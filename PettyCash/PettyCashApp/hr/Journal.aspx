<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Journal.aspx.cs" Inherits="PettyCashApp.hr.Journal" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cust{

    width:30%;

        }
    </style>

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
    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <div class="btn-group pull-right m-t-15">
                <div id="clock-1"></div>
            </div>
            <h4 class="page-title">Journal Validation</h4>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <div class="row">
                    <form class="form-horizontal" runat="server" id="startj_form">
                        <div class="form-group">
                            <label for="lbluser" class="col-sm-4 control-label">Select Date*</label>
                            <div class="col-sm-7">
                                <asp:DropDownList ID="start_date" runat="server" CssClass="form-control cust" DataTextField="odate" DataValueField="pcmid"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-8">
                                <asp:Button ID="jnul_hrty" runat="server" Text="Submit" CssClass="btn btn-primary waves-light" ClientIDMode="Static" OnClientClick="rpt_vali()" OnClick="jnul_hrty_Click" />
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="junl_grid" runat="server" CssClass="table table-striped table-bordered dataTable no-footer dataTables_paginate paging_simple_numbers" AutoGenerateColumns="False" AllowPaging="True" PageSize="4" OnPageIndexChanging="rpt_grid_PageIndexChanging" DataKeyNames="id">
                                <Columns>
                                    <asp:TemplateField HeaderText="No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Entry Date" DataField="entry_date" />
                                    <asp:BoundField HeaderText="Type" DataField="type_detail" />
                                    <asp:BoundField HeaderText="Reciept No:" DataField="r_no" />
                                    <asp:BoundField HeaderText="Item" DataField="item_name" />
                                    <asp:BoundField HeaderText="Qty" DataField="qty" />
                                    <asp:BoundField HeaderText="Price" DataField="amount" />
                                    <asp:BoundField HeaderText="Entered By" DataField="name" /> 
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
                                            <asp:LinkButton ID="lnk_vhr" runat="server" OnClick="lnk_vhr_Click" Visible='<%# Isenable((string)Eval("visible")) %>' OnClientClick="PostToNewWindow()">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
