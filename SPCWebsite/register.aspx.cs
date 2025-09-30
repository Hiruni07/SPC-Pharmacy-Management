using System;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace SPCWebsite
{
    public partial class Register : Page
    {
        private string connectionString = "server=localhost;user id=root;password=;database=spc_pharmacy_db;";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompany.Text) ||
                string.IsNullOrWhiteSpace(txtContact.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtLicense.Text) ||
                string.IsNullOrWhiteSpace(ddlRole.SelectedValue) ||
                ddlRole.SelectedValue == "Select Role")
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please fill in all fields and select a valid role.";
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Gather values from form
                    string role = ddlRole.SelectedValue.Trim();
                    string company = txtCompany.Text.Trim();
                    string contact = txtContact.Text.Trim();
                    string email = txtEmail.Text.Trim();
                    string phone = txtPhone.Text.Trim();
                    string address = txtAddress.Text.Trim();
                    string license = txtLicense.Text.Trim();
                    string password = txtPassword.Text.Trim();

                    // Insert into user table
                    string insertUserQuery = @"INSERT INTO user 
                        (company_name, contact_person, email, phone, address, license_number, role, password, registered_at)
                        VALUES (@Company, @Contact, @Email, @Phone, @Address, @License, @Role, @Password, NOW())";

                    MySqlCommand userCmd = new MySqlCommand(insertUserQuery, conn);
                    userCmd.Parameters.AddWithValue("@Company", company);
                    userCmd.Parameters.AddWithValue("@Contact", contact);
                    userCmd.Parameters.AddWithValue("@Email", email);
                    userCmd.Parameters.AddWithValue("@Phone", phone);
                    userCmd.Parameters.AddWithValue("@Address", address);
                    userCmd.Parameters.AddWithValue("@License", license);
                    userCmd.Parameters.AddWithValue("@Role", role); // ✅ This ensures 'Supplier' is stored
                    userCmd.Parameters.AddWithValue("@Password", password); // 🔒 Consider hashing

                    int userResult = userCmd.ExecuteNonQuery();
                    if (userResult == 0)
                    {
                        lblMessage.CssClass = "text-danger";
                        lblMessage.Text = "Failed to register user.";
                        return;
                    }

                    // Get inserted user_id
                    long userId = userCmd.LastInsertedId;

                    // Prepare insert for role-specific table
                    string roleQuery = "";

                    switch (role)
                    {
                        case "Supplier":
                            roleQuery = @"INSERT INTO suppliers 
                                (supplier_id, company_name, contact_person, email, phone, address, license_number, registration_date)
                                VALUES (@UserId, @Company, @Contact, @Email, @Phone, @Address, @License, NOW())";
                            break;

                        case "Pharmacy":
                            roleQuery = @"INSERT INTO pharmacies 
                                (pharmacy_id, company_name, contact_person, email, phone, address, license_number, registration_date)
                                VALUES (@UserId, @Company, @Contact, @Email, @Phone, @Address, @License, NOW())";
                            break;

                        case "Manufacture":
                            roleQuery = @"INSERT INTO manufacture 
                                (manufacture_id, company_name, contact_person, email, phone, address, license_number, registration_date)
                                VALUES (@UserId, @Company, @Contact, @Email, @Phone, @Address, @License, NOW())";
                            break;

                        case "Warehouse":
                            roleQuery = @"INSERT INTO warehouse 
                                (warehouse_id, company_name, contact_person, email, phone, address, license_number, registration_date)
                                VALUES (@UserId, @Company, @Contact, @Email, @Phone, @Address, @License, NOW())";
                            break;

                        default:
                            lblMessage.CssClass = "text-danger";
                            lblMessage.Text = "Invalid role selected.";
                            return;
                    }

                    MySqlCommand roleCmd = new MySqlCommand(roleQuery, conn);
                    roleCmd.Parameters.AddWithValue("@UserId", userId);
                    roleCmd.Parameters.AddWithValue("@Company", company);
                    roleCmd.Parameters.AddWithValue("@Contact", contact);
                    roleCmd.Parameters.AddWithValue("@Email", email);
                    roleCmd.Parameters.AddWithValue("@Phone", phone);
                    roleCmd.Parameters.AddWithValue("@Address", address);
                    roleCmd.Parameters.AddWithValue("@License", license);

                    int roleResult = roleCmd.ExecuteNonQuery();

                    if (roleResult > 0)
                    {
                        lblMessage.CssClass = "text-success";
                        lblMessage.Text = "Registration successful!";
                        ClearForm();
                    }
                    else
                    {
                        lblMessage.CssClass = "text-warning";
                        lblMessage.Text = "User registered, but role table insertion failed.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        private void ClearForm()
        {
            txtCompany.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtLicense.Text = "";
            ddlRole.SelectedIndex = 0;
        }
    }
}
