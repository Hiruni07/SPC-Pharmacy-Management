using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SPCPharmacyManagement
{
    public partial class OrderManagementForm : Form
    {
        private int selectedOrderId = 0;
        private List<OrderItem> currentOrderItems = new List<OrderItem>();

        public OrderManagementForm()
        {
            InitializeComponent();
            LoadOrders();
            LoadPharmacies();
            LoadDrugs();

            dgvOrders.SelectionChanged += DgvOrders_SelectionChanged;
        }

        private void LoadOrders()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM orders";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvOrders.DataSource = dt;
            }
        }

        private void LoadPharmacies()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT pharmacy_id, company_name FROM pharmacies";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                cmbPharmacy.DataSource = dt;
                cmbPharmacy.DisplayMember = "company_name";
                cmbPharmacy.ValueMember = "pharmacy_id";
            }
        }

        private void LoadDrugs()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT drug_id, drug_name, unit_price FROM drugs";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                cmbDrug.DataSource = dt;
                cmbDrug.DisplayMember = "drug_name";
                cmbDrug.ValueMember = "drug_id";
            }
        }

        private void DgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;

            selectedOrderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["order_id"].Value);
            LoadOrderItems(selectedOrderId);
        }

        private void LoadOrderItems(int orderId)
        {
            currentOrderItems.Clear();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT oi.drug_id, d.drug_name, oi.quantity, oi.unit_price, oi.total_price
                                 FROM order_items oi
                                 JOIN drugs d ON oi.drug_id = d.drug_id
                                 WHERE oi.order_id = @orderId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orderId", orderId);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    currentOrderItems.Add(new OrderItem
                    {
                        DrugId = Convert.ToInt32(reader["drug_id"]),
                        DrugName = reader["drug_name"].ToString(),
                        Quantity = Convert.ToInt32(reader["quantity"]),
                        UnitPrice = Convert.ToDecimal(reader["unit_price"]),
                        TotalPrice = Convert.ToDecimal(reader["total_price"])
                    });
                }
            }
            RefreshOrderItemsGrid();
            UpdateTotalAmount();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbDrug.SelectedItem == null || nudQuantity.Value < 1)
                return;

            DataRowView drug = cmbDrug.SelectedItem as DataRowView;
            decimal unitPrice = Convert.ToDecimal(drug["unit_price"]);
            int quantity = (int)nudQuantity.Value;

            // Check if drug already in list, update quantity if so
            var existingItem = currentOrderItems.Find(i => i.DrugId == Convert.ToInt32(drug["drug_id"]));
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.TotalPrice = existingItem.Quantity * existingItem.UnitPrice;
            }
            else
            {
                currentOrderItems.Add(new OrderItem
                {
                    DrugId = Convert.ToInt32(drug["drug_id"]),
                    DrugName = drug["drug_name"].ToString(),
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    TotalPrice = unitPrice * quantity
                });
            }

            RefreshOrderItemsGrid();
            UpdateTotalAmount();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.CurrentRow != null)
            {
                int index = dgvOrderItems.CurrentRow.Index;
                if (index >= 0 && index < currentOrderItems.Count)
                {
                    currentOrderItems.RemoveAt(index);
                    RefreshOrderItemsGrid();
                    UpdateTotalAmount();
                }
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == 0)
            {
                MessageBox.Show("Please select an order to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this order?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    MySqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        // First delete order items
                        MySqlCommand deleteItemsCmd = new MySqlCommand("DELETE FROM order_items WHERE order_id = @orderId", conn, transaction);
                        deleteItemsCmd.Parameters.AddWithValue("@orderId", selectedOrderId);
                        deleteItemsCmd.ExecuteNonQuery();

                        // Then delete order
                        MySqlCommand deleteOrderCmd = new MySqlCommand("DELETE FROM orders WHERE order_id = @orderId", conn, transaction);
                        deleteOrderCmd.Parameters.AddWithValue("@orderId", selectedOrderId);
                        deleteOrderCmd.ExecuteNonQuery();

                        transaction.Commit();

                        MessageBox.Show("Order deleted successfully.");
                        ClearForm();
                        LoadOrders();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Failed to delete order.\n" + ex.Message);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            DataTable dt = dgvOrders.DataSource as DataTable;
            if (dt != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        dt.DefaultView.RowFilter = $"Convert(order_id, 'System.String') LIKE '%{searchText}%'";
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid search value.\n" + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = dgvOrders.DataSource as DataTable;
            if (dt != null)
            {
                string filter = cmbStatusFilter.SelectedItem?.ToString() ?? "All";
                if (filter == "All")
                {
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    dt.DefaultView.RowFilter = $"status = '{filter}'";
                }
            }
        }

        private void RefreshOrderItemsGrid()
        {
            dgvOrderItems.DataSource = null;
            dgvOrderItems.DataSource = currentOrderItems;
            dgvOrderItems.Refresh();
        }

        private void UpdateTotalAmount()
        {
            decimal total = 0;
            foreach (var item in currentOrderItems)
            {
                total += item.TotalPrice;
            }
            lblTotalAmount.Text = $"Total Amount: ${total:F2}";
        }

        private void ClearForm()
        {
            currentOrderItems.Clear();
            RefreshOrderItemsGrid();
            selectedOrderId = 0;
            UpdateTotalAmount();
        }

        private void gbNewOrder_Enter(object sender, EventArgs e)
        {
            // Optional: handle if needed
        }
    }

    public class OrderItem
    {
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
