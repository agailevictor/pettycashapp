<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JournalList.aspx.cs" Inherits="PettyCashApp.user.JournalList" MasterPageFile="~/user/user.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function success_delete() {
            swal({
                title: 'Success!',
                text: 'Entry has been succesfully Deleted',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>

    <script type="text/javascript">
        function error_delete() {
            swal({
                title: 'Error!',
                text: 'Something Went Wrong',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
    <style type="text/css">
        .hidden {
            display: none;
        }
    </style>

    <script type="text/javascript">
        function PostToNewWindow() {
            originalTarget = document.forms[0].target;
            document.forms[0].target = '_blank';
            window.setTimeout("document.forms[0].target=originalTarget;", 300);
            return true;
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form class="form-horizontal" runat="server" id="logdetails_form">
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <div class="btn-group pull-right m-t-15">
                    <a href="Journal.aspx" class="btn btn-custom" id="aeTag" runat="server">Add New Entry</a>
                </div>
                <h4 class="page-title">Journal Log(s)</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <h4 class="header-title m-t-0 m-b-30">Journal Entry(s) Current </h4>
                    <div class="row">

                        <div class="table-responsive">
                            <asp:GridView ID="grid_ongoing_details" CssClass="table table-striped table-bordered dataTable no-footer" runat="server" AutoGenerateColumns="False" DataKeyNames="id" AllowPaging="True" OnPageIndexChanging="grid_ongoing_details_PageIndexChanging" PageSize="4">
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Entry Date" DataField="entry_date" />
                                    <asp:BoundField HeaderText="Type" DataField="type_detail" />
                                    <asp:BoundField HeaderText="Receipt No" DataField="r_no" />
                                    <asp:BoundField HeaderText="Item" DataField="item_name" />
                                    <asp:BoundField DataField="qty" HeaderText="Qty" />
                                    <asp:BoundField HeaderText="Amount" DataField="amount" />
                                    <asp:BoundField HeaderText="Description" DataField="description" />
                                    <asp:BoundField DataField="visible" HeaderText="Condition">
                                        <HeaderStyle CssClass="hidden"></HeaderStyle>
                                        <ItemStyle CssClass="hidden"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Bill">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_bill" runat="server" OnClick="lnk_bill_Click" OnClientClick="PostToNewWindow()">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Voucher">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_vhr" runat="server" OnClick="lnk_vhr_Click" Visible='<%# Isenable((string)Eval("visible")) %>' OnClientClick="PostToNewWindow()" >View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Operation">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="edit_link" runat="server" CssClass="fa fa-edit" OnClick="edit_link_Click"></asp:LinkButton>
                                            <%--<div style="padding-left: 60px;">--%>
                                            <asp:LinkButton ID="delete_link" runat="server" CssClass="zmdi zmdi-delete" OnClick="delete_link_Click"></asp:LinkButton>
                                            <%--  </div>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
