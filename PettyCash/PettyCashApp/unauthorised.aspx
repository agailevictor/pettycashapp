﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unauthorised.aspx.cs" Inherits="PettyCashApp.unauthorised" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="A fully featured admin theme which can be used to build CRM, CMS, etc." />
    <meta name="author" content="Coderthemes" />

    <!-- App Favicon -->
    <link rel="shortcut icon" href="assets/images/favicon.ico" />

    <!-- App title -->
    <title>PettyCashApp</title>
    <script type="text/javascript">
        function DisableBack() {
            window.history.forward();
        }
        DisableBack();
        window.onload = DisableBack;
        window.onpageshow = function (evt) {
            if (evt.persisted) DisableBack();
        }
        window.onunload = function () { void (0); }
    </script>

    <!-- App CSS -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/menu.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->

    <script src="assets/js/modernizr.min.js"></script>
    <style type="text/css">
        .ex-page-content.text-center {
            background-color: rgba(219, 219, 219, 0.86);
            border-radius: 7px;
            padding: 20px;
        }

        .ex-page-content .text-muted {
            color: #505458 !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="account-pages"></div>
        <div class="clearfix"></div>
        <div class="wrapper-page">
            <div class="ex-page-content text-center">
                <div class="text-error">404</div>
                <h3 class="text-uppercase font-600">Page not Found</h3>
                <p class="text-muted">
                    It's looking like you may have taken a wrong turn. Don't worry... it happens to
                    the best of us. You might want to check your internet connection. Here's a little tip that might
                    help you get back on track.
                </p>
                <br />
                <a class="btn btn-success waves-effect waves-light" href="MainPage.aspx">Return Home</a>

            </div>
        </div>
    </form>
</body>
</html>
