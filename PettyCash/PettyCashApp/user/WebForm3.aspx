<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="PettyCashApp.user.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script>
        function toggle_modal() {
            alert('toggle');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="testform">
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="modal1()" />
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        <div id="delay" class="modal fade" data-width="760">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="modal-title">Attention !</h4>
                    </div>
                    <div class="modal-body" id="modal-body">
                        <h4 id="mbody">Almost there sending the monthly report, do not hit refresh you will be redirected in a short period.</h4>
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>
    </form>

</asp:Content>
