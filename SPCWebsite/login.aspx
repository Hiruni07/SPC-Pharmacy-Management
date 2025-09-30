<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SPCWebsite.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>SPC Pharmacy | Login</title>

  <!-- Bootstrap & FontAwesome -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
  <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />

  <style>
    body {
      background: url('https://www.bennettphilp.com.au/wp-content/uploads/2019/09/Aisle-of-pharmacy-e1569376043853.jpg') no-repeat center center fixed;
      background-size: cover;
      height: 100vh;
      display: flex;
      justify-content: center;
      align-items: center;
      font-family: 'Segoe UI', sans-serif;
      margin: 0;
      position: relative;
    }

    body::before {
      content: "";
      position: absolute;
      top: 0; left: 0;
      width: 100%; height: 100%;
      background: linear-gradient(135deg, rgba(0, 0, 0, 0.65), rgba(0, 123, 255, 0.6));
      z-index: 0;
    }

    .card-login {
      background: white;
      border-radius: 15px;
      box-shadow: 0px 0px 25px rgba(0, 0, 0, 0.4);
      padding: 40px 30px;
      width: 100%;
      max-width: 420px;
      position: relative;
      z-index: 1;
      animation: fadeInUp 0.9s ease-out;
    }

    @keyframes fadeInUp {
      from {
        transform: translateY(40px);
        opacity: 0;
      }
      to {
        transform: translateY(0);
        opacity: 1;
      }
    }

    .card-login h3 {
      text-align: center;
      color: #007bff;
      font-weight: 700;
      margin-bottom: 30px;
    }

    .icon-box {
      text-align: center;
      font-size: 48px;
      color: goldenrod;
      margin-bottom: 10px;
    }

    .form-control {
      border: 1px solid #ced4da;
      border-radius: 0.5rem;
    }

    .form-control:focus {
      border-color: #007bff;
      box-shadow: 0 0 10px rgba(0, 123, 255, 0.4);
    }

    .btn-login {
      background-color: #007bff;
      border: none;
      color: #fff;
      font-weight: bold;
      transition: 0.3s ease;
      border-radius: 0.5rem;
    }

    .btn-login:hover {
      background-color: goldenrod;
    }

    .form-footer {
      text-align: center;
      margin-top: 20px;
    }

    .form-footer a {
      color: goldenrod;
      font-weight: 600;
      text-decoration: none;
    }

    .form-footer a:hover {
      text-decoration: underline;
    }
  </style>
</head>
<body>

  <div class="card-login">
    <div class="icon-box">
      <i class="fas fa-user-shield"></i>
    </div>
    <h3>Login to SPC Pharmacy</h3>

    <form id="form1" runat="server">
      <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3" placeholder="Email address" TextMode="Email" />
      <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mb-3" placeholder="Password" TextMode="Password" />
      <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-login w-100" Text="Login" OnClick="btnLogin_Click" />
      <div class="form-footer mt-3">
        <span>Don't have an account? <a href="Register.aspx">Register here</a></span>
      </div>
    </form>
  </div>

  <!-- Scripts -->
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>
