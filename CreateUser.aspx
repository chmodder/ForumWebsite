<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">

    <%-- Div-boks med fejlmeddelelse. Ikke synlig --%>
    <asp:Panel ID="PanelMsgFejl" runat="server" CssClass="alert alert-danger alert-dismissable" Visible="False">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
        <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label><%--<strong>Fejl</strong> Tjek den indtastede email.--%>
    </asp:Panel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">


    <%-- Input felter --%>
    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="CreateUserNameLbl" AssociatedControlID="CreateUserNameTxt" class="input-group-addon" runat="server" Text="Brugernavn"></asp:Label>
                <asp:TextBox ID="CreateUserNameTxt" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>

    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="CreateUserPassWordLbl" AssociatedControlID="CreateUserPassWordTxt" class="input-group-addon" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="CreateUserPassWordTxt" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>

    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="CreateUserEmailLbl" AssociatedControlID="CreateUserEmailTxt" class="input-group-addon" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="CreateUserEmailTxt" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>
    
    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="ConfirmUserEmailLbl" AssociatedControlID="ConfirmUserEmailTxt" class="input-group-addon" runat="server" Text="bekræft email"></asp:Label>
                <asp:TextBox ID="ConfirmUserEmailTxt" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>
    <hr />

    <%-- Knapper --%>
    <asp:Button ID="Discard" class="btn btn-default" runat="server" Text="Annuller" OnClick="Discard_Click" />
    <asp:Button ID="CreateUserBtn" class="btn btn-default" runat="server" Text="Gem" OnClick="CreateUserBtn_Click" />




</asp:Content>

