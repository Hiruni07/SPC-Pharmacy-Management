using System.ComponentModel;
using System.Windows.Forms;

namespace SPCPharmacyManagement
{
    partial class OrderManagementForm
    {
        private IContainer components = null;

        private Label lblTitle;
        private DataGridView dgvOrders;
        private DataGridView dgvOrderItems;
        private GroupBox gbOrderDetails;
        private Label lblTotalAmount;
        private GroupBox gbNewOrder;
        private Label lblPharmacy;
        private ComboBox cmbPharmacy;
        private Label lblDrug;
        private ComboBox cmbDrug;
        private Label lblQuantity;
        private NumericUpDown nudQuantity;
        private Button btnAddItem;
        private Button btnRemoveItem;
        private Button btnDeleteOrder;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblSearch;
        private ComboBox cmbStatusFilter;
        private Label lblStatusFilter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.gbOrderDetails = new System.Windows.Forms.GroupBox();
            this.gbNewOrder = new System.Windows.Forms.GroupBox();
            this.lblPharmacy = new System.Windows.Forms.Label();
            this.cmbPharmacy = new System.Windows.Forms.ComboBox();
            this.lblDrug = new System.Windows.Forms.Label();
            this.cmbDrug = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.gbOrderDetails.SuspendLayout();
            this.gbNewOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 Manage Orders";
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
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(70, 47);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(280, 45);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Location = new System.Drawing.Point(370, 50);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(52, 17);
            this.lblStatusFilter.TabIndex = 4;
            this.lblStatusFilter.Text = "Status:";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "All",
            "PENDING",
            "PROCESSING",
            "SHIPPED",
            "DELIVERED",
            "CANCELLED"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(430, 47);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(120, 24);
            this.cmbStatusFilter.TabIndex = 5;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(12, 80);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.Size = new System.Drawing.Size(800, 250);
            this.dgvOrders.TabIndex = 6;
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(10, 25);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.RowTemplate.Height = 24;
            this.dgvOrderItems.Size = new System.Drawing.Size(380, 180);
            this.dgvOrderItems.TabIndex = 0;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(10, 215);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(177, 20);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "Total Amount: $0.00";
            // 
            // gbOrderDetails
            // 
            this.gbOrderDetails.Controls.Add(this.dgvOrderItems);
            this.gbOrderDetails.Controls.Add(this.lblTotalAmount);
            this.gbOrderDetails.Location = new System.Drawing.Point(830, 80);
            this.gbOrderDetails.Name = "gbOrderDetails";
            this.gbOrderDetails.Size = new System.Drawing.Size(400, 250);
            this.gbOrderDetails.TabIndex = 7;
            this.gbOrderDetails.TabStop = false;
            this.gbOrderDetails.Text = "Order Items";
            // 
            // gbNewOrder
            // 
            this.gbNewOrder.Controls.Add(this.lblPharmacy);
            this.gbNewOrder.Controls.Add(this.cmbPharmacy);
            this.gbNewOrder.Controls.Add(this.lblDrug);
            this.gbNewOrder.Controls.Add(this.cmbDrug);
            this.gbNewOrder.Controls.Add(this.lblQuantity);
            this.gbNewOrder.Controls.Add(this.nudQuantity);
            this.gbNewOrder.Controls.Add(this.btnAddItem);
            this.gbNewOrder.Controls.Add(this.btnRemoveItem);
            this.gbNewOrder.Controls.Add(this.btnDeleteOrder);
            this.gbNewOrder.Location = new System.Drawing.Point(12, 350);
            this.gbNewOrder.Name = "gbNewOrder";
            this.gbNewOrder.Size = new System.Drawing.Size(1250, 178);
            this.gbNewOrder.TabIndex = 8;
            this.gbNewOrder.TabStop = false;
            // 
            // lblPharmacy
            // 
            this.lblPharmacy.AutoSize = true;
            this.lblPharmacy.Location = new System.Drawing.Point(20, 30);
            this.lblPharmacy.Name = "lblPharmacy";
            this.lblPharmacy.Size = new System.Drawing.Size(75, 17);
            this.lblPharmacy.TabIndex = 0;
            this.lblPharmacy.Text = "Pharmacy:";
            // 
            // cmbPharmacy
            // 
            this.cmbPharmacy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPharmacy.Location = new System.Drawing.Point(100, 27);
            this.cmbPharmacy.Name = "cmbPharmacy";
            this.cmbPharmacy.Size = new System.Drawing.Size(200, 24);
            this.cmbPharmacy.TabIndex = 1;
            // 
            // lblDrug
            // 
            this.lblDrug.AutoSize = true;
            this.lblDrug.Location = new System.Drawing.Point(320, 30);
            this.lblDrug.Name = "lblDrug";
            this.lblDrug.Size = new System.Drawing.Size(43, 17);
            this.lblDrug.TabIndex = 2;
            this.lblDrug.Text = "Drug:";
            // 
            // cmbDrug
            // 
            this.cmbDrug.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrug.Location = new System.Drawing.Point(370, 27);
            this.cmbDrug.Name = "cmbDrug";
            this.cmbDrug.Size = new System.Drawing.Size(200, 24);
            this.cmbDrug.TabIndex = 3;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(590, 30);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(65, 17);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Quantity:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(660, 27);
            this.nudQuantity.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(80, 22);
            this.nudQuantity.TabIndex = 5;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.LightGreen;
            this.btnAddItem.Location = new System.Drawing.Point(818, 21);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(108, 46);
            this.btnAddItem.TabIndex = 6;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackColor = System.Drawing.Color.LightCoral;
            this.btnRemoveItem.Location = new System.Drawing.Point(994, 23);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(112, 44);
            this.btnRemoveItem.TabIndex = 7;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.BackColor = System.Drawing.Color.LightCoral;
            this.btnDeleteOrder.Location = new System.Drawing.Point(268, 119);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(163, 44);
            this.btnDeleteOrder.TabIndex = 12;
            this.btnDeleteOrder.Text = "Delete Order";
            this.btnDeleteOrder.UseVisualStyleBackColor = false;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // OrderManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1250, 580);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblStatusFilter);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.gbOrderDetails);
            this.Controls.Add(this.gbNewOrder);
            this.Name = "OrderManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.gbOrderDetails.ResumeLayout(false);
            this.gbOrderDetails.PerformLayout();
            this.gbNewOrder.ResumeLayout(false);
            this.gbNewOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
