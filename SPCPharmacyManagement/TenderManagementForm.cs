using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SPCPharmacyManagement
{
    public partial class TenderManagementForm : Form
    {
        private int selectedTenderId = 0;
        private string connectionString = "server=localhost;user id=root;password=;database=spc_pharmacy_db";

        public TenderManagementForm()
        {
            InitializeComponent();
            LoadTenders();
        }

        private void LoadTenders()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(
                    "SELECT tender_id, drug_name, quantity, deadline FROM tenders", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTenders.DataSource = dt;
            }
        }

        private void LoadProposalsForTender(int tenderId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(
                    @"SELECT 
                        tender_proposal_id,
                        supplier_name,
                        price_per_unit,
                        delivery_time_days,
                        submitted_by,
                        submitted_at,
                        status 
                      FROM tender_proposals 
                      WHERE tender_id = @tenderId", conn);
                adapter.SelectCommand.Parameters.AddWithValue("@tenderId", tenderId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvProposals.DataSource = dt;
            }
        }

        private void btnAddTender_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO tenders (drug_name, quantity, deadline) VALUES (@drug, @qty, @deadline)", conn);
                cmd.Parameters.AddWithValue("@drug", txtDrugName.Text);
                cmd.Parameters.AddWithValue("@qty", nudQuantity.Value);
                cmd.Parameters.AddWithValue("@deadline", dtpDeadline.Value);
                cmd.ExecuteNonQuery();
                LoadTenders();
                ClearFields();
            }
        }

        private void btnUpdateTender_Click(object sender, EventArgs e)
        {
            if (selectedTenderId == 0)
            {
                MessageBox.Show("Please select a tender to update.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE tenders SET drug_name=@drug, quantity=@qty, deadline=@deadline WHERE tender_id=@id", conn);
                cmd.Parameters.AddWithValue("@drug", txtDrugName.Text);
                cmd.Parameters.AddWithValue("@qty", nudQuantity.Value);
                cmd.Parameters.AddWithValue("@deadline", dtpDeadline.Value);
                cmd.Parameters.AddWithValue("@id", selectedTenderId);
                cmd.ExecuteNonQuery();
                LoadTenders();
                ClearFields();
            }
        }

        private void btnDeleteTender_Click(object sender, EventArgs e)
        {
            if (selectedTenderId == 0)
            {
                MessageBox.Show("Please select a tender to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this tender?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM tenders WHERE tender_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", selectedTenderId);
                    cmd.ExecuteNonQuery();
                    LoadTenders();
                    dgvProposals.DataSource = null;
                    ClearFields();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtDrugName.Text = "";
            nudQuantity.Value = 1;
            dtpDeadline.Value = DateTime.Today;
            selectedTenderId = 0;
            dgvProposals.DataSource = null;
        }

        private void dgvTenders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTenders.Rows[e.RowIndex];
                selectedTenderId = Convert.ToInt32(row.Cells["tender_id"].Value);
                txtDrugName.Text = row.Cells["drug_name"].Value.ToString();
                nudQuantity.Value = Convert.ToDecimal(row.Cells["quantity"].Value);
                dtpDeadline.Value = Convert.ToDateTime(row.Cells["deadline"].Value);

                LoadProposalsForTender(selectedTenderId);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvProposals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a proposal to confirm.");
                return;
            }

            int proposalId = Convert.ToInt32(dgvProposals.SelectedRows[0].Cells["tender_proposal_id"].Value);
            UpdateProposalStatus(proposalId, "Confirmed");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvProposals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a proposal to reject.");
                return;
            }

            int proposalId = Convert.ToInt32(dgvProposals.SelectedRows[0].Cells["tender_proposal_id"].Value);
            UpdateProposalStatus(proposalId, "Rejected");
        }

        private void UpdateProposalStatus(int proposalId, string status)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE tender_proposals SET status=@status WHERE tender_proposal_id=@id", conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", proposalId);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"Proposal has been {status.ToLower()}.");
                LoadProposalsForTender(selectedTenderId);
            }
        }
    }
}
