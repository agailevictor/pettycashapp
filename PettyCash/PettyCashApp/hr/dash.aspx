<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dash.aspx.cs" Inherits="PettyCashApp.hr.dash" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="form-horizontal" runat="server" id="dash_form">
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <div class="btn-group pull-right m-t-15">
                    <div id="clock-1"></div>
                </div>
                <h4 class="page-title">Dashboard</h4>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-4 col-md-6">
                <div class="card-box">

                    <h4 class="header-title m-t-0 m-b-30">Cash Balance</h4>

                    <div class="widget-chart-1">
                        <div class="widget-chart-box-1">
                            <span id="cb"><span id="cbh"></span><i id="cbi"></i></span>
                        </div>
                        <div class="widget-detail-1">
                            <h2 id="cbv" class="p-t-10 m-b-0"></h2>
                            <p class="fa fa-inr"></p>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end col -->

            <div class="col-lg-4 col-md-6">
                <div class="card-box">

                    <h4 class="header-title m-t-0 m-b-30">Current Month Expense</h4>

                    <div class="widget-chart-1">
                        <div class="widget-chart-box-1">
                            <span id="ce"><span id="ceh"></span><i id="cei"></i></span>
                        </div>

                        <div class="widget-detail-1">
                            <h2 id="cev" class="p-t-10 m-b-0"></h2>
                            <p class="fa fa-inr"></p>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end col -->

            <div class="col-lg-4 col-md-6">
                <div class="card-box">

                    <h4 class="header-title m-t-0 m-b-30">Previous Month Expense</h4>

                    <div class="widget-chart-1">
                        <div class="widget-chart-box-1">
                            <span id="pe"><span id="peh"></span><i id="pei"></i></span>
                        </div>
                        <div class="widget-detail-1">
                            <h2 id="pev" class="p-t-10 m-b-0"></h2>
                            <p class="fa fa-inr"></p>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end col -->
        </div>

        <div class="row">

            <div class="col-lg-12">
                <div class="card-box">
                    <h4 class="header-title m-t-0 m-b-30">Latest Entries</h4>

                    <div class="table-responsive">
                        <asp:GridView ID="grd_latest" CssClass="table table-striped table-bordered dataTable no-footer" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grd_latest_PageIndexChanging" PageSize="4">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="entry_date" HeaderText="Entry Date" />
                                <asp:BoundField DataField="type_detail" HeaderText="Type" />
                                <asp:BoundField DataField="r_no" HeaderText="Receipt No" />
                                <asp:BoundField DataField="item_name" HeaderText="Item" />
                                <asp:BoundField DataField="qty" HeaderText="Qty" />
                                <asp:BoundField DataField="amount" HeaderText="Amount" />
                                <asp:BoundField DataField="Name" HeaderText="Entered By" />
                            </Columns>
                            <PagerStyle CssClass="pagination-ys" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <!-- end col -->

        </div>
        <!-- end row -->
    </form>
</asp:Content>
