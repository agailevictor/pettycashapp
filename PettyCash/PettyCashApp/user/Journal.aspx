<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Journal.aspx.cs" Inherits="PettyCashApp.user.Journal" MasterPageFile="~/user/user.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function success_entry() {
            swal({
                title: 'Success!',
                text: 'Entry added successfully!',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                function () {
                    window.location = "JournalList.aspx";
                });
        }
    </script>
    <script type="text/javascript">
        function error_entry() {
            swal({
                title: 'Error!',
                text: 'Something went wrong!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>

    <script>
        function success_deposit() {
            swal({
                title: 'Success!',
                text: 'Entry added successfully!',
                type: 'success',
                allowEscapeKey: false,
                allowOutsideClick: false
            },
                function () {
                    window.location = "JournalList.aspx";
                });
        }
    </script>
    <script type="text/javascript">
        function error_deposit() {
            swal({
                title: 'Error!',
                text: 'Something went wrong!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>

    <script type="text/javascript">
        function error_nofile() {
            swal({
                title: 'Error!',
                text: 'No file present for Bill or Voucher. Please Check!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>

    <script type="text/javascript">
        function error_ext() {
            swal({
                title: 'Error!',
                text: 'Only Pdf Files are Accepted!',
                type: 'error',
                allowEscapeKey: false,
                allowOutsideClick: false
            });
        }
    </script>

    <script type="text/javascript">
        function error_size() {
            swal({
                title: 'Error!',
                text: 'File size should be less than 3mb!',
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
            <h4 class="page-title">Journal Entry</h4>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="card-box">
                <h4 class="header-title m-t-0 m-b-30">Add New Entry</h4>
                <form id="journal_entry" runat="server">
                    <div class="form-group">
                        <label for="date">Date*</label>
                        <asp:TextBox ID="txtdate" runat="server" placeholder="Enter Date" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="receiptno">Receipt No*</label>
                        <asp:TextBox ID="txtrcpt" runat="server" placeholder="Enter Receipt No" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="type">Type*</label>
                        <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control cls_type"
                            ClientIDMode="Static" DataTextField="type_detail" DataValueField="type_id">
                        </asp:DropDownList>
                    </div>
                    <div id="wrk_div_deposit" class="form-group hidden">
                        <label for="amount">Amount*</label>
                        <asp:TextBox ID="txtamountd" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="bfp">Bill Upload*</label>
                                <asp:FileUpload ID="bfp" runat="server" ClientIDMode="Static" />
                                 <small>Allowed File Type: PDF</small>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">                              
                                <asp:CheckBox ID="fup_new" runat="server" ClientIDMode="Static" />
                                <label for="fup_new">Click here to upload Voucher</label>
                            </div>
                        </div>
                    </div>
                    <div id="v_up" class="row hidden">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="vfp">Voucher Upload*</label>
                                <asp:FileUpload ID="vfp" runat="server" ClientIDMode="Static"/>
                                <small>Allowed File Type: PDF</small>
                            </div>
                        </div>
                    </div>
                    <div id="wrk_div_withdraw" class="row hidden">
                        <div class="col-lg-12">
                            <div class="panel panel-custom panel-border">
                                <div class="panel-heading">
                                    <div class="pull-right">
                                        <button id="addToTable" type="button" class="btn btn-primary waves-effect waves-light">Add <i class="zmdi zmdi-plus"></i></button>
                                    </div>
                                    <h3 class="panel-title">Item Details</h3>
                                </div>
                                <div class="panel-body area_insert">
                                    <div class="cls_deposit active">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label for="item_name">Item Name*</label>
                                                <asp:TextBox ID="item_name1" placeholder="Enter item" runat="server" CssClass="form-control item_name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label for="price">Price*</label>
                                                <asp:TextBox ID="price1" runat="server" placeholder="Enter price" CssClass="form-control item_price"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label for="desc">Description</label>
                                                <asp:TextBox ID="desc1" runat="server" CssClass="form-control item_desc" placeholder="Enter Description" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-1">
                                            <a href="javascript:;" class="pull-right row_remove hidden" style="padding-top: 25px;" title="Remove">
                                                <i class="zmdi zmdi-delete" style="font-size: 25px;"></i>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <div class="form-group text-right m-b-0">
                        <asp:Button ID="btnaddentry" runat="server" Text="Submit" CssClass="btn btn-primary" OnClientClick="jvali()" ClientIDMode="Static" OnClick="btnaddentry_Click" />
                    </div>
                </form>
            </div>
        </div>
        <!-- end col -->
    </div>

</asp:Content>
