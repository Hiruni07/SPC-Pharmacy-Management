<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManufactureDashboard.aspx.cs" Inherits="SPCWebsite.ManufactureDashboard" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Manufacture Dashboard - SPC</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        :root {
            --main-blue: #007bff;
            --dark-yellow: #ffc107;
            --ash: #f0f0f0;
            --dark-black: #212529;
            --white: #ffffff;
        }

        body {
            background-color: var(--ash);
            color: var(--dark-black);
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .dashboard-header {
            background: linear-gradient(90deg, var(--main-blue), var(--dark-yellow));
            color: var(--white);
            padding: 40px 20px;
            text-align: center;
            font-weight: bold;
            font-size: 2rem;
            border-radius: 0 0 20px 20px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
        }

        .card-custom {
            background-color: var(--white);
            border: none;
            border-radius: 15px;
            padding: 30px;
            margin-top: 40px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease;
        }

        .card-custom:hover {
            transform: translateY(-5px);
        }

        .form-label {
            font-weight: 600;
            color: var(--dark-black);
        }

        .form-control {
            border-radius: 10px;
            padding: 12px;
            border: 2px solid #ced4da;
            transition: border-color 0.3s, box-shadow 0.3s;
        }

        .form-control:focus {
            border-color: var(--main-blue);
            box-shadow: 0 0 10px rgba(0, 123, 255, 0.25);
        }

        .btn-custom {
            background-color: var(--dark-yellow);
            color: var(--dark-black);
            font-weight: bold;
            border: none;
            border-radius: 30px;
            padding: 12px;
            transition: background-color 0.3s ease;
        }

        .btn-custom:hover {
            background-color: #e0a800;
        }

        #lblMessage {
            margin-top: 15px;
            font-weight: 600;
        }

        .footer {
            background-color: var(--main-blue);
            color: var(--white);
            text-align: center;
            padding: 20px 0;
            margin-top: 60px;
            border-radius: 20px 20px 0 0;
            font-weight: 500;
            box-shadow: 0 -2px 10px rgba(0, 0, 0, 0.1);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Dashboard Header -->
        <div class="dashboard-header">
            Manufacture Dashboard
        </div>

        <!-- Form Card -->
        <div class="container">
            <div class="card card-custom mx-auto" style="max-width: 550px;">
                <div class="mb-3">
                    <label for="txtDrugName" class="form-label">Drug Name</label>
                    <asp:TextBox ID="txtDrugName" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtQuantity" class="form-label">Quantity</label>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number" />
                </div>

                <div class="mb-3">
                    <label for="txtUnitPrice" class="form-label">Unit Price (Rs)</label>
                    <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="form-control" TextMode="Number" />
                </div>

                <div class="mb-3">
                    <label for="txtUpdateReason" class="form-label">Update Reason</label>
                    <asp:TextBox ID="txtUpdateReason" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                </div>

                <asp:Button ID="btnUpdateStock" runat="server" CssClass="btn btn-custom w-100" Text="Update Stock" OnClick="btnUpdateStock_Click" />
                <asp:Label ID="lblMessage" runat="server" CssClass="text-center d-block mt-3" />
            </div>
        </div>
              
    </form>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

    <!-- Placeholder JS -->
    <script>
        window.onload = function () {
            document.getElementById('<%= txtDrugName.ClientID %>').setAttribute('placeholder', 'Enter drug name');
            document.getElementById('<%= txtQuantity.ClientID %>').setAttribute('placeholder', 'Enter quantity');
            document.getElementById('<%= txtUnitPrice.ClientID %>').setAttribute('placeholder', 'Enter unit price');
            document.getElementById('<%= txtUpdateReason.ClientID %>').setAttribute('placeholder', 'Enter update reason');
        };
    </script>
</body>
</html>
