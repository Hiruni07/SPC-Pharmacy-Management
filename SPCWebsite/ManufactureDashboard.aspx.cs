using System;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace SPCWebsite
{
    public partial class ManufactureDashboard : Page
    {
        private string connectionString = "server=localhost;userid=root;password=;database=spc_pharmacy_db;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Add placeholders dynamically
                txtDrugName.Attributes["placeholder"] = "Enter drug name";
                txtQuantity.Attributes["placeholder"] = "Enter quantity";
                txtUnitPrice.Attributes["placeholder"] = "Enter unit price";
                txtUpdateReason.Attributes["placeholder"] = "Enter update reason";
            }
        }

        // ✅ REPLACED METHOD BELOW
        protected void btnUpdateStock_Click(object sender, EventArgs e)
        {
            string drugName = txtDrugName.Text.Trim();
            string quantityText = txtQuantity.Text.Trim();
            string priceText = txtUnitPrice.Text.Trim();
            string reason = txtUpdateReason.Text.Trim();

            if (string.IsNullOrEmpty(drugName) || string.IsNullOrEmpty(quantityText) ||
                string.IsNullOrEmpty(priceText) || string.IsNullOrEmpty(reason))
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            int quantity;
            if (!int.TryParse(quantityText, out quantity) || quantity <= 0)

            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Quantity must be a positive integer.";
                return;
            }

            decimal unitPrice;
            if (!decimal.TryParse(priceText, out unitPrice) || unitPrice <= 0)

            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Unit price must be a positive decimal number.";
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string getDrugIdQuery = "SELECT drug_id FROM drugs WHERE drug_name = @DrugName";
                    int drugId;

                    using (MySqlCommand cmd = new MySqlCommand(getDrugIdQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@DrugName", drugName);
                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            lblMessage.CssClass = "text-danger";
                            lblMessage.Text = "Drug not found.";
                            return;
                        }

                        drugId = Convert.ToInt32(result);
                    }

                    string updateQuery = @"UPDATE drugs 
                                           SET quantity_in_stock = quantity_in_stock + @Quantity,
                                               unit_price = @UnitPrice
                                           WHERE drug_id = @DrugId";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                        cmd.Parameters.AddWithValue("@DrugId", drugId);
                        cmd.ExecuteNonQuery();
                    }

                    string insertLogQuery = @"INSERT INTO stock_updates
                                              (drug_id, quantity, update_type, reason, update_date, updated_by)
                                              VALUES (@DrugId, @Quantity, 'ADD', @Reason, @UpdateDate, @UpdatedBy)";

                    using (MySqlCommand cmd = new MySqlCommand(insertLogQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@DrugId", drugId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@Reason", reason);
                        cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UpdatedBy", Session["UserEmail"] ?? "unknown");
                        cmd.ExecuteNonQuery();
                    }

                    lblMessage.CssClass = "text-success";
                    lblMessage.Text = "Stock updated successfully.";

                    // Clear inputs
                    txtDrugName.Text = "";
                    txtQuantity.Text = "";
                    txtUnitPrice.Text = "";
                    txtUpdateReason.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
