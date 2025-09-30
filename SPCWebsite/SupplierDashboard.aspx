<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierDashboard.aspx.cs" Inherits="SPCWebsite.SupplierDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Supplier Dashboard</title>

    <!-- Bootstrap 5 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Font Awesome -->
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
            padding: 40px 0;
            text-align: center;
            border-radius: 0 0 30px 30px;
            box-shadow: 0 5px 15px rgba(0,0,0,0.2);
        }

        .dashboard-header h2 {
            font-weight: bold;
            margin: 0;
        }

        .container {
            background-color: var(--white);
            border-radius: 12px;
            padding: 30px;
            margin-top: 40px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.08);
        }

        h4 {
            color: var(--blue);
        }

        .form-control {
            background-color: var(--ash);
            color: var(--black);
            border: 1px solid var(--blue);
        }

        .form-control:focus {
            border-color: var(--dark-yellow);
            box-shadow: 0 0 10px var(--dark-yellow);
            background-color: #ffffff;
        }

        .btn-success {
            background-color: var(--dark-yellow);
            border: none;
            color: var(--black);
            font-weight: bold;
        }

        .btn-success:hover {
            background-color: #e0a800;
            color: black;
        }

        .table {
            color: var(--black);
        }

        .table th {
            background-color: var(--blue);
            color: var(--white);
            text-align: center;
        }

        .table td {
            text-align: center;
        }

        .footer {
            background-color: var(--blue);
            color: var(--white);
            text-align: center;
            padding: 20px;
            margin-top: 60px;
            border-radius: 20px 20px 0 0;
        }

        .status-pending { color: orange; font-weight: bold; }
        .status-confirmed { color: green; font-weight: bold; }
        .status-rejected { color: red; font-weight: bold; }
        .status-none { color: gray; font-weight: bold; }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <!-- Header -->
        <div class="dashboard-header">
            <h2><i class="fas fa-industry me-2"></i>Supplier Dashboard</h2>
        </div>

        <!-- Main Container -->
        <div class="container">
            <h4 class="mb-4"><i class="fas fa-file-signature me-2"></i>Available Tenders</h4>

            <asp:Label ID="lblMessage" runat="server" CssClass="d-block mb-3 text-danger fw-bold"></asp:Label>

            <asp:GridView ID="gvTenders" runat="server" AutoGenerateColumns="False"
                CssClass="table table-bordered table-hover text-center"
                OnSelectedIndexChanged="gvTenders_SelectedIndexChanged"
                DataKeyNames="tender_id">
                <Columns>
                    <asp:BoundField DataField="tender_id" HeaderText="Tender ID" />
                    <asp:BoundField DataField="drug_name" HeaderText="Drug Name" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="deadline" HeaderText="Deadline" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="proposal_status" HeaderText="Status" />
                    <asp:CommandField ShowSelectButton="True" SelectText="Submit Proposal" ButtonType="Button" />
                </Columns>
            </asp:GridView>

            <asp:Panel ID="pnlProposal" runat="server" Visible="false" CssClass="mt-4">
                <h4 class="mb-3">
                    <i class="fas fa-plus-circle me-2"></i>Submit Proposal for: 
                    <asp:Label ID="lblDrugName" runat="server" CssClass="text-warning fw-bold"></asp:Label>
                </h4>

                <div class="mb-3">
                    <label for="txtSupplierName" class="form-label">Supplier Name:</label>
                    <asp:TextBox ID="txtSupplierName" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtSubmittedBy" class="form-label">Submitted By:</label>
                    <asp:TextBox ID="txtSubmittedBy" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtPricePerUnit" class="form-label">Price per Unit (LKR):</label>
                    <asp:TextBox ID="txtPricePerUnit" runat="server" CssClass="form-control" TextMode="Number" />
                </div>

                <div class="mb-3">
                    <label for="txtDeliveryTime" class="form-label">Delivery Time (in days):</label>
                    <asp:TextBox ID="txtDeliveryTime" runat="server" CssClass="form-control" TextMode="Number" />
                </div>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit Proposal" CssClass="btn btn-success px-4 py-2" OnClick="btnSubmit_Click" />

                <asp:Label ID="lblMessage2" runat="server" CssClass="d-block mt-3 text-success fw-bold"></asp:Label>
            </asp:Panel>
        </div>

        <!-- Bootstrap JS -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

    </form>
</body>
</html>
