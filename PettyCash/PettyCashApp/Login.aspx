<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PettyCashApp.Login" %>

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
    <link href="assets/plugins/sweetalert/sweetalert.css" rel="stylesheet" type="text/css" />
    <script src="assets/plugins/sweetalert/sweetalert.min.js" type="text/javascript"></script>
    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->

    <script src="assets/js/modernizr.min.js"></script>
    <script type="text/javascript">
        function empty_uname_pswd() {
            swal({
                title: 'Error!',
                text: 'Username & Password is required!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
</head>
<body>
    <div class="account-pages"></div>
    <div class="clearfix"></div>
    <div class="wrapper-page">
        <div class="m-t-40 card-box">
            <div class="text-center">
                <a href="index-2.html" class="logo"><span>PettyCash<span>App</span></span></a>
            </div>
            <div class="col-xs-12">
                <div class="alert alert-danger" runat="server" id="inval">
                    <asp:Label ID="lbl_inval" runat="server"></asp:Label>
                </div>
            </div>
            <div class="panel-body">
                <form id="form1" class="form-horizontal m-t-20" runat="server">

                    <div class="form-group ">
                        <div class="col-xs-12">
                            <asp:TextBox ID="txtuname" runat="server" placeholder="Username" CssClass="form-control" onMouseOver="unload();" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12">
                            <asp:TextBox ID="txtpswd" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group text-center m-t-30">
                        <div class="col-xs-12">
                            <asp:Button ID="btnlogin" runat="server" Text="Log In" CssClass="btn btn-info w-md waves-light m-b-5" OnClientClick="vali()" OnClick="btnlogin_Click" />
                        </div>
                    </div>

                </form>

            </div>
        </div>
        <!-- end card-box-->

        <div class="row">
            <div class="col-sm-12 text-center">
                <p class="text-muted">2016 © <a href="http://www.summersoft.in" target="_blank" class="text-primary m-l-5"><b>summersoft</b></a></p>
            </div>
        </div>

    </div>
    <!-- end wrapper page -->



    <%--        <script>
            var resizefunc = [];
        </script>--%>

    <!-- jQuery  -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/detect.js"></script>
    <script src="assets/js/fastclick.js"></script>
    <script src="assets/js/jquery.slimscroll.js"></script>
    <script src="assets/js/jquery.blockUI.js"></script>
    <script src="assets/js/waves.js"></script>
    <script src="assets/js/wow.min.js"></script>
    <script src="assets/js/jquery.nicescroll.js"></script>
    <script src="assets/js/jquery.scrollTo.min.js"></script>

    <!-- App js -->
    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>

    <!-- Validation js -->
    <script src="assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
    <script src="assets/js/validate_js/custom_login.js"></script>

    <script type="text/javascript">
        function vali() {
                Login.init();
        }
    </script>

    <script type="text/javascript">
        function unload() {
            if (document.getElementById("inval") && document.getElementById("inval").innerHTML != "") {
                document.getElementById("inval").className = "no-display";
                document.getElementById("inval").innerHTML = "";
            }
        }
    </script>
</body>
</html>
