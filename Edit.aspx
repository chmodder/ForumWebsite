<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <HeaderTemplate>
            <h1><%# Eval ("Title") %></h1>
            
        </HeaderTemplate>
        
        <ItemTemplate>
            <h1><%# Eval ("Title") %></h1>
            <%# Eval ("Content") %><br />
            
        </ItemTemplate>

    </asp:Repeater>

    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT Threads.Id AS ThreadId, Threads.Title, Posts.[Content] FROM Posts LEFT OUTER JOIN Threads ON Posts.FkThreadId = Threads.Id WHERE (Threads.Id = 1)"></asp:SqlDataSource>
</asp:Content>

