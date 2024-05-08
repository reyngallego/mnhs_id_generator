﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="WebApplication4.dashboard" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Admin Dashboard</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS for Admin Dashboard -->
    <link href="styles/styles.css" rel="stylesheet">
</head>
<body>
    <div class="wrapper">
        <div class="sidebar">
            <ul class="nav">
                <h2>Moonwalk National Highschool</h2>
                <img src="gallery/mnhslogo.png" alt="Logo" class="img-fluid mt-3" style="width: 150px;">

                <li><a href="#">Dashboard</a></li>
                <li><a href="#">Attendance</a></li>
                <li><a href="#" class="active" id="addStudentRecord">Student</a></li>
                <li><a href="#">Reports</a></li>
                <li><a href="#">Id Generator</a></li>
                <li><a href="#">Log out</a></li>
            </ul>
        </div>
        <div class="content" id="mainContent">
            <h1>Welcome to the Admin Dashboard!</h1>
            <p>This is a basic Bootstrap template for an admin dashboard with tabs on the left side.</p>
        </div>
    </div>

    <!-- Bootstrap JS dependencies (jQuery, Popper.js, Bootstrap JS) -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
     <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script>
        $(document).ready(function () {
            // Use delegated event handler for dynamically added elements
            $(document).on("click", "#addStudentRecord", function (e) {
                e.preventDefault();
                $("#mainContent").load("dashboard/add_student_record.html");
            });
        });
    </script>
</body>
</html>
