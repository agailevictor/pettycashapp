<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="start_journal.aspx.cs" Inherits="PettyCashApp.user.start_journal" MasterPageFile="~/user/user.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function empty_fields() {
            swal({
                title: 'Error!',
                text: 'Provide the required fields!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <script>
        function success_jstart() {
            swal({
                title: 'Success!',
                text: 'Journal added successfully!',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                function () {
                    window.location = "Template.aspx";
                });
        }
    </script>
    <script type="text/javascript">
        function error_jstart() {
            swal({
                title: 'Error!',
                text: 'Failed to create journal!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Start New Journal</h4>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="header-title m-t-0 m-b-30">Enter Journal details</h4>
                <div class="row">
                    <form class="form-horizontal" runat="server" id="startj_form">
                        <div class="form-group">
                            <label for="lbluser" class="col-sm-4 control-label">Opening By</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lbluser" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lblregion" class="col-sm-4 control-label">Region</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblregion" runat="server" CssClass="form-control"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtdate" class="col-sm-4 control-label">Date*</label>
                            <div class="col-sm-7">
                                <asp:TextBox ID="txtsjdate" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-8">
                                <asp:Button ID="btnadd" runat="server" Text="Add Journal" CssClass="btn btn-primary waves-light" ClientIDMode="Static" OnClientClick="startj_vali()" OnClick="btnadd_Click" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
