using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SPCPharmacyManagement
{
    partial class InventoryManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvInventory;
        private GroupBox gbDrugDetails;
        private GroupBox gbStockUpdate;
        private TextBox txtDrugName;
        private TextBox txtGenericName;
        private TextBox txtManufacturer;
        private TextBox txtBatchNumber;
        private DateTimePicker dtpExpiryDate;
        private NumericUpDown nudUnitPrice;
        private NumericUpDown nudQuantityInStock;
        private TextBox txtDescription;
        private ComboBox cmbUpdateType;
        private NumericUpDown nudUpdateQuantity;
        private TextBox txtUpdateReason;
        private TextBox txtUpdatedBy;
        private Button btnAddDrug;
        private Button btnUpdateDrug;
        private Button btnDeleteDrug;
        private Button btnUpdateStock;
        private Button btnClearDrug;
        private Button btnSearch;
        private TextBox txtSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.gbDrugDetails = new System.Windows.Forms.GroupBox();
            this.lblDrugName = new System.Windows.Forms.Label();
            this.txtDrugName = new System.Windows.Forms.TextBox();
            this.lblGenericName = new System.Windows.Forms.Label();
            this.txtGenericName = new System.Windows.Forms.TextBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.nudUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nudQuantityInStock = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAddDrug = new System.Windows.Forms.Button();
            this.btnUpdateDrug = new System.Windows.Forms.Button();
            this.btnDeleteDrug = new System.Windows.Forms.Button();
            this.btnClearDrug = new System.Windows.Forms.Button();
            this.gbStockUpdate = new System.Windows.Forms.GroupBox();
            this.lblUpdateType = new System.Windows.Forms.Label();
            this.cmbUpdateType = new System.Windows.Forms.ComboBox();
            this.lblUpdateQuantity = new System.Windows.Forms.Label();
            this.nudUpdateQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblUpdateReason = new System.Windows.Forms.Label();
            this.txtUpdateReason = new System.Windows.Forms.TextBox();
            this.lblUpdatedBy = new System.Windows.Forms.Label();
            this.txtUpdatedBy = new System.Windows.Forms.TextBox();
            this.btnUpdateStock = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.gbDrugDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityInStock)).BeginInit();
            this.gbStockUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(267, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 Manage Inventory";
            // 
            // dgvInventory
            // 
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(12, 80);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(1000, 300);
            this.dgvInventory.TabIndex = 4;
            this.dgvInventory.SelectionChanged += new System.EventHandler(this.dgvInventory_SelectionChanged);
            // 
            // gbDrugDetails
            // 
            this.gbDrugDetails.Controls.Add(this.lblDrugName);
            this.gbDrugDetails.Controls.Add(this.txtDrugName);
            this.gbDrugDetails.Controls.Add(this.lblGenericName);
            this.gbDrugDetails.Controls.Add(this.txtGenericName);
            this.gbDrugDetails.Controls.Add(this.lblManufacturer);
            this.gbDrugDetails.Controls.Add(this.txtManufacturer);
            this.gbDrugDetails.Controls.Add(this.lblBatchNumber);
            this.gbDrugDetails.Controls.Add(this.txtBatchNumber);
            this.gbDrugDetails.Controls.Add(this.lblExpiryDate);
            this.gbDrugDetails.Controls.Add(this.dtpExpiryDate);
            this.gbDrugDetails.Controls.Add(this.lblUnitPrice);
            this.gbDrugDetails.Controls.Add(this.nudUnitPrice);
            this.gbDrugDetails.Controls.Add(this.lblQuantity);
            this.gbDrugDetails.Controls.Add(this.nudQuantityInStock);
            this.gbDrugDetails.Controls.Add(this.lblDescription);
            this.gbDrugDetails.Controls.Add(this.txtDescription);
            this.gbDrugDetails.Controls.Add(this.btnAddDrug);
            this.gbDrugDetails.Controls.Add(this.btnUpdateDrug);
            this.gbDrugDetails.Controls.Add(this.btnDeleteDrug);
            this.gbDrugDetails.Controls.Add(this.btnClearDrug);
            this.gbDrugDetails.Location = new System.Drawing.Point(12, 390);
            this.gbDrugDetails.Name = "gbDrugDetails";
            this.gbDrugDetails.Size = new System.Drawing.Size(600, 280);
            this.gbDrugDetails.TabIndex = 5;
            this.gbDrugDetails.TabStop = false;
            this.gbDrugDetails.Text = "Drug Details";
            // 
            // lblDrugName
            // 
            this.lblDrugName.AutoSize = true;
            this.lblDrugName.Location = new System.Drawing.Point(20, 30);
            this.lblDrugName.Name = "lblDrugName";
            this.lblDrugName.Size = new System.Drawing.Size(84, 17);
            this.lblDrugName.TabIndex = 0;
            this.lblDrugName.Text = "Drug Name:";
            // 
            // txtDrugName
            // 
            this.txtDrugName.Location = new System.Drawing.Point(120, 27);
            this.txtDrugName.Name = "txtDrugName";
            this.txtDrugName.Size = new System.Drawing.Size(180, 22);
            this.txtDrugName.TabIndex = 1;
            // 
            // lblGenericName
            // 
            this.lblGenericName.AutoSize = true;
            this.lblGenericName.Location = new System.Drawing.Point(320, 30);
            this.lblGenericName.Name = "lblGenericName";
            this.lblGenericName.Size = new System.Drawing.Size(103, 17);
            this.lblGenericName.TabIndex = 2;
            this.lblGenericName.Text = "Generic Name:";
            // 
            // txtGenericName
            // 
            this.txtGenericName.Location = new System.Drawing.Point(430, 27);
            this.txtGenericName.Name = "txtGenericName";
            this.txtGenericName.Size = new System.Drawing.Size(150, 22);
            this.txtGenericName.TabIndex = 3;
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(20, 65);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(96, 17);
            this.lblManufacturer.TabIndex = 4;
            this.lblManufacturer.Text = "Manufacturer:";
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(120, 62);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(180, 22);
            this.txtManufacturer.TabIndex = 5;
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Location = new System.Drawing.Point(320, 65);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(102, 17);
            this.lblBatchNumber.TabIndex = 6;
            this.lblBatchNumber.Text = "Batch Number:";
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Location = new System.Drawing.Point(430, 62);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(150, 22);
            this.txtBatchNumber.TabIndex = 7;
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(20, 100);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(84, 17);
            this.lblExpiryDate.TabIndex = 8;
            this.lblExpiryDate.Text = "Expiry Date:";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Location = new System.Drawing.Point(120, 97);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(180, 22);
            this.dtpExpiryDate.TabIndex = 9;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(320, 100);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(73, 17);
            this.lblUnitPrice.TabIndex = 10;
            this.lblUnitPrice.Text = "Unit Price:";
            // 
            // nudUnitPrice
            // 
            this.nudUnitPrice.DecimalPlaces = 2;
            this.nudUnitPrice.Location = new System.Drawing.Point(430, 97);
            this.nudUnitPrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudUnitPrice.Name = "nudUnitPrice";
            this.nudUnitPrice.Size = new System.Drawing.Size(150, 22);
            this.nudUnitPrice.TabIndex = 11;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(20, 135);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(65, 17);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "Quantity:";
            // 
            // nudQuantityInStock
            // 
            this.nudQuantityInStock.Location = new System.Drawing.Point(120, 132);
            this.nudQuantityInStock.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudQuantityInStock.Name = "nudQuantityInStock";
            this.nudQuantityInStock.Size = new System.Drawing.Size(180, 22);
            this.nudQuantityInStock.TabIndex = 13;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 170);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 17);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(120, 167);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(460, 60);
            this.txtDescription.TabIndex = 15;
            // 
            // btnAddDrug
            // 
            this.btnAddDrug.BackColor = System.Drawing.Color.LightGreen;
            this.btnAddDrug.Location = new System.Drawing.Point(120, 240);
            this.btnAddDrug.Name = "btnAddDrug";
            this.btnAddDrug.Size = new System.Drawing.Size(75, 30);
            this.btnAddDrug.TabIndex = 16;
            this.btnAddDrug.Text = "Add";
            this.btnAddDrug.UseVisualStyleBackColor = false;
            this.btnAddDrug.Click += new System.EventHandler(this.btnAddDrug_Click);
            // 
            // btnUpdateDrug
            // 
            this.btnUpdateDrug.BackColor = System.Drawing.Color.LightBlue;
            this.btnUpdateDrug.Location = new System.Drawing.Point(210, 240);
            this.btnUpdateDrug.Name = "btnUpdateDrug";
            this.btnUpdateDrug.Size = new System.Drawing.Size(75, 30);
            this.btnUpdateDrug.TabIndex = 17;
            this.btnUpdateDrug.Text = "Update";
            this.btnUpdateDrug.UseVisualStyleBackColor = false;
            this.btnUpdateDrug.Click += new System.EventHandler(this.btnUpdateDrug_Click);
            // 
            // btnDeleteDrug
            // 
            this.btnDeleteDrug.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteDrug.Location = new System.Drawing.Point(300, 240);
            this.btnDeleteDrug.Name = "btnDeleteDrug";
            this.btnDeleteDrug.Size = new System.Drawing.Size(75, 30);
            this.btnDeleteDrug.TabIndex = 18;
            this.btnDeleteDrug.Text = "Delete";
            this.btnDeleteDrug.UseVisualStyleBackColor = false;
            this.btnDeleteDrug.Click += new System.EventHandler(this.btnDeleteDrug_Click);
            // 
            // btnClearDrug
            // 
            this.btnClearDrug.BackColor = System.Drawing.Color.LightYellow;
            this.btnClearDrug.Location = new System.Drawing.Point(390, 240);
            this.btnClearDrug.Name = "btnClearDrug";
            this.btnClearDrug.Size = new System.Drawing.Size(75, 30);
            this.btnClearDrug.TabIndex = 19;
            this.btnClearDrug.Text = "Clear";
            this.btnClearDrug.UseVisualStyleBackColor = false;
            this.btnClearDrug.Click += new System.EventHandler(this.btnClearDrug_Click);
            // 
            // gbStockUpdate
            // 
            this.gbStockUpdate.Controls.Add(this.lblUpdateType);
            this.gbStockUpdate.Controls.Add(this.cmbUpdateType);
            this.gbStockUpdate.Controls.Add(this.lblUpdateQuantity);
            this.gbStockUpdate.Controls.Add(this.nudUpdateQuantity);
            this.gbStockUpdate.Controls.Add(this.lblUpdateReason);
            this.gbStockUpdate.Controls.Add(this.txtUpdateReason);
            this.gbStockUpdate.Controls.Add(this.lblUpdatedBy);
            this.gbStockUpdate.Controls.Add(this.txtUpdatedBy);
            this.gbStockUpdate.Controls.Add(this.btnUpdateStock);
            this.gbStockUpdate.Location = new System.Drawing.Point(630, 390);
            this.gbStockUpdate.Name = "gbStockUpdate";
            this.gbStockUpdate.Size = new System.Drawing.Size(380, 280);
            this.gbStockUpdate.TabIndex = 6;
            this.gbStockUpdate.TabStop = false;
            this.gbStockUpdate.Text = "Stock Update";
            // 
            // lblUpdateType
            // 
            this.lblUpdateType.AutoSize = true;
            this.lblUpdateType.Location = new System.Drawing.Point(20, 30);
            this.lblUpdateType.Name = "lblUpdateType";
            this.lblUpdateType.Size = new System.Drawing.Size(94, 17);
            this.lblUpdateType.TabIndex = 0;
            this.lblUpdateType.Text = "Update Type:";
            // 
            // cmbUpdateType
            // 
            this.cmbUpdateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpdateType.Items.AddRange(new object[] {
            "ADD",
            "REMOVE"});
            this.cmbUpdateType.Location = new System.Drawing.Point(120, 27);
            this.cmbUpdateType.Name = "cmbUpdateType";
            this.cmbUpdateType.Size = new System.Drawing.Size(120, 24);
            this.cmbUpdateType.TabIndex = 1;
            // 
            // lblUpdateQuantity
            // 
            this.lblUpdateQuantity.AutoSize = true;
            this.lblUpdateQuantity.Location = new System.Drawing.Point(20, 65);
            this.lblUpdateQuantity.Name = "lblUpdateQuantity";
            this.lblUpdateQuantity.Size = new System.Drawing.Size(65, 17);
            this.lblUpdateQuantity.TabIndex = 2;
            this.lblUpdateQuantity.Text = "Quantity:";
            // 
            // nudUpdateQuantity
            // 
            this.nudUpdateQuantity.Location = new System.Drawing.Point(120, 62);
            this.nudUpdateQuantity.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudUpdateQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudUpdateQuantity.Name = "nudUpdateQuantity";
            this.nudUpdateQuantity.Size = new System.Drawing.Size(120, 22);
            this.nudUpdateQuantity.TabIndex = 3;
            this.nudUpdateQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblUpdateReason
            // 
            this.lblUpdateReason.AutoSize = true;
            this.lblUpdateReason.Location = new System.Drawing.Point(20, 100);
            this.lblUpdateReason.Name = "lblUpdateReason";
            this.lblUpdateReason.Size = new System.Drawing.Size(61, 17);
            this.lblUpdateReason.TabIndex = 4;
            this.lblUpdateReason.Text = "Reason:";
            // 
            // txtUpdateReason
            // 
            this.txtUpdateReason.Location = new System.Drawing.Point(120, 97);
            this.txtUpdateReason.Multiline = true;
            this.txtUpdateReason.Name = "txtUpdateReason";
            this.txtUpdateReason.Size = new System.Drawing.Size(240, 60);
            this.txtUpdateReason.TabIndex = 5;
            // 
            // lblUpdatedBy
            // 
            this.lblUpdatedBy.AutoSize = true;
            this.lblUpdatedBy.Location = new System.Drawing.Point(20, 175);
            this.lblUpdatedBy.Name = "lblUpdatedBy";
            this.lblUpdatedBy.Size = new System.Drawing.Size(86, 17);
            this.lblUpdatedBy.TabIndex = 6;
            this.lblUpdatedBy.Text = "Updated By:";
            // 
            // txtUpdatedBy
            // 
            this.txtUpdatedBy.Location = new System.Drawing.Point(120, 172);
            this.txtUpdatedBy.Name = "txtUpdatedBy";
            this.txtUpdatedBy.Size = new System.Drawing.Size(240, 22);
            this.txtUpdatedBy.TabIndex = 7;
            // 
            // btnUpdateStock
            // 
            this.btnUpdateStock.BackColor = System.Drawing.Color.Orange;
            this.btnUpdateStock.Location = new System.Drawing.Point(120, 210);
            this.btnUpdateStock.Name = "btnUpdateStock";
            this.btnUpdateStock.Size = new System.Drawing.Size(120, 35);
            this.btnUpdateStock.TabIndex = 8;
            this.btnUpdateStock.Text = "Update Stock";
            this.btnUpdateStock.UseVisualStyleBackColor = false;
            this.btnUpdateStock.Click += new System.EventHandler(this.btnUpdateStock_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(300, 45);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(80, 47);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 50);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(57, 17);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search:";
            // 
            // InventoryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1030, 700);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.gbDrugDetails);
            this.Controls.Add(this.gbStockUpdate);
            this.Name = "InventoryManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.gbDrugDetails.ResumeLayout(false);
            this.gbDrugDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityInStock)).EndInit();
            this.gbStockUpdate.ResumeLayout(false);
            this.gbStockUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdateQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblDrugName;
        private Label lblGenericName;
        private Label lblManufacturer;
        private Label lblBatchNumber;
        private Label lblExpiryDate;
        private Label lblUnitPrice;
        private Label lblQuantity;
        private Label lblDescription;
        private Label lblUpdateType;
        private Label lblUpdateQuantity;
        private Label lblUpdateReason;
        private Label lblUpdatedBy;
        private Label lblSearch;
    }
}
