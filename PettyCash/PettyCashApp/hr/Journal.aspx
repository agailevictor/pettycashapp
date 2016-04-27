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

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <h4 class="header-title m-t-0 m-b-30">Input Types</h4>

                <div class="row">
                    <form class="form-horizontal" id="form_journal" runat="server">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Assignee*</label>
                            <div class="col-sm-10">
                                <%--                                                <select class="select2-chosen">
													<option>--- Select ---</option>
                                                    <option>Smijith</option>
                                                    <option>Sebin</option>
                                                    <option>Agaile Victor</option>
                                                    <option>Harishankar R</option>
                                                    <option>Jane Elizabeth Jose</option>
                                                </select>--%>
                                <asp:DropDownList ID="ddl_assign_user" CssClass="form-control cust" runat="server" DataTextField="Name" DataValueField="user_id" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <div class="col-sm-5">
                                    <div class="col-sm-5">
                                        <div class="col-sm-2">
                                            <button class="btn btn-success btn-bordred waves-effect w-md waves-light m-b-5" type="button">Success</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>

                </div>
                <!-- end row -->
            </div>
        </div>
        <!-- end col -->
    </div>
    <!-- end row -->

</asp:Content>
