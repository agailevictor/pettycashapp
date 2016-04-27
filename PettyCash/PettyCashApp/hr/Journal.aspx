<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Journal.aspx.cs" Inherits="PettyCashApp.hr.Journal" MasterPageFile="~/hr/hr.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cust{

    width:30%;

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
            <h4 class="page-title">Journal Validation</h4>
        </div>
    </div>

</asp:Content>
