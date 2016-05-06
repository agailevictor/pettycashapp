<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Template.aspx.cs" Inherits="PettyCashApp.user.Template" MasterPageFile="~/user/user.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function success_freeze() {
            swal({
                title: "Attention!",
                text: "Almost there sending the monthly report, do not hit refresh you will be redirected in a short period.",
                timer: 15000,
                showConfirmButton: false,
                allowEscapeKey: false,
                allowOutsideClick: false
            }, function () {
                var twist = '<%= Session["checker"] %>';
                if (twist == "t") {
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
                else if(twist == "f") {
                    swal({
                        title: 'Error!',
                        text: 'Failed to send Mail!',
                        type: 'error',
                        allowEscapeKey: false,
                        allowOutsideClick: false
                    },
                    function () {
                        window.location = "Template.aspx";
                    });
                }
                else if (twist == "n") {
                    swal({
                        title: 'Error!',
                        text: 'Failed to freeze journal!',
                        type: 'error',
                        allowEscapeKey: false,
                        allowOutsideClick: false
                    });
                }
                else {
                    success_freeze();
                }
            });
        }
    </script>
    <script type="text/javascript">
        function error_freeze() {
            swal({
                title: 'Error!',
                text: 'Failed to freeze journal!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script type="text/javascript">
        function error_mail() {
            swal({
                title: 'Error!',
                text: 'Failed to send Mail!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="form-horizontal" runat="server" id="ongoing_form">
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <div class="btn-group pull-right m-t-15">
                    <asp:Button ID="btnfreeze" runat="server" Text="Freeze" CssClass="btn btn-danger" OnClick="btnfreeze_Click" />
                    <a href="start_journal.aspx" class="btn btn-custom" id="aTag" runat="server">Add New</a>
                </div>
                <h4 class="page-title">Template</h4>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <h4 class="header-title m-t-0 m-b-30">Journal Details Current & Previous</h4>
                    <div class="row">

                        <div class="table-responsive">
                            <asp:GridView ID="grid_ongoing_details" CssClass="table table-striped table-bordered dataTable no-footer" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grid_ongoing_details_PageIndexChanging" PageSize="4">
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Opening Date" DataField="odate" />
                                    <asp:BoundField HeaderText="Freezed Date" DataField="fdate" />
                                    <asp:BoundField HeaderText="Balance On Start" DataField="pcbal" />
                                    <asp:BoundField HeaderText="Opened By" DataField="opend_by" />
                                    <asp:BoundField HeaderText="Status" DataField="status" />
                                </Columns>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div id="email-delay" class="modal fade" data-width="760" style="display: none;">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="modal-title">Attention !</h4>
                    </div>
                    <div class="modal-body" id="modal-body">
                        <h4 id="mbody">Almost there sending the monthly report, do not hit refresh you will be redirected in a short period.</h4>
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
