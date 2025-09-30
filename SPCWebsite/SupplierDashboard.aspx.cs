using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace SPCWebsite
{
    public partial class SupplierDashboard : System.Web.UI.Page
    {
        protected int SelectedTenderId
        {
            get { return ViewState["SelectedTenderId"] != null ? (int)ViewState["SelectedTenderId"] : 0; }
            set { ViewState["SelectedTenderId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTenders();
                lblMessage.Text = "";
                pnlProposal.Visible = false;
            }
        }

        private void LoadTenders()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"
                    SELECT t.tender_id, t.drug_name, t.quantity, t.deadline,
                           COALESCE(tp.status, 'None') AS proposal_status
                    FROM tenders t
                    LEFT JOIN tender_proposals tp ON t.tender_id = tp.tender_id
                    ORDER BY t.tender_id DESC", conn);

                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                gvTenders.DataSource = dt;
                gvTenders.DataBind();
            }
        }

        protected void gvTenders_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTenderId = Convert.ToInt32(gvTenders.SelectedDataKey.Value);
            GridViewRow row = gvTenders.SelectedRow;
            lblDrugName.Text = row.Cells[1].Text;
            pnlProposal.Visible = true;
            lblMessage.Text = "";

            // Clear previous input
            txtPricePerUnit.Text = "";
            txtDeliveryTime.Text = "";
            txtSupplierName.Text = "";
            txtSubmittedBy.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (SelectedTenderId == 0)
            {
                lblMessage.Text = "⚠️ Please select a tender.";
                lblMessage.CssClass = "d-block mb-3 text-danger fw-bold";
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtPricePerUnit.Text.Trim(), out price))
            {
                lblMessage.Text = "Invalid price per unit.";
                lblMessage.CssClass = "text-danger";
                return;
            }

            int deliveryDays;
            if (!int.TryParse(txtDeliveryTime.Text.Trim(), out deliveryDays))
            {
                lblMessage.Text = "Invalid delivery time.";
                lblMessage.CssClass = "text-danger";
                return;
            }


            string supplierName = txtSupplierName.Text.Trim();
            string submittedBy = txtSubmittedBy.Text.Trim();

            if (string.IsNullOrEmpty(supplierName) || string.IsNullOrEmpty(submittedBy))
            {
                lblMessage.Text = "❌ Supplier Name and Submitted By are required.";
                lblMessage.CssClass = "d-block mb-3 text-danger fw-bold";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO tender_proposals 
                            (tender_id, supplier_name, price_per_unit, delivery_time_days, submitted_by, submitted_at, status) 
                        VALUES 
                            (@tenderId, @supplierName, @price, @days, @submittedBy, NOW(), 'Pending')
                        ON DUPLICATE KEY UPDATE
                            supplier_name = @supplierName,
                            price_per_unit = @price,
                            delivery_time_days = @days,
                            submitted_by = @submittedBy,
                            submitted_at = NOW(),
                            status = 'Pending'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenderId", SelectedTenderId);
                        cmd.Parameters.AddWithValue("@supplierName", supplierName);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@days", deliveryDays);
                        cmd.Parameters.AddWithValue("@submittedBy", submittedBy);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            lblMessage.Text = "✅ Proposal submitted successfully!";
                            lblMessage.CssClass = "d-block mb-3 text-success fw-bold";
                            pnlProposal.Visible = false;
                            LoadTenders();
                        }
                        else
                        {
                            lblMessage.Text = "❌ Failed to submit proposal.";
                            lblMessage.CssClass = "d-block mb-3 text-danger fw-bold";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "❌ Error: " + ex.Message;
                lblMessage.CssClass = "d-block mb-3 text-danger fw-bold";
            }
        }
    }
}
