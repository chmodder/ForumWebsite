<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">

    <asp:HyperLink ID="CreateCategoryLink" runat="server" NavigateUrl='CreateCategory.aspx' class="btn btn-default" Visible='<%# Per.Allowed("CreateCategory") %>'>Opret Kategori</asp:HyperLink>

    <%--<a id="CreateCategoryLink" runat="server" visible="false" href="CreateCategory.aspx" class="btn btn-default">Opret Kategori</a>--%>


    <hr id="CreateCategoryLinkSeparator" runat="server" Visible='<%# Per.Allowed("CreateCategory") %>' />

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
                        <a href="Category.aspx?Id=<%# Eval ("CategoryId") %>" class="col-xs-6"><%# Eval ("CategoryName") %></a>
                        <span class="col-xs-1"><%# Eval ("NumberOfThreads") %></span>
                        <span class="col-xs-1"><%# Eval ("NumberOfPosts") %></span>
                        <span class="col-xs-3">Her skal der stå tidspunkt</span>
                        <%--<a href='EditCategory.aspx?Model=Category&Id=<%# Eval ("CategoryId") %>' class="col-xs-1 glyphicon glyphicon-pencil"></a>--%>
                        <asp:HyperLink ID="EditCategoryLink" runat="server" NavigateUrl='<%#"EditCategory.aspx?Model=Category&Id=" + Eval ("CategoryId") %>' class="col-xs-1 glyphicon glyphicon-pencil" Visible='<%# Per.Allowed("EditCategory") %>'></asp:HyperLink>

                        <br />
                        <span class="col-xs-6"><%# Eval ("CategoryDescription") %></span>
                        <span class="col-xs-1"></span><span class="col-xs-1"></span>
                        <span class="col-xs-3">af <a href="#">brugernavn</a></span>
                        <%--<a href='DeleteScript.aspx?Model=Category&Id=<%# Eval ("CategoryId") %>' class="col-xs-1 glyphicon glyphicon-trash"></a>--%>
                        <asp:HyperLink ID="DeleteCategoryLink" runat="server" NavigateUrl='<%#"DeleteScript.aspx?Model=Category&Id=" + Eval ("CategoryId")  %>' class="col-xs-1 glyphicon glyphicon-trash" Visible='<%# Per.Allowed("DeleteCategory") %>'></asp:HyperLink>

                    </div>



                </ItemTemplate>

            </asp:Repeater>



        </div>

        <div class="panel-footer"></div>
    </div>



</asp:Content>

