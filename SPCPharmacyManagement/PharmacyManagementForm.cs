using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SPCPharmacyManagement
{
    public partial class PharmacyManagementForm : Form
    {
        private string connectionString = "server=localhost;user=root;password=;database=spc_pharmacy_db";
        private int selectedPharmacyId = -1;
        private MySqlConnection connection;

        public PharmacyManagementForm()
        {
            InitializeComponent();
            LoadPharmacies();
        }

        private void LoadPharmacies(string keyword = "")
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT pharmacy_id, company_name, contact_person, phone, email, address, 
                                     license_number, registration_date FROM pharmacies";

                    if (!string.IsNullOrWhiteSpace(keyword))
                        query += " WHERE company_name LIKE @keyword OR contact_person LIKE @keyword";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (!string.IsNullOrWhiteSpace(keyword))
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvPharmacies.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load pharmacies: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtLicenseNumber.Text))
            {
                MessageBox.Show("Company Name, License Number, and Password are required.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"INSERT INTO pharmacies
                             (company_name, contact_person, email, phone, address, license_number, password)
                             VALUES
                             (@company_name, @contact_person, @email, @phone, @address, @license_number, @password)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@company_name", txtCompanyName.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact_person", txtContactPerson.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@license_number", txtLicenseNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pharmacy added successfully!");
                    ClearInputs();
                    LoadPharmacies();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding pharmacy: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPharmacyId == -1)
            {
                MessageBox.Show("Please select a pharmacy to update.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"UPDATE pharmacies SET 
                             company_name = @name,
                             contact_person = @contact,
                             phone = @phone,
                             email = @email,
                             address = @address,
                             license_number = @license
                             WHERE pharmacy_id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtCompanyName.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact", txtContactPerson.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@license", txtLicenseNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", selectedPharmacyId);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pharmacy updated successfully!");
                    ClearInputs();
                    LoadPharmacies();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating pharmacy: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPharmacyId == -1)
            {
                MessageBox.Show("Please select a pharmacy to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "DELETE FROM pharmacies WHERE pharmacy_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedPharmacyId);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pharmacy deleted successfully.");
                    ClearInputs();
                    LoadPharmacies();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting pharmacy: " + ex.Message);
            }
        }

        private void dgvPharmacies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPharmacies.Rows[e.RowIndex];
                selectedPharmacyId = Convert.ToInt32(row.Cells["pharmacy_id"].Value);

                txtCompanyName.Text = row.Cells["company_name"].Value?.ToString();
                txtContactPerson.Text = row.Cells["contact_person"].Value?.ToString();
                txtPhone.Text = row.Cells["phone"].Value?.ToString();
                txtEmail.Text = row.Cells["email"].Value?.ToString();
                txtAddress.Text = row.Cells["address"].Value?.ToString();
                txtLicenseNumber.Text = row.Cells["license_number"].Value?.ToString();

                txtPassword.Text = "";
                txtPassword.Enabled = false;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPharmacies(txtSearch.Text.Trim());
        }

        private void ClearInputs()
        {
            selectedPharmacyId = -1;
            txtCompanyName.Clear();
            txtContactPerson.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtLicenseNumber.Clear();
            txtPassword.Clear();
            txtPassword.Enabled = true;
        }
    }
}
