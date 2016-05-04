<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report1.aspx.cs" Inherits="PettyCashApp.user.Report1" MasterPageFile="~/user/user.Master" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <h4 class="page-title">Ongoing Report</h4>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <div class="row">
                    <form class="form-horizontal" runat="server" id="assign_form">
                        <div class="table-responsive">
                            <asp:GridView ID="grd_ogrpt" runat="server" CssClass="table table-striped table-bordered dataTable no-footer" ClientIDMode="Static" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="grd_ogrpt_PageIndexChanging" PageSize="4">
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Entry Date" DataField="entry_date" />
                                    <asp:BoundField HeaderText="Type" DataField="typ" />
                                    <asp:BoundField HeaderText="Receipt No" DataField="r_no" />
                                    <asp:BoundField HeaderText="Item" DataField="item_name" />
                                    <asp:BoundField HeaderText="Quantity" DataField="qty"/>
                                    <asp:BoundField HeaderText="Amount" DataField="amount" />
                                </Columns>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                        <div class="arrange pull-right">
                            <asp:Button ID="btn_pdf" CssClass="btn btn-primary waves-light" runat="server" Text="Export to PDF" OnClick="btn_pdf_Click" />
                            <asp:Button ID="btn_exl" CssClass="btn btn-primary waves-light" runat="server" Text="Export to Excel" OnClick="btn_exl_Click" />

                        </div>
                    </form>
                </div>
            </div>
        </div>
        <!-- end col -->
    </div>

</asp:Content>
