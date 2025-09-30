using System;
using System.Windows.Forms;

namespace SPCPharmacyManagement
{
    partial class TenderManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblDrugName;
        private TextBox txtDrugName;
        private Label lblQuantity;
        private NumericUpDown nudQuantity;
        private Label lblDeadline;
        private DateTimePicker dtpDeadline;
        private Button btnAddTender;
        private Button btnUpdateTender;
        private Button btnDeleteTender;
        private Button btnClear;
        private DataGridView dgvTenders;
        private Label lblProposals;
        private DataGridView dgvProposals;
        private Button btnConfirm;
        private Button btnReject;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblTitle = new Label();
            this.lblDrugName = new Label();
            this.txtDrugName = new TextBox();
            this.lblQuantity = new Label();
            this.nudQuantity = new NumericUpDown();
            this.lblDeadline = new Label();
            this.dtpDeadline = new DateTimePicker();
            this.btnAddTender = new Button();
            this.btnUpdateTender = new Button();
            this.btnDeleteTender = new Button();
            this.btnClear = new Button();
            this.dgvTenders = new DataGridView();
            this.lblProposals = new Label();
            this.dgvProposals = new DataGridView();
            this.btnConfirm = new Button();
            this.btnReject = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTenders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProposals)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Text = "📢 Tender Management";

            // lblDrugName
            this.lblDrugName.AutoSize = true;
            this.lblDrugName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDrugName.Location = new System.Drawing.Point(20, 70);
            this.lblDrugName.Text = "Drug Name:";

            // txtDrugName
            this.txtDrugName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDrugName.Location = new System.Drawing.Point(132, 68);
            this.txtDrugName.Size = new System.Drawing.Size(250, 30);

            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQuantity.Location = new System.Drawing.Point(20, 110);
            this.lblQuantity.Text = "Quantity:";

            // nudQuantity
            this.nudQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudQuantity.Location = new System.Drawing.Point(132, 108);
            this.nudQuantity.Maximum = 100000;
            this.nudQuantity.Minimum = 1;
            this.nudQuantity.Value = 1;
            this.nudQuantity.Size = new System.Drawing.Size(120, 30);

            // lblDeadline
            this.lblDeadline.AutoSize = true;
            this.lblDeadline.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDeadline.Location = new System.Drawing.Point(20, 150);
            this.lblDeadline.Text = "Deadline:";

            // dtpDeadline
            this.dtpDeadline.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDeadline.Format = DateTimePickerFormat.Short;
            this.dtpDeadline.MinDate = DateTime.Today;
            this.dtpDeadline.Location = new System.Drawing.Point(132, 148);
            this.dtpDeadline.Size = new System.Drawing.Size(150, 30);

            // btnAddTender
            this.btnAddTender.BackColor = System.Drawing.Color.LightGreen;
            this.btnAddTender.FlatStyle = FlatStyle.Flat;
            this.btnAddTender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddTender.Location = new System.Drawing.Point(420, 65);
            this.btnAddTender.Size = new System.Drawing.Size(130, 40);
            this.btnAddTender.Text = "Add Tender";
            this.btnAddTender.UseVisualStyleBackColor = false;
            this.btnAddTender.Click += new EventHandler(this.btnAddTender_Click);

            // btnUpdateTender
            this.btnUpdateTender.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnUpdateTender.FlatStyle = FlatStyle.Flat;
            this.btnUpdateTender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdateTender.Location = new System.Drawing.Point(420, 110);
            this.btnUpdateTender.Size = new System.Drawing.Size(130, 40);
            this.btnUpdateTender.Text = "Update Tender";
            this.btnUpdateTender.UseVisualStyleBackColor = false;
            this.btnUpdateTender.Click += new EventHandler(this.btnUpdateTender_Click);

            // btnDeleteTender
            this.btnDeleteTender.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteTender.FlatStyle = FlatStyle.Flat;
            this.btnDeleteTender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteTender.Location = new System.Drawing.Point(420, 155);
            this.btnDeleteTender.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteTender.Text = "Delete Tender";
            this.btnDeleteTender.UseVisualStyleBackColor = false;
            this.btnDeleteTender.Click += new EventHandler(this.btnDeleteTender_Click);

            // btnClear
            this.btnClear.BackColor = System.Drawing.Color.Khaki;
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.Location = new System.Drawing.Point(420, 200);
            this.btnClear.Size = new System.Drawing.Size(130, 40);
            this.btnClear.Text = "Clear Fields";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            // dgvTenders
            this.dgvTenders.AllowUserToAddRows = false;
            this.dgvTenders.AllowUserToDeleteRows = false;
            this.dgvTenders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTenders.Location = new System.Drawing.Point(20, 250);
            this.dgvTenders.ReadOnly = true;
            this.dgvTenders.Size = new System.Drawing.Size(750, 230);
            this.dgvTenders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTenders.CellClick += new DataGridViewCellEventHandler(this.dgvTenders_CellClick);

            // lblProposals
            this.lblProposals.AutoSize = true;
            this.lblProposals.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProposals.Location = new System.Drawing.Point(20, 500);
            this.lblProposals.Text = "📨 Submitted Proposals";

            // dgvProposals
            this.dgvProposals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProposals.Location = new System.Drawing.Point(20, 530);
            this.dgvProposals.ReadOnly = true;
            this.dgvProposals.Size = new System.Drawing.Size(750, 180);
            this.dgvProposals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // btnConfirm
            this.btnConfirm.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfirm.FlatStyle = FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Location = new System.Drawing.Point(600, 720);
            this.btnConfirm.Size = new System.Drawing.Size(80, 40);
            this.btnConfirm.Text = "✔ Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new EventHandler(this.btnConfirm_Click);

            // btnReject
            this.btnReject.BackColor = System.Drawing.Color.Salmon;
            this.btnReject.FlatStyle = FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReject.Location = new System.Drawing.Point(690, 720);
            this.btnReject.Size = new System.Drawing.Size(80, 40);
            this.btnReject.Text = "✘ Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new EventHandler(this.btnReject_Click);

            // TenderManagementForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 780);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDrugName);
            this.Controls.Add(this.txtDrugName);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.lblDeadline);
            this.Controls.Add(this.dtpDeadline);
            this.Controls.Add(this.btnAddTender);
            this.Controls.Add(this.btnUpdateTender);
            this.Controls.Add(this.btnDeleteTender);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvTenders);
            this.Controls.Add(this.lblProposals);
            this.Controls.Add(this.dgvProposals);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnReject);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TenderManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Tender Management";
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTenders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProposals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
