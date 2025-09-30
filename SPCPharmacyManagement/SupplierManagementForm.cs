using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SPCPharmacyManagement.Models;

namespace SPCPharmacyManagement
{
    public partial class SupplierManagementForm : Form
    {
        private int selectedSupplierId = 0;

        public SupplierManagementForm()
        {
            InitializeComponent();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT supplier_id AS 'ID', company_name AS 'Company Name',
                                     contact_person AS 'Contact Person', email AS 'Email',
                                     phone AS 'Phone', license_number AS 'License Number',
                                     password AS 'Password', registration_date AS 'Registration Date'
                                     FROM suppliers
                                     ORDER BY company_name";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvSuppliers.DataSource = dataTable;
                    dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvSuppliers.SelectedRows[0];
                selectedSupplierId = Convert.ToInt32(row.Cells["ID"].Value);

                txtCompanyName.Text = row.Cells["Company Name"].Value?.ToString();
                txtContactPerson.Text = row.Cells["Contact Person"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
                txtLicenseNumber.Text = row.Cells["License Number"].Value?.ToString();
                txtPassword.Text = row.Cells["Password"].Value?.ToString();

                LoadSupplierAddress(selectedSupplierId);
            }
        }

        private void LoadSupplierAddress(int supplierId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT address FROM suppliers WHERE supplier_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", supplierId);
                    object result = cmd.ExecuteScalar();
                    txtAddress.Text = result?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading address: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string query = @"INSERT INTO suppliers
                                         (company_name, contact_person, email, phone, address, license_number, password)
                                         VALUES
                                         (@company_name, @contact_person, @email, @phone, @address, @license_number, @password)";

                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@company_name", txtCompanyName.Text.Trim());
                        cmd.Parameters.AddWithValue("@contact_person", txtContactPerson.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@license_number", txtLicenseNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Supplier added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadSuppliers();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding supplier: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == 0)
            {
                MessageBox.Show("Please select a supplier to update.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateInput())
            {
                try
                {
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string query = @"UPDATE suppliers SET
                                         company_name = @company_name,
                                         contact_person = @contact_person,
                                         email = @email,
                                         phone = @phone,
                                         address = @address,
                                         license_number = @license_number,
                                         password = @password
                                         WHERE supplier_id = @id";

                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@company_name", txtCompanyName.Text.Trim());
                        cmd.Parameters.AddWithValue("@contact_person", txtContactPerson.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@license_number", txtLicenseNumber.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", selectedSupplierId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Supplier updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadSuppliers();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating supplier: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == 0)
            {
                MessageBox.Show("Please select a supplier to delete.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this supplier?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string query = "DELETE FROM suppliers WHERE supplier_id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@id", selectedSupplierId);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Supplier deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadSuppliers();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting supplier: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtCompanyName.Clear();
            txtContactPerson.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtLicenseNumber.Clear();
            txtPassword.Clear();
            selectedSupplierId = 0;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                MessageBox.Show("Company Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
            {
                MessageBox.Show("License Number is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
