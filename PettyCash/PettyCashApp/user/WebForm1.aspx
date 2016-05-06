<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PettyCashApp.user.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function twist() {
            //swal({
            //    title: "Attention!",
            //    text: "Almost there sending the monthly report, do not hit refresh you will be redirected in a short period.",
            //    timer: 15000,
            //    showConfirmButton: false,
            //    allowEscapeKey: false,
            //    allowOutsideClick: false
            //}, function () {
            //    swal({
            //        title: 'Success!',
            //        text: 'Journal freezed successfully!',
            //        type: 'success',
            //        allowEscapeKey: false,
            //        allowOutsideClick: false
            //    },
            //     function () {
            //                    window.location = "WebForm1.aspx";
            //                });
            //});

           <%--alert('<%= Session["checker"] %>');--%>

          swal({
                title: "Attention!",
                text: "Almost there sending the monthly report, do not hit refresh you will be redirected in a short period.",
                timer: 15000,
                showConfirmButton: false,
                allowEscapeKey: false,
                allowOutsideClick: false
            }, function () {
                var twist1 = '<%= Session["checker"] %>';
                if (twist1 == "t") {
                    swal({
                        title: 'Success!',
                        text: 'Journal freezed successfully!',
                        type: 'success',
                        allowEscapeKey: false,
                        allowOutsideClick: false
                    },
                     function () {
                         window.location = "Template.aspx";
                     });
                }
                else if (twist1 == "f") {
                    swal({
                        title: 'Error!',
                        text: 'Failed to freeze journal!',
                        type: 'error',
                        allowEscapeKey: false,
                        allowOutsideClick: false
                    });
                }
                else {
                    //twist();
                    swal({
                        title: 'Agaile!',
                        text: 'Failed to freeze journal!',
                        allowEscapeKey: false,
                        allowOutsideClick: false
                    });
                }
            });


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page-Title -->
    <form runat="server" id="twist">
        <div class="row">
            <div class="col-sm-12">
                <div class="btn-group pull-right m-t-15">
                    <div id="clock-1"></div>
                </div>
                <h4 class="page-title">Dashboard</h4>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            </div>
        </div>
    </form>


</asp:Content>
