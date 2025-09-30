<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SPCWebsite.Register" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>SPC Pharmacy - Register</title>

  <!-- Bootstrap & FontAwesome -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
  <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />

  <style>
    body {
      background: url('https://tse4.mm.bing.net/th/id/OIP.ADlGhxIZYRXdYSKsfqDgqgHaEK?pid=Api&P=0&h=220') no-repeat center center fixed;
      background-size: cover;
      font-family: 'Segoe UI', sans-serif;
      min-height: 100vh;
      margin: 0;
      display: flex;
      align-items: center;
      justify-content: center;
      position: relative;
      padding: 20px;
    }

    body::before {
      content: "";
      position: absolute;
      top: 0; left: 0;
      width: 100%; height: 100%;
      background: rgba(0, 0, 0, 0.6);
      z-index: 0;
    }

    .register-card {
      background: white;
      border-radius: 20px;
      padding: 40px 30px;
      width: 100%;
      max-width: 720px;
      z-index: 1;
      position: relative;
      box-shadow: 0 8px 30px rgba(0, 0, 0, 0.4);
      animation: slideIn 0.9s ease-out;
    }

    @keyframes slideIn {
      from {
        transform: translateY(30px);
        opacity: 0;
      }
      to {
        transform: translateY(0);
        opacity: 1;
      }
    }

    h2 {
      text-align: center;
      color: #007bff;
      font-weight: 800;
      margin-bottom: 25px;
    }

    .form-label {
      font-weight: 600;
      color: #333;
    }

    .form-control:focus {
      border-color: #007bff;
      box-shadow: 0 0 8px rgba(0, 123, 255, 0.3);
    }

    .btn-register {
      background-color: #ffcc00; /* Dark Yellow */
      color: black;
      font-weight: bold;
      border: none;
      transition: 0.3s ease;
    }

    .btn-register:hover {
      background-color: #e6b800;
      color: white;
    }

    .form-text-center {
      text-align: center;
      margin-top: 15px;
    }

    .form-text-center a {
      color: #ffcc00;
      font-weight: 600;
      text-decoration: none;
    }

    .form-text-center a:hover {
      text-decoration: underline;
    }

    .icon-top {
      text-align: center;
      font-size: 48px;
      color: #ffcc00;
      margin-bottom: 10px;
    }

    .label-required::after {
      content: "*";
      color: red;
      margin-left: 4px;
    }
  </style>
</head>
<body>

  <form id="form1" runat="server" class="register-card">
    <div class="icon-top">
      <i class="fas fa-user-plus"></i>
    </div>
    <h2>Register to SPC Pharmacy</h2>

    <asp:Label ID="lblMessage" runat="server" CssClass="text-center d-block text-danger mb-3"></asp:Label>

    <div class="row">
      <div class="col-md-6 mb-3">
        <asp:Label ID="lblCompany" runat="server" Text="Company Name" CssClass="form-label label-required"></asp:Label>
        <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control" />
      </div>

      <div class="col-md-6 mb-3">
        <asp:Label ID="lblContact" runat="server" Text="Contact Person" CssClass="form-label label-required"></asp:Label>
        <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" />
      </div>
    </div>

    <div class="row">
      <div class="col-md-6 mb-3">
        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label label-required"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
      </div>

      <div class="col-md-6 mb-3">
        <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label label-required"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
      </div>
    </div>

    <div class="row">
      <div class="col-md-6 mb-3">
        <asp:Label ID="lblPhone" runat="server" Text="Phone" CssClass="form-label label-required"></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
      </div>

      <div class="col-md-6 mb-3">
        <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="form-label label-required"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" />
      </div>
    </div>

    <div class="row">
      <div class="col-md-6 mb-3">
        <asp:Label ID="lblLicense" runat="server" Text="License Number" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtLicense" runat="server" CssClass="form-control" />
      </div>

      <div class="col-md-6 mb-3">
        <asp:Label ID="lblRole" runat="server" Text="Role" CssClass="form-label label-required"></asp:Label>
        <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select">
          <asp:ListItem Text="Select Role" Value="" />
          <asp:ListItem Text="Supplier" Value="Supplier" />
          <asp:ListItem Text="Pharmacy" Value="Pharmacy" />
          <asp:ListItem Text="Warehouse" Value="Warehouse" />
          <asp:ListItem Text="Manufacture" Value="Manufacture" />
        </asp:DropDownList>
      </div>
    </div>

    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-register w-100 mt-3" OnClick="btnRegister_Click" />

    <div class="form-text-center">
      Already have an account? <a href="Login.aspx">Login here</a>
    </div>
  </form>

  <!-- Bootstrap JS -->
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>
