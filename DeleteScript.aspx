<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteScript.aspx.cs" Inherits="DeleteScript" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <asp:Label ID="WarningLbl" class="alert alert-warning" runat="server" Text="">Er du sikker på, at du vil slette "<%=ModelTitleText%>"?</asp:Label>

    <hr />

    <asp:Button ID="ContinueDeletetion" runat="server" Text="Ja, slet du bare løs" OnClick="ContinueDeletetion_Click" />
</asp:Content>
