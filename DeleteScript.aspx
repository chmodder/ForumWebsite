<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteScript.aspx.cs" Inherits="DeleteScript" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">

    <asp:Label ID="WarningLbl" class="alert alert-warning" runat="server" Text="">Er du sikker på, at du vil slette "<%=ModelTitleText%>"?</asp:Label>

    <hr />

    <asp:Button ID="Discard" class="btn btn-default" runat="server" Text="Annuller" OnClick="Discard_Click" />
    <asp:Button ID="ContinueDeletetion" CssClass="btn btn-danger" runat="server" Text="Ja, slet du bare løs" OnClick="ContinueDeletetion_Click" />


</asp:Content>
