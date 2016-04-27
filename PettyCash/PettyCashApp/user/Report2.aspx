<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report2.aspx.cs" Inherits="PettyCashApp.user.Report2" MasterPageFile="~/user/user.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style type="text/css">
        .arrange {
            text-align: right;
            padding: 20px;
            padding-top: 0;
        }
    </style>
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
            <h4 class="page-title">Report 2</h4>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <div class="row">
                    <form class="form-horizontal" runat="server" id="startj_form">
                        <div class="form-group">
                            <label for="lbluser" class="col-sm-4 control-label">Select Date</label>
                            <div class="col-sm-7">
                                <asp:DropDownList ID="start_date" runat="server" CssClass="form-control cust" DataTextField="odate" DataValueField="pcmid"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-8">
                                <asp:Button ID="rpt_htry" runat="server" Text="Get Report" CssClass="btn btn-primary waves-light" OnClick="rpt_htry_Click" ClientIDMode="Static" />
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="rpt_grid" runat="server" CssClass="table table-striped table-bordered dataTable no-footer dataTables_paginate paging_simple_numbers" AutoGenerateColumns="False" AllowPaging="True" PageSize="4" OnPageIndexChanging="rpt_grid_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Entry Date" DataField="odate" />
                                    <asp:BoundField HeaderText="Type" DataField="typ" />
                                    <asp:BoundField HeaderText="Item" DataField="item_name" />
                                    <asp:BoundField HeaderText="Reciept No:" DataField="r_no" />
                                    <asp:BoundField HeaderText="Price" DataField="amount" />
                                    <asp:BoundField HeaderText="Entered By" DataField="opend_by" />
                                </Columns>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                        <div class="arrange">
                            <asp:Button ID="btn_pdf" runat="server" Text="Export to PDF" CssClass="btn btn-primary waves-light" OnClick="btn_pdf_Click" />

                            <asp:Button ID="btn_excel" runat="server" Text="Export to Excel" CssClass="btn btn-primary waves-light" OnClick="btn_excel_Click" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
