<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="edit_journal.aspx.cs" Inherits="PettyCashApp.user.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function success_update() {
            swal({
                title: 'Success!',
                text: 'Entry updated successfully!',
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
        function error_update() {
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
        function texbox_hide()
        {
            if(type_lbl=="Deposit")
            {

            }
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
            <h4 class="page-title">Edit Journal Entry</h4>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="card-box">
                <form id="journal_edit" runat="server">
                    <div class="form-group">
                        <label for="date">Date *</label>
                        <asp:TextBox ID="txtdate" runat="server" placeholder="Enter Date" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="receiptno">Receipt No *</label>
                        <asp:TextBox ID="txtrcpt" runat="server" placeholder="Enter Receipt No" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="type">Type</label>
                        <asp:Label ID="type_lbl" runat="server" Text="" CssClass="form-control"></asp:Label>
                    </div>
                    <div id="iname" class="form-group" runat="server">
                        <label for="item_name">Item Name *</label>
                        <asp:TextBox ID="item_name1" placeholder="Enter item" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div id="price" class="form-group" runat="server">
                        <label for="price">Price *</label>
                        <asp:TextBox ID="price1" runat="server" placeholder="Enter price" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div id="amnt" class="form-group" runat="server">
                        <label for="amount">Amount *</label>
                        <asp:TextBox ID="txtamount" placeholder="Enter amount" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div id="desc" class="form-group" runat="server">
                        <label for="desc">Description (Optional)</label>
                        <asp:TextBox ID="desc1" runat="server" CssClass="form-control item_desc" placeholder="Enter Description" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">                              
                                <asp:CheckBox ID="bill_new" runat="server" ClientIDMode="Static" />
                                <label for="bill_nw_lbl">Click here to upload Bill</label>
                            </div>
                        </div>
                    </div>
                    <div id="bill_up" class="row hidden">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="bill_up">Bill Upload</label>
                                <asp:FileUpload ID="bill_upload" runat="server" ClientIDMode="Static"/>
                                <small>Allowed File Type: PDF</small>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">                              
                                <asp:CheckBox ID="vhr_new" runat="server" ClientIDMode="Static" />
                                <label for="vhr_nw_lbl">Click here to upload Voucher</label>
                            </div>
                        </div>
                    </div>
                    <div id="vhr_up" class="row hidden">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="vfp">Voucher Upload</label>
                                <asp:FileUpload ID="vhr_upload" runat="server" ClientIDMode="Static"/>
                                <small>Allowed File Type: PDF</small>
                            </div>
                        </div>
                    </div>

                    <div class="form-group text-right m-b-0">
                        <asp:Button ID="btnadd_editentry" runat="server" Text="Update" CssClass="btn btn-primary" ClientIDMode="Static" OnClick="btnadd_editentry_Click" OnClientClick="edit_vali()" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
