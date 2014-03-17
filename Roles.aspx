<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">

    <asp:SqlDataSource runat="server" ID="DataSourceDropDownList" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="GetRolesSP" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:DropDownList ID="RolesDdl" AutoPostBack="true" CssClass="form-control" runat="server" DataSourceID="DataSourceDropDownList" DataTextField="RoleName" DataValueField="Id">
        <asp:ListItem>2</asp:ListItem>
    </asp:DropDownList>

    <hr />

<%--    <asp:SqlDataSource runat="server" ID="DataSourceCheckList" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="GetAllPrivilegesSP" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>

    <asp:CheckBoxList ID="PrivilegesCbl" runat="server" DataTextField="Privilege" DataValueField="Id">
        <asp:ListItem></asp:ListItem>
    </asp:CheckBoxList>




    <asp:Button ID="UpdateRoleBtn" runat="server" Text="Gem" OnClick="UpdateRoleBtn_Click" />
</asp:Content>

