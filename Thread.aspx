<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Thread.aspx.cs" Inherits="Thread" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">

    <ol class="breadcrumb">
        <li><a href="Default.aspx">Home</a></li>
        <li><a href='Category.aspx?Id=<%=CatId %>'><%=CatName %></a></li>

        <asp:Repeater ID="TitleRpt" runat="server">
            <ItemTemplate>
                <li class="active"><%# Eval ("Title") %></li>
            </ItemTemplate>
        </asp:Repeater>
    </ol>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">

    <%--<a href='#' class="btn btn-default">Opret svar</a>--%>


    <hr />

    <div class="panel panel-default">
        <div class="panel-heading">

            <asp:Repeater ID="TitleRpt2" runat="server">
                <ItemTemplate>
                    <h3 class="panel-title"><%# Eval ("Title") %></h3>
                    </div>
        <div class="panel-body">
            <h5 class="col-xs-6">Tråd oprettet den <%# Eval ("CreationTime") %></h5>
                </ItemTemplate>
            </asp:Repeater>




            <asp:Repeater ID="PostsRpt" runat="server">

                <ItemTemplate>
                    <div class="panel-body">
                        <hr />
                        <span class="col-xs-3"><%# Eval ("PostAuthor") %></span>
                        <span class="col-xs-9"><%# Eval ("PostCreationTime") %></span>

                        <br />
                        <span class="col-xs-3"><%# Eval ("RoleName") %></span>
                        <span class="col-xs-8"><%# Eval ("Content") %></span>
                        <asp:HyperLink ID="EditPostLink" runat="server" NavigateUrl='<%#"EditPost.aspx?Model=Post&Id=" +  (int)Eval ("PostId") %>' class="col-xs-1 glyphicon glyphicon-pencil" Visible='<%# Per.EditPostPrivilege(Eval("PostId")) %>'></asp:HyperLink>

                    </div>



                </ItemTemplate>

            </asp:Repeater>



        </div>

        <div class="panel-footer">
            <asp:Button ID="ShowEditor" class="btn btn-default" runat="server" Text="Opret svar" OnClick="ShowEditor_Click" />
        </div>
    </div>



    <hr id="PostEditorDivider" runat="server" visible="false" />


    <div id="PostEditor" runat="server" visible="false" class="col-xs-6">
        <textarea id="SubmitPostTA" class="form-control" rows="5" runat="server"></textarea>
        <hr />
        <asp:Button ID="SubmitPostBtn" class="btn btn-default" runat="server" Text="Gem svar" OnClick="SubmitPostBtn_Click" />

    </div>
</asp:Content>

