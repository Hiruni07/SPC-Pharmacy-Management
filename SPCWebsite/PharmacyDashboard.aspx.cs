using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace SPCWebsite
{
    public partial class PharmacyDashboard : Page
    {
        private string connectionString = "server=localhost;userid=root;password=;database=spc_pharmacy_db;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDrugs();
                LoadPharmacies();

                txtDrugId.Attributes["placeholder"] = "Enter Drug ID";
                txtOrderQty.Attributes["placeholder"] = "Enter Quantity";
                txtOrderNote.Attributes["placeholder"] = "Additional Notes (optional)";
                txtSearchDrug.Attributes["placeholder"] = "Search by drug name...";
            }
        }

        private void LoadPharmacies()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT pharmacy_id, company_name FROM pharmacies";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ddlPharmacies.DataSource = dt;
                    ddlPharmacies.DataTextField = "company_name";
                    ddlPharmacies.DataValueField = "pharmacy_id";
                    ddlPharmacies.DataBind();
                }
            }

            ddlPharmacies.Items.Insert(0, new ListItem("-- Select Pharmacy --", "0"));
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
                string query = @"SELECT drug_id, drug_name, generic_name, unit_price, quantity_in_stock 
                                 FROM drugs 
                                 WHERE drug_name LIKE @keyword OR generic_name LIKE @keyword";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvDrugs.DataSource = dt;
                    gvDrugs.DataBind();
                }
            }
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            int pharmacyId;
            if (!int.TryParse(ddlPharmacies.SelectedValue, out pharmacyId) || pharmacyId == 0)
            {
                lblStatus.CssClass = "text-danger";
                lblStatus.Text = "❌ Please select a valid pharmacy.";
                return;
            }

            string drugIdText = txtDrugId.Text.Trim();
            string quantityText = txtOrderQty.Text.Trim();
            string notes = txtOrderNote.Text.Trim();

            if (string.IsNullOrEmpty(drugIdText) || string.IsNullOrEmpty(quantityText))
            {
                lblStatus.CssClass = "text-danger";
                lblStatus.Text = "❌ Please enter Drug ID and Quantity.";
                return;
            }

            int drugId, quantity;
            if (!int.TryParse(drugIdText, out drugId) || !int.TryParse(quantityText, out quantity) || quantity <= 0)
            {
                lblStatus.CssClass = "text-danger";
                lblStatus.Text = "❌ Invalid Drug ID or Quantity.";
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    decimal unitPrice;
                    int quantityInStock;

                    // Get price and stock
                    using (MySqlCommand getDetails = new MySqlCommand("SELECT unit_price, quantity_in_stock FROM drugs WHERE drug_id = @drugId", conn))
                    {
                        getDetails.Parameters.AddWithValue("@drugId", drugId);
                        using (MySqlDataReader reader = getDetails.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                lblStatus.CssClass = "text-danger";
                                lblStatus.Text = "❌ Drug not found.";
                                return;
                            }

                            unitPrice = reader.GetDecimal("unit_price");
                            quantityInStock = reader.GetInt32("quantity_in_stock");
                        }
                    }

                    // Validate available stock
                    if (quantity > quantityInStock)
                    {
                        lblStatus.CssClass = "text-danger";
                        lblStatus.Text = $"❌ Not enough stock. Only {quantityInStock} units available.";
                        return;
                    }

                    decimal totalAmount = unitPrice * quantity;

                    // Insert order
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"INSERT INTO orders (pharmacy_id, order_date, status, total_amount, order_notes) 
                          VALUES (@PharmacyId, @OrderDate, 'PENDING', @TotalAmount, @Notes)", conn))
                    {
                        cmd.Parameters.AddWithValue("@PharmacyId", pharmacyId);
                        cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@Notes", notes);
                        cmd.ExecuteNonQuery();
                    }

                    lblStatus.CssClass = "text-success";
                    lblStatus.Text = "✅ Order placed successfully.";

                    // Clear inputs
                    txtDrugId.Text = "";
                    txtOrderQty.Text = "";
                    txtOrderNote.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblStatus.CssClass = "text-danger";
                lblStatus.Text = "❌ Database error: " + ex.Message;
            }
        }
    }
}
