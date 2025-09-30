using System;
using System.Data;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace SPCWebsite
{
    public partial class WarehouseDashboard : Page
    {
        private string connectionString = "server=localhost;userid=root;password=;database=spc_pharmacy_db;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDrugs(); // Load all drugs initially
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDrugs(txtSearchDrug.Text.Trim());
        }

        private void LoadDrugs(string keyword = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT drug_id, drug_name, unit_price, quantity_in_stock, expiry_date 
                    FROM drugs 
                    WHERE drug_name LIKE @keyword OR generic_name LIKE @keyword";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvDrugs.DataSource = dt;
                    gvDrugs.DataBind();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string drugName = txtDrugName.Text.Trim();
            string quantityText = txtQuantity.Text.Trim();
            string priceText = txtUnitPrice.Text.Trim();
            string reason = txtUpdateReason.Text.Trim();

            if (string.IsNullOrEmpty(drugName) || string.IsNullOrEmpty(quantityText) ||
                string.IsNullOrEmpty(priceText) || string.IsNullOrEmpty(reason))
            {
                lblStatus.CssClass = "text-danger";
                lblStatus.Text = "Please fill in all fields.";
                return;
            }

            int quantity;
            if (!int.TryParse(quantityText, out quantity) || quantity <= 0)

            {
                lblStatus.CssClass = "text-danger";
                lblStatus.Text = "Quantity must be a positive number.";
                return;
            }

            decimal unitPrice;
            if (!decimal.TryParse(priceText, out unitPrice) || unitPrice <= 0)

            {
                lblStatus.CssClass = "text-danger";
                lblStatus.Text = "Unit price must be valid.";
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string getDrugQuery = "SELECT drug_id FROM drugs WHERE drug_name = @DrugName";
                    int drugId;

                    using (MySqlCommand cmd = new MySqlCommand(getDrugQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@DrugName", drugName);
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            lblStatus.CssClass = "text-danger";
                            lblStatus.Text = "Drug not found.";
                            return;
                        }
                        drugId = Convert.ToInt32(result);
                    }

                    string updateDrugQuery = @"UPDATE drugs 
                                               SET quantity_in_stock = quantity_in_stock + @Quantity,
                                                   unit_price = @UnitPrice 
                                               WHERE drug_id = @DrugId";

                    using (MySqlCommand cmd = new MySqlCommand(updateDrugQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                        cmd.Parameters.AddWithValue("@DrugId", drugId);
                        cmd.ExecuteNonQuery();
                    }

                    string logQuery = @"INSERT INTO stock_updates 
                                        (drug_id, quantity, update_type, reason, update_date, updated_by)
                                        VALUES (@DrugId, @Quantity, 'ADD', @Reason, @UpdateDate, @UpdatedBy)";

                    using (MySqlCommand cmd = new MySqlCommand(logQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@DrugId", drugId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@Reason", reason);
                        cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UpdatedBy", Session["UserEmail"] ?? "warehouse@spc.lk");
                        cmd.ExecuteNonQuery();
                    }

                    lblStatus.CssClass = "text-success";
                    lblStatus.Text = "Stock updated successfully.";

                    // Clear form
                    txtDrugName.Text = "";
                    txtQuantity.Text = "";
                    txtUnitPrice.Text = "";
                    txtUpdateReason.Text = "";

                    LoadDrugs(); // Refresh table
                }
            }
            catch (Exception ex)
            {
                lblStatus.CssClass = "text-danger";
                lblStatus.Text = "Error: " + ex.Message;
            }
        }
    }
}
