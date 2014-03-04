<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">

    
        <a href="CreateCategory.aspx" class="btn btn-default">Opret Kategori</a>
    

    <hr />

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Kategorier</h3>
        </div>
        <div class="panel-body">
            <h5 class="col-xs-6">Kategorier</h5>
            <h5 class="col-xs-1">Tråde</h5>
            <h5 class="col-xs-1">Indlæg</h5>
            <h5 class="col-xs-4">Sidste indlæg</h5>



            <asp:Repeater ID="CategoriesRpt" runat="server">

                <ItemTemplate>
                    <div class="panel-body">
                        <hr />
                        <a href="#" class="col-xs-6"><%# Eval ("CategoryName") %></a><span class="col-xs-1"><%# Eval ("NumberOfThreads") %></span><span class="col-xs-1"><%# Eval ("NumberOfPosts") %></span><span class="col-xs-3">Her skal der stå tidspunkt</span><a href="Edit.aspx?Id=<%# Eval ("CategoryId") %>" class="col-xs-1 glyphicon glyphicon-pencil"></a>
                        <br />
                        <span class="col-xs-6"><%# Eval ("CategoryDescription") %></span><span class="col-xs-1"></span><span class="col-xs-1"></span><span class="col-xs-3">af <a href="#">brugernavn</a></span><a href='#' class="col-xs-1 glyphicon glyphicon-trash"></a>
                        
                    </div>



                </ItemTemplate>

            </asp:Repeater>



        </div>

        <div class="panel-footer">Panel footer</div>
    </div>



</asp:Content>

