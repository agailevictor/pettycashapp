<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="defreeze.aspx.cs" Inherits="PettyCashApp.hr.defreeze" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function success_defreeze() {
            swal({
                title: 'Success!',
                text: 'Journal defreezed successfully!',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                function () {
                    window.location = "defreeze.aspx";
                });
        }
    </script>

    <script type="text/javascript">
        function error_defreeze() {
            swal({
                title: 'Error!',
                text: 'Cannot Defreeze Journal as One is Still Active',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-sm-12">
            <div class="btn-group pull-right m-t-15">
                <div id="clock-1"></div>
            </div>
            <h4 class="page-title">Defreeze Journal</h4>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <div class="row">
                    <form class="form-horizontal" runat="server" id="assign_form">
                        <div class="table-responsive">
                            <asp:GridView ID="grid_users_defreeze" CssClass="table table-striped table-bordered dataTable no-footer" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="4" DataKeyNames="pcmid">
                               <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Opening Date" DataField="odate" />
                                    <asp:BoundField HeaderText="Freezed Date" DataField="fdate" />
                                    <asp:BoundField HeaderText="Balance On Start" DataField="pcbal" />
                                    <asp:BoundField HeaderText="Opened By" DataField="opend_by" />
                                    <asp:BoundField HeaderText="Status" DataField="status" />
                                    <asp:TemplateField HeaderText="Defreeze">
                                        <ItemTemplate>
                                            <div style="padding-left: 20px;">
                                            <asp:LinkButton ID="lnk_defreeze" runat="server" CssClass="fa fa-unlock" OnClick="lnk_defreeze_Click"></asp:LinkButton>
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