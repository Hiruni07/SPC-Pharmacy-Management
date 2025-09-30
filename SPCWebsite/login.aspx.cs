using System;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace SPCWebsite
{
    public partial class Login : Page
    {
        private string connectionString = "server=localhost;user id=root;password=;database=spc_pharmacy_db;";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Optional: clear previous login session or status
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowPopup("Please enter both email and password.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Step 1: Check in user table
                    string userQuery = "SELECT user_id, role FROM user WHERE email = @Email AND password = @Password";
                    using (MySqlCommand cmd = new MySqlCommand(userQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("user_id");
                                string role = reader.GetString("role");

                                Session["user_id"] = userId;
                                Session["role"] = role;

                                ShowPopup("Login successful!");

                                string redirectPage = "";

                                if (role == "Pharmacy")
                                    redirectPage = "PharmacyDashboard.aspx";
                                else if (role == "Warehouse")
                                    redirectPage = "WarehouseDashboard.aspx";
                                else if (role == "Manufacture")
                                    redirectPage = "ManufactureDashboard.aspx";
                                else if (role == "Supplier")
                                    redirectPage = "SupplierDashboard.aspx";
                                else
                                {
                                    ShowPopup("Unknown role type.");
                                    return;
                                }

                                // Use JavaScript delay before redirecting
                                ClientScript.RegisterStartupScript(this.GetType(), "redirect",
                                    "setTimeout(function() { window.location='" + redirectPage + "'; }, 1500);", true);
                                return;
                            }
                        }
                    }

                    // Step 2: Check in suppliers table
                    string supplierQuery = "SELECT supplier_id FROM suppliers WHERE email = @Email AND password = @Password";
                    using (MySqlCommand cmd = new MySqlCommand(supplierQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            Session["supplier_id"] = result.ToString();
                            Session["role"] = "Supplier";

                            ShowPopup("Login successful!");
                            ClientScript.RegisterStartupScript(this.GetType(), "redirect",
                                "setTimeout(function() { window.location='SupplierDashboard.aspx'; }, 1500);", true);
                            return;
                        }
                    }

                    // Step 3: Check in pharmacies table
                    string pharmacyQuery = "SELECT pharmacy_id FROM pharmacies WHERE email = @Email AND password = @Password";
                    using (MySqlCommand cmd = new MySqlCommand(pharmacyQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            Session["pharmacy_id"] = result.ToString();
                            Session["role"] = "Pharmacy";

                            ShowPopup("Login successful!");
                            ClientScript.RegisterStartupScript(this.GetType(), "redirect",
                                "setTimeout(function() { window.location='PharmacyDashboard.aspx'; }, 1500);", true);
                            return;
                        }
                    }

                    // Step 4: Invalid login
                    ShowPopup("Invalid email or password.");
                }
            }
            catch (Exception ex)
            {
                ShowPopup("Login failed: " + ex.Message);
            }
        }

        private void ShowPopup(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{message}');", true);
        }
    }
}
