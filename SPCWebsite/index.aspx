<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SPCWebsite.index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <title>SPC Pharmacy</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap 5 & Font Awesome -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet" />

    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f8f9fa;
        }

        .navbar {
            background: linear-gradient(90deg, #003366, #0066cc);
        }

        .navbar-brand, .navbar-nav .nav-link {
            color: #fff !important;
        }

        .navbar-nav .nav-link:hover {
            color: #ffcc00 !important;
        }

        .hero {
            background: url('https://www.pkf.com.au/uploads/Insights/Health-AdobeStock_527209943-Pharmacy-60-day-dispensing.jpg') center/cover no-repeat;
            color: #fff;
            height: 90vh;
            position: relative;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .hero::before {
            content: '';
            position: absolute;
            inset: 0;
            background: rgba(0, 0, 0, 0.4);
        }

        .hero-content {
            z-index: 1;
            text-align: center;
            max-width: 800px;
        }

        .hero h1 {
            font-size: 3.5rem;
            font-weight: bold;
            text-shadow: 2px 2px 10px rgba(0, 0, 0, 0.7);
        }

        .hero p {
            font-size: 1.3rem;
            margin-bottom: 2rem;
        }

        .btn-hero {
            background: #ffcc00;
            color: #003366;
            font-weight: 600;
            padding: 12px 30px;
            border-radius: 50px;
        }

        .btn-hero:hover {
            background: #e6b800;
        }

        .highlight-section {
            padding: 80px 0;
            background-color: #fff;
        }

        .highlight-section h2 {
            font-weight: bold;
            color: #003366;
            text-align: center;
            margin-bottom: 40px;
        }

        .highlight-card {
            background: #e9f5ff;
            border-radius: 12px;
            padding: 30px;
            text-align: center;
            transition: all 0.3s ease-in-out;
            height: 100%;
        }

        .highlight-card:hover {
            transform: translateY(-5px);
            background: #d0ebff;
        }

        .blogs {
            padding: 80px 0;
            background: #f0f8ff;
        }

        .blogs h2 {
            color: #003366;
            font-weight: bold;
            text-align: center;
            margin-bottom: 50px;
        }

        .card {
            border: none;
            border-radius: 15px;
            transition: transform 0.3s;
        }

        .card:hover {
            transform: scale(1.03);
        }

        .card-title {
            color: #0066cc;
            font-weight: 600;
        }

        .footer {
            background: #003366;
            color: #fff;
            padding: 40px 0;
        }

        .footer a {
            color: #ffcc00;
            margin: 0 8px;
            font-size: 1.2rem;
        }

        .footer a:hover {
            color: #fff;
        }
    </style>
</head>
<body>
    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg navbar-dark fixed-top">
        <div class="container">
            <a class="navbar-brand fw-bold" href="#">SPC Pharmacy</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navMenu">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navMenu">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item"><a class="nav-link" href="#home">Home</a></li>
                    <li class="nav-item"><a class="nav-link" href="#mission">Mission</a></li>
                    <li class="nav-item"><a class="nav-link" href="#values">Values</a></li>
                    <li class="nav-item"><a class="nav-link" href="#blogs">Blogs</a></li>
                    <li class="nav-item"><a class="btn btn-warning text-dark fw-semibold ms-3" href="Login.aspx">Login</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <!-- Hero Section -->
    <section id="home" class="hero">
        <div class="hero-content container">
            <h1>Your Lifelong Wellness Partner</h1>
            <p>Delivering affordable, high-quality medicines across Sri Lanka</p>
            <a href="#mission" class="btn btn-hero">Explore More</a>
        </div>
    </section>

    <!-- Mission Section -->
    <section id="mission" class="highlight-section">
        <div class="container">
            <h2>Our Mission</h2>
            <div class="row g-4">
                <div class="col-md-4">
                    <div class="highlight-card">
                        <i class="fas fa-pills fa-2x mb-3 text-primary"></i>
                        <h5>Affordable Medicine</h5>
                        <p>We ensure the lowest possible prices while maintaining global pharmaceutical quality standards.</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="highlight-card">
                        <i class="fas fa-hospital fa-2x mb-3 text-primary"></i>
                        <h5>Healthcare for All</h5>
                        <p>SPC guarantees medicine access to every citizen through a national outlet network.</p>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="highlight-card">
                        <i class="fas fa-truck fa-2x mb-3 text-primary"></i>
                        <h5>Nationwide Delivery</h5>
                        <p>Our logistics ensure consistent, island-wide medicine distribution, even in rural areas.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Values Section -->
    <section id="values" class="highlight-section bg-light">
        <div class="container">
            <h2>Our Core Values</h2>
            <div class="row g-4">
                <div class="col-md-6">
                    <div class="highlight-card">
                        <i class="fas fa-user-shield fa-2x mb-3 text-success"></i>
                        <h5>Integrity & Transparency</h5>
                        <p>Every operation at SPC is built on accountability, trust, and public service ethics.</p>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="highlight-card">
                        <i class="fas fa-vial fa-2x mb-3 text-success"></i>
                        <h5>Innovation in Healthcare</h5>
                        <p>We adapt to global innovations to provide efficient digital services and improve access.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Blogs Section -->
    <section id="blogs" class="blogs">
        <div class="container">
            <h2>Latest Health & Pharmacy Blogs</h2>
            <div class="row g-4 mt-4">
                <div class="col-md-4">
                    <div class="card shadow-sm">
                        <img src="https://tse2.mm.bing.net/th/id/OIP.X57gckKIOZCIKK2C0beUcQHaE8?pid=Api&P=0&h=220" class="card-img-top" alt="Blog 1">
                        <div class="card-body text-center">
                            <h5 class="card-title">Daily Health Habits</h5>
                            <p class="card-text">Build a healthier routine with small but impactful lifestyle changes.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card shadow-sm">
                        <img src="https://tse2.mm.bing.net/th/id/OIP.IcY5ag6iv2S4lm-KdU1_tAHaE8?pid=Api&P=0&h=220" class="card-img-top" alt="Blog 2">
                        <div class="card-body text-center">
                            <h5 class="card-title">Affordable Medication</h5>
                            <p class="card-text">Learn how SPC ensures medication affordability for every citizen.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card shadow-sm">
                        <img src="https://tse4.mm.bing.net/th/id/OIP._W1bdqsoP3XYP2PqlBM1LwHaEK?pid=Api&P=0&h=220" class="card-img-top" alt="Blog 3">
                        <div class="card-body text-center">
                            <h5 class="card-title">SPC Distribution Network</h5>
                            <p class="card-text">A behind-the-scenes look at how medicine gets to your pharmacy.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Footer -->
    <footer class="footer text-center">
        <div class="container">
            <p class="mb-2">📧 info@spcpharmacy.lk | 📞 +94 11 234 5678</p>
            <div class="mb-3">
                <a href="#"><i class="fab fa-facebook"></i></a>
                <a href="#"><i class="fab fa-twitter"></i></a>
                <a href="#"><i class="fab fa-instagram"></i></a>
                <a href="#"><i class="fab fa-linkedin"></i></a>
            </div>
            <p class="mb-0">&copy; 2025 SPC Pharmacy. All Rights Reserved.</p>
        </div>
    </footer>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
