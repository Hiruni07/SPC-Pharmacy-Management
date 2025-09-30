using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SPCPharmacyManagement
{
    public partial class InventoryManagementForm : Form
    {
        private int selectedDrugId = 0;

        public InventoryManagementForm()
        {
            InitializeComponent();
            LoadInventory();
        }

        private void LoadInventory()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT drug_id as 'ID', drug_name as 'Drug Name', 
                                   generic_name as 'Generic Name', manufacturer as 'Manufacturer',
                                   batch_number as 'Batch Number', expiry_date as 'Expiry Date',
                                   unit_price as 'Unit Price', quantity_in_stock as 'Stock Quantity'
                                   FROM drugs ORDER BY drug_name";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvInventory.DataSource = dataTable;
                    dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Format expiry date and price columns
                    if (dgvInventory.Columns["Expiry Date"] != null)
                        dgvInventory.Columns["Expiry Date"].DefaultCellStyle.Format = "yyyy-MM-dd";

                    if (dgvInventory.Columns["Unit Price"] != null)
                        dgvInventory.Columns["Unit Price"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvInventory.SelectedRows[0];
                selectedDrugId = Convert.ToInt32(row.Cells["ID"].Value);

                txtDrugName.Text = row.Cells["Drug Name"].Value?.ToString();
                txtGenericName.Text = row.Cells["Generic Name"].Value?.ToString();
                txtManufacturer.Text = row.Cells["Manufacturer"].Value?.ToString();
                txtBatchNumber.Text = row.Cells["Batch Number"].Value?.ToString();

                // Fixed variable declarations with proper syntax
                string expiryDateStr = row.Cells["Expiry Date"].Value?.ToString();
                DateTime expiryDate;
                if (DateTime.TryParse(expiryDateStr, out expiryDate))
                    dtpExpiryDate.Value = expiryDate;

                string unitPriceStr = row.Cells["Unit Price"].Value?.ToString();
                decimal unitPrice;
                if (decimal.TryParse(unitPriceStr, out unitPrice))
                    nudUnitPrice.Value = unitPrice;

                string quantityStr = row.Cells["Stock Quantity"].Value?.ToString();
                int quantity;
                if (int.TryParse(quantityStr, out quantity))
                    nudQuantityInStock.Value = quantity;

                LoadDrugDescription(selectedDrugId);
            }
        }

        private void LoadDrugDescription(int drugId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT description FROM drugs WHERE drug_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", drugId);

                    object result = cmd.ExecuteScalar();
                    txtDescription.Text = result?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading description: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDrug_Click(object sender, EventArgs e)
        {
            if (ValidateDrugInput())
            {
                try
                {
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string query = @"INSERT INTO drugs (drug_name, generic_name, manufacturer, batch_number, 
                                       expiry_date, unit_price, quantity_in_stock, description) 
                                       VALUES (@drug_name, @generic_name, @manufacturer, @batch_number, 
                                       @expiry_date, @unit_price, @quantity_in_stock, @description)";

                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@drug_name", txtDrugName.Text);
                        cmd.Parameters.AddWithValue("@generic_name", txtGenericName.Text);
                        cmd.Parameters.AddWithValue("@manufacturer", txtManufacturer.Text);
                        cmd.Parameters.AddWithValue("@batch_number", txtBatchNumber.Text);
                        cmd.Parameters.AddWithValue("@expiry_date", dtpExpiryDate.Value.Date);
                        cmd.Parameters.AddWithValue("@unit_price", nudUnitPrice.Value);
                        cmd.Parameters.AddWithValue("@quantity_in_stock", nudQuantityInStock.Value);
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Drug added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadInventory();
                        ClearDrugForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding drug: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateDrug_Click(object sender, EventArgs e)
        {
            if (selectedDrugId == 0)
            {
                MessageBox.Show("Please select a drug to update.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateDrugInput())
            {
                try
                {
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string query = @"UPDATE drugs SET drug_name = @drug_name, generic_name = @generic_name, 
                                       manufacturer = @manufacturer, batch_number = @batch_number, 
                                       expiry_date = @expiry_date, unit_price = @unit_price, 
                                       quantity_in_stock = @quantity_in_stock, description = @description 
                                       WHERE drug_id = @id";

                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@drug_name", txtDrugName.Text);
                        cmd.Parameters.AddWithValue("@generic_name", txtGenericName.Text);
                        cmd.Parameters.AddWithValue("@manufacturer", txtManufacturer.Text);
                        cmd.Parameters.AddWithValue("@batch_number", txtBatchNumber.Text);
                        cmd.Parameters.AddWithValue("@expiry_date", dtpExpiryDate.Value.Date);
                        cmd.Parameters.AddWithValue("@unit_price", nudUnitPrice.Value);
                        cmd.Parameters.AddWithValue("@quantity_in_stock", nudQuantityInStock.Value);
                        cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@id", selectedDrugId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Drug updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadInventory();
                        ClearDrugForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating drug: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteDrug_Click(object sender, EventArgs e)
        {
            if (selectedDrugId == 0)
            {
                MessageBox.Show("Please select a drug to delete.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this drug?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        string query = "DELETE FROM drugs WHERE drug_id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@id", selectedDrugId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Drug deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadInventory();
                        ClearDrugForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting drug: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            if (selectedDrugId == 0)
            {
                MessageBox.Show("Please select a drug to update stock.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateStockUpdate())
            {
                try
                {
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        using (var transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Insert stock update record
                                string insertQuery = @"INSERT INTO stock_updates (drug_id, quantity, update_type, reason, updated_by) 
                                                     VALUES (@drug_id, @quantity, @update_type, @reason, @updated_by)";
                                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection, transaction);
                                insertCmd.Parameters.AddWithValue("@drug_id", selectedDrugId);
                                insertCmd.Parameters.AddWithValue("@quantity", nudUpdateQuantity.Value);
                                insertCmd.Parameters.AddWithValue("@update_type", cmbUpdateType.SelectedItem.ToString());
                                insertCmd.Parameters.AddWithValue("@reason", txtUpdateReason.Text);
                                insertCmd.Parameters.AddWithValue("@updated_by", txtUpdatedBy.Text);
                                insertCmd.ExecuteNonQuery();

                                // Update drug quantity
                                string updateQuery;
                                if (cmbUpdateType.SelectedItem.ToString() == "ADD")
                                {
                                    updateQuery = "UPDATE drugs SET quantity_in_stock = quantity_in_stock + @quantity WHERE drug_id = @drug_id";
                                }
                                else
                                {
                                    updateQuery = "UPDATE drugs SET quantity_in_stock = quantity_in_stock - @quantity WHERE drug_id = @drug_id";
                                }

                                MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection, transaction);
                                updateCmd.Parameters.AddWithValue("@quantity", nudUpdateQuantity.Value);
                                updateCmd.Parameters.AddWithValue("@drug_id", selectedDrugId);
                                updateCmd.ExecuteNonQuery();

                                transaction.Commit();
                                MessageBox.Show("Stock updated successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LoadInventory();
                                ClearStockUpdateForm();
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating stock: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearDrug_Click(object sender, EventArgs e)
        {
            ClearDrugForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchDrugs();
        }

        private void SearchDrugs()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string searchTerm = txtSearch.Text.Trim();
                    string query;

                    if (string.IsNullOrEmpty(searchTerm))
                    {
                        LoadInventory();
                        return;
                    }

                    query = @"SELECT drug_id as 'ID', drug_name as 'Drug Name', 
                            generic_name as 'Generic Name', manufacturer as 'Manufacturer',
                            batch_number as 'Batch Number', expiry_date as 'Expiry Date',
                            unit_price as 'Unit Price', quantity_in_stock as 'Stock Quantity'
                            FROM drugs 
                            WHERE drug_name LIKE @search OR generic_name LIKE @search 
                            OR manufacturer LIKE @search OR batch_number LIKE @search
                            ORDER BY drug_name";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvInventory.DataSource = dataTable;
                    dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Format columns
                    if (dgvInventory.Columns["Expiry Date"] != null)
                        dgvInventory.Columns["Expiry Date"].DefaultCellStyle.Format = "yyyy-MM-dd";

                    if (dgvInventory.Columns["Unit Price"] != null)
                        dgvInventory.Columns["Unit Price"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching drugs: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearDrugForm()
        {
            txtDrugName.Clear();
            txtGenericName.Clear();
            txtManufacturer.Clear();
            txtBatchNumber.Clear();
            dtpExpiryDate.Value = DateTime.Now.AddMonths(12);
            nudUnitPrice.Value = 0;
            nudQuantityInStock.Value = 0;
            txtDescription.Clear();
            selectedDrugId = 0;
        }

        private void ClearStockUpdateForm()
        {
            cmbUpdateType.SelectedIndex = 0;
            nudUpdateQuantity.Value = 1;
            txtUpdateReason.Clear();
            txtUpdatedBy.Clear();
        }

        private bool ValidateDrugInput()
        {
            if (string.IsNullOrWhiteSpace(txtDrugName.Text))
            {
                MessageBox.Show("Drug name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDrugName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtManufacturer.Text))
            {
                MessageBox.Show("Manufacturer is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManufacturer.Focus();
                return false;
            }

            if (dtpExpiryDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Expiry date must be in the future.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpExpiryDate.Focus();
                return false;
            }

            if (nudUnitPrice.Value <= 0)
            {
                MessageBox.Show("Unit price must be greater than zero.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudUnitPrice.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateStockUpdate()
        {
            if (cmbUpdateType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select update type.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUpdateType.Focus();
                return false;
            }

            if (nudUpdateQuantity.Value <= 0)
            {
                MessageBox.Show("Update quantity must be greater than zero.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudUpdateQuantity.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUpdatedBy.Text))
            {
                MessageBox.Show("Updated by field is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpdatedBy.Focus();
                return false;
            }

            // Check if removing more stock than available
            if (cmbUpdateType.SelectedItem.ToString() == "REMOVE")
            {
                if (nudUpdateQuantity.Value > nudQuantityInStock.Value)
                {
                    MessageBox.Show("Cannot remove more stock than available.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudUpdateQuantity.Focus();
                    return false;
                }
            }

            return true;
        }

        // Event handler for Enter key in search textbox
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchDrugs();
                e.Handled = true;
            }
        }

        // Method to refresh inventory data
        public void RefreshInventory()
        {
            LoadInventory();
        }

        // Method to get low stock items
        private void CheckLowStock()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT drug_name, quantity_in_stock 
                                   FROM drugs 
                                   WHERE quantity_in_stock < 10 
                                   ORDER BY quantity_in_stock";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    string lowStockItems = "";
                    while (reader.Read())
                    {
                        lowStockItems += $"{reader["drug_name"]}: {reader["quantity_in_stock"]} units\n";
                    }

                    if (!string.IsNullOrEmpty(lowStockItems))
                    {
                        MessageBox.Show($"Low Stock Alert:\n\n{lowStockItems}", "Low Stock Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking low stock: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Override form load to check low stock
        private void InventoryManagementForm_Load(object sender, EventArgs e)
        {
            CheckLowStock();
        }
    }
}
