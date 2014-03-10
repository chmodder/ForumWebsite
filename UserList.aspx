<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">

    <asp:Repeater ID="UserListRpt" runat="server">
        <ItemTemplate>
            <asp:Label ID="UserNameLbl" runat="server" Text='<%# Eval ("UserName") %>'></asp:Label>
            <asp:Label ID="RoleNameLbl" runat="server" Text='<%# Eval ("RoleName") %>'></asp:Label>
            <a href='DeleteScript.aspx?Model=User&Id=<%# Eval ("UserId") %>'>Slet bruger</a>
            <a href='EditUser.aspx?Model=User&Id=<%# Eval ("UserId") %>'>Rediger bruger</a>
            <hr />
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

