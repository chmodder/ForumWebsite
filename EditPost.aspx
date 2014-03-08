﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditPost.aspx.cs" Inherits="EditPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" Runat="Server">
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
                        <a href='EditPost.aspx?Model=Post&Id=<%# Eval ("PostId") %>' class="col-xs-1 glyphicon glyphicon-pencil"></a>

                    </div>



                </ItemTemplate>

            </asp:Repeater>



        </div>

        <div class="panel-footer">
            
        </div>
    </div>



    <hr />


    <div class="col-xs-6">
        <textarea id="SubmitPostTA" class="form-control" rows="5" runat="server"></textarea>
        <hr />
        <asp:Button ID="SubmitPostBtn" class="btn btn-danger" runat="server" Text="Gem svar" />
        <asp:Button ID="DiscardBtn" class="btn btn-default" runat="server" Text="Annuller"/>
    </div>
</asp:Content>
