<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarehouseDashboard.aspx.cs" Inherits="SPCWebsite.WarehouseDashboard" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Warehouse Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Bootstrap & Font Awesome -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet" />

    <style>
        :root {
            --blue: #004080;
            --ash: #f5f5f5;
            --dark-yellow: #ffc107;
            --white: #ffffff;
            --black: #1c1c1c;
        }

        body {
            background-color: var(--ash);
            font-family: 'Segoe UI', sans-serif;
            color: var(--black);
        }

        .dashboard-header {
            background: linear-gradient(to right, var(--blue), var(--dark-yellow));
            color: var(--white);
            padding: 50px 0;
            text-align: center;
            border-radius: 0 0 30px 30px;
            box-shadow: 0 5px 15px rgba(0,0,0,0.2);
        }

        .dashboard-header h2 {
            font-weight: bold;
            letter-spacing: 1px;
        }

        .form-section {
            background-color: var(--white);
            padding: 30px;
            border-radius: 16px;
            box-shadow: 0 4px 15px rgba(0,0,0,0.08);
            margin-bottom: 40px;
        }

        .form-label {
            font-weight: 600;
            color: var(--blue);
        }

        .form-control {
            border-radius: 10px;
            padding: 10px;
        }

        .btn-primary {
            background-color: var(--blue);
            border: none;
            font-weight: 600;
        }

        .btn-primary:hover {
            background-color: #002855;
        }

        .btn-success {
            background-color: var(--dark-yellow);
            border: none;
            color: var(--black);
            font-weight: 600;
        }

        .btn-success:hover {
            background-color: #e0a800;
            color: var(--black);
        }

        .footer {
            background-color: var(--blue);
            color: var(--white);
            padding: 20px 0;
            text-align: center;
            margin-top: 60px;
            border-radius: 10px 10px 0 0;
        }

        .gridview-style th {
            background-color: var(--blue);
            color: var(--white);
            text-align: center;
        }

        .gridview-style td {
            text-align: center;
        }

        .section-title {
            color: var(--blue);
            font-weight: 700;
            margin-bottom: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <!-- Dashboard Header -->
        <div class="dashboard-header">
            <h2><i class="fas fa-warehouse me-2"></i>Warehouse Dashboard</h2>
            <p class="lead mb-0">Manage drug stock and view inventory</p>
        </div>

        <!-- Page Content -->
        <div class="container mt-5">
            
            <!-- Update Drug Stock -->
            <div class="form-section">
                <h4 class="section-title"><i class="fas fa-edit me-2"></i>Update Drug Stock</h4>

                <div class="mb-3">
                    <label class="form-label">Drug Name</label>
                    <asp:TextBox ID="txtDrugName" runat="server" CssClass="form-control" placeholder="Enter drug name"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label class="form-label">Quantity</label>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number" placeholder="Enter quantity"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label class="form-label">Unit Price (Rs)</label>
                    <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="form-control" TextMode="Number" placeholder="Enter price per unit"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label class="form-label">Update Reason</label>
                    <asp:TextBox ID="txtUpdateReason" runat="server" CssClass="form-control" placeholder="Why is this update needed?"></asp:TextBox>
                </div>

                <asp:Button ID="btnUpdate" runat="server" Text="Update Stock" CssClass="btn btn-success px-4 py-2" OnClick="btnUpdate_Click" />
                <asp:Label ID="lblStatus" runat="server" CssClass="fw-bold text-success d-block mt-3"></asp:Label>
            </div>

            <!-- Search Drug Inventory -->
            <div class="form-section">
                <h4 class="section-title"><i class="fas fa-search me-2"></i>Search Drug Inventory</h4>

                <div class="row mb-4">
                    <div class="col-md-10">
                        <asp:TextBox ID="txtSearchDrug" runat="server" CssClass="form-control" placeholder="Search by drug or generic name"></asp:TextBox>
                    </div>
                    <div class="col-md-2 d-grid">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                    </div>
                </div>

                <div class="gridview-style">
                    <asp:GridView ID="gvDrugs" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="drug_id" HeaderText="ID" />
                            <asp:BoundField DataField="drug_name" HeaderText="Name" />
                            <asp:BoundField DataField="unit_price" HeaderText="Unit Price (Rs)" DataFormatString="{0:F2}" />
                            <asp:BoundField DataField="quantity_in_stock" HeaderText="Stock" />
                            <asp:BoundField DataField="expiry_date" HeaderText="Expiry Date" DataFormatString="{0:yyyy-MM-dd}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
