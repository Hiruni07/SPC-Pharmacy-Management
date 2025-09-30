using System;
using System.Windows.Forms;

namespace SPCPharmacyManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CheckDatabaseConnection();
        }

        private void CheckDatabaseConnection()
        {
            if (!DatabaseConnection.TestConnection())
            {
                MessageBox.Show("Database connection failed. Please check your MySQL server.",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierManagementForm supplierForm = new SupplierManagementForm();
            supplierForm.ShowDialog();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryManagementForm inventoryForm = new InventoryManagementForm();
            inventoryForm.ShowDialog();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderManagementForm orderForm = new OrderManagementForm();
            orderForm.ShowDialog();
        }

        private void pharmacyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PharmacyManagementForm pharmacyForm = new PharmacyManagementForm();
            pharmacyForm.ShowDialog();
        }

        private void tenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenderManagementForm tenderForm = new TenderManagementForm();
            tenderForm.ShowDialog();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }
    }
}
