<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PharmacyDashboard.aspx.cs" Inherits="SPCWebsite.PharmacyDashboard" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Pharmacy Dashboard - SPC</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        :root {
            --blue: #0056b3;
            --ash: #f0f0f0;
            --dark-yellow: #ffc107;
            --white: #ffffff;
            --black: #212529;
        }

        body {
            background-color: #f0f0f0;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #212529;
        }

        .navbar {
            background-color: #0056b3;
        }

        .navbar-brand,
        .nav-link {
            color: #ffffff !important;
            font-weight: bold;
        }

        .dashboard-section {
            background-color: #ffffff;
            padding: 40px 30px;
            margin-top: 40px;
            border-radius: 16px;
            box-shadow: 0 8px 25px rgba(0, 0, 0, 0.1);
        }

        .dashboard-section h3 {
            color: #0056b3;
            font-weight: 700;
        }

        .form-control {
            border-radius: 10px;
            padding: 10px 15px;
            border: 1px solid #ced4da;
            transition: all 0.3s;
        }

        .form-control:focus {
            border-color: #0056b3;
            box-shadow: 0 0 10px rgba(0, 86, 179, 0.2);
        }

        .btn-primary {
            background-color: #0056b3;
            border: none;
            font-weight: bold;
        }

        .btn-primary:hover {
            background-color: #003d80;
        }

        .btn-success {
            background-color: #ffc107;
            border: none;
            color: #212529;
            font-weight: bold;
        }

        .btn-success:hover {
            background-color: #e0a800;
            color: #212529;
        }

        .table {
            border-radius: 10px;
            overflow: hidden;
        }

        .footer {
            background-color: #0056b3;
            color: #ffffff;
            text-align: center;
            padding: 20px;
            margin-top: 60px;
            border-radius: 10px 10px 0 0;
        }

        .fw-bold {
            color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg shadow-sm">
            <div class="container">
                <a class="navbar-brand" href="#">SPC Pharmacy</a>
            </div>
        </nav>

        <!-- Dashboard Content -->
        <div class="container dashboard-section">
            <h3 class="mb-4">🔍 Search Drugs</h3>

            <div class="row mb-4">
                <div class="col-md-10">
                    <asp:TextBox ID="txtSearchDrug" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary w-100" OnClick="btnSearch_Click" />
                </div>
            </div>

            <asp:GridView ID="gvDrugs" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped text-center">
                <Columns>
                    <asp:BoundField DataField="drug_id" HeaderText="Drug ID" />
                    <asp:BoundField DataField="drug_name" HeaderText="Drug Name" />
                    <asp:BoundField DataField="generic_name" HeaderText="Generic Name" />
                    <asp:BoundField DataField="quantity_in_stock" HeaderText="Available" />
                    <asp:BoundField DataField="unit_price" HeaderText="Price (Rs)" DataFormatString="{0:N2}" />
                </Columns>
            </asp:GridView>

            <hr class="my-4" />
            <h3 class="mb-3">📝 Place Order</h3>

            <!-- Drug ID -->
            <div class="mb-3 row">
                <asp:Label AssociatedControlID="txtDrugId" CssClass="col-sm-2 col-form-label fw-bold" runat="server" Text="Drug ID"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtDrugId" runat="server" CssClass="form-control" />
                </div>
            </div>

            <!-- Quantity -->
            <div class="mb-3 row">
                <asp:Label AssociatedControlID="txtOrderQty" CssClass="col-sm-2 col-form-label fw-bold" runat="server" Text="Quantity"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtOrderQty" runat="server" CssClass="form-control" />
                </div>
            </div>

            <!-- Notes -->
            <div class="mb-3 row">
                <asp:Label AssociatedControlID="txtOrderNote" CssClass="col-sm-2 col-form-label fw-bold" runat="server" Text="Order Notes"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtOrderNote" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>
            </div>

            <!-- Pharmacy Dropdown -->
            <div class="mb-3 row">
                <asp:Label AssociatedControlID="ddlPharmacies" CssClass="col-sm-2 col-form-label fw-bold" runat="server" Text="Pharmacy"></asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlPharmacies" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" CssClass="btn btn-success px-4 py-2" OnClick="btnPlaceOrder_Click" />
            <asp:Label ID="lblStatus" runat="server" CssClass="mt-4 d-block text-center fw-bold"></asp:Label>
        </div>

     
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
