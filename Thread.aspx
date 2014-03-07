<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Thread.aspx.cs" Inherits="Thread" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">

    <ol class="breadcrumb">
        <li><a href="Default.aspx">Home</a></li>
        <li><a href='#<%--Category.aspx?Id=<%=QsId %>--%>'>Library</a></li>

        <asp:Repeater ID="TitleRpt" runat="server">
            <ItemTemplate>
                <li class="active"><%# Eval ("Title") %></li>
            </ItemTemplate>
        </asp:Repeater>
    </ol>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">



    <table class="table table-striped">

        <asp:Repeater ID="PostsRpt" runat="server">
            <ItemTemplate>

                <tr>
                    <th><%# Eval ("PostAuthor") %></th>
                    <th><%# Eval ("PostCreationTime") %><span class="pull-right">hej</span></th>
                </tr>
                <tr>
                    <td><span class=""><%# Eval ("RoleName") %></span></td>
                    <td><%# Eval ("Content") %></td>
                </tr>

            </ItemTemplate>
        </asp:Repeater>


    </table>

    <hr />
        

    <div class="col-xs-6">
        <textarea class="form-control" rows="5"></textarea>
        <hr />
        <a href="#" class="btn btn-default">Gem svar</a>
    </div>
</asp:Content>

