<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assign.aspx.cs" Inherits="PettyCashApp.hr.Assign" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function error_ddl_empty() {
            swal({
                title: 'Error!',
                text: 'Select atleast one user',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>

    <script type="text/javascript">
        function success_assign() {
            swal({
                title: 'Success!',
                text: 'User has been succesfully Assigned',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>

    <script type="text/javascript">
        function error_assign() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>


    <script type="text/javascript">
        function success_unassign() {
            swal({
                title: 'Success!',
                text: 'User has been succesfully Unassigned',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },

                function () {
                    window.location = "Assign.aspx";
                });
        }
    </script>


    <script type="text/javascript">
        function failure_unassign() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>

    <style>
        .cust {
            width: 30%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <div class="btn-group pull-right m-t-15">
                <div id="clock-1"></div>
            </div>
            <h4 class="page-title">Assign User</h4>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <div class="row">
                    <form class="form-horizontal" runat="server" id="assign_form">
                        <div class="form-group" id="assignee_user">
                            <label for="assignee" class="col-sm-4 control-label">Select Assignee*</label>
                            <div class="col-sm-7">
                                <asp:DropDownList ID="ddl_assign_user" runat="server" CssClass="form-control cust" DataTextField="Name" DataValueField="user_id" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-8">
                                <asp:Button ID="Button1" runat="server" Text="Assign" CssClass="btn btn-primary waves-light" OnClick="Button1_Click" OnClientClick="assign_vali()" ClientIDMode="Static" />
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="grid_assigned_user" ShowHeaderWhenEmpty="true" CssClass="table table-striped table-bordered dataTable no-footer" runat="server" AutoGenerateColumns="False" DataKeyNames="user_id">
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Name" DataField="name" />
                                    <asp:BoundField HeaderText="Department" DataField="Department" />
                                    <asp:BoundField HeaderText="Designation" DataField="Designation" />
                                    <asp:TemplateField HeaderText="Remove Assignee">

                                        <ItemTemplate>
                                            <div style="padding-left: 60px;">
                                                <asp:LinkButton ID="lnk_rmv_assign" runat="server" CssClass="btn btn-icon  waves-light btn-danger m-b-5 fa fa-remove" OnClick="lnk_rmv_assign_Click"></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>No records Available !</EmptyDataTemplate>
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <!-- end col -->
    </div>
</asp:Content>
