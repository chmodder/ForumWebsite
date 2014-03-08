﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" Runat="Server">

    <ol class="breadcrumb">
        <li><a href="Default.aspx">Home</a></li>

                <li class="active"><%=CatName %></li>


    </ol>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <a href='CreateThread.aspx?CatId=<%= QsId %>' class="btn btn-default">Opret Tråd</a>
    

    <hr />

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title"><%=CatName %></h3>
        </div>
        <div class="panel-body">
            <h5 class="col-xs-6">Tråde</h5>
            <h5 class="col-xs-1">Indlæg</h5>
            <h5 class="col-xs-1"></h5><!--"Visninger" (planlagt til v.1.1)-->
            <h5 class="col-xs-4"></h5><!--"Sidste indlæg" (planlagt til v.1.1)-->



            <asp:Repeater ID="ThreadRpt" runat="server">

                <ItemTemplate>
                    <div class="panel-body">
                        <hr />
                        <a href="Thread.aspx?Model=Thread&Id=<%# Eval ("ThreadId") %>" class="col-xs-6"><%# Eval ("ThreadName") %></a>
                        <span class="col-xs-1"><%# Eval ("NumberOfPosts") %></span>
                        <span class="col-xs-1"></span><!--her skal antallet af visninger stå (planlagt til v.1.1)-->
                        <span class="col-xs-3"></span><!--her skal tidspunktet for seneste indlæg stå (planlagt til v.1.1)-->
                        <a href='EditThread.aspx?Model=Thread&Id=<%# Eval ("ThreadId") %>' class="col-xs-1 glyphicon glyphicon-pencil"></a>
                        <br />
                        <span class="col-xs-6"></span><!--her skal forfatteren af tråden stå "Trådstarter: <%--<%# Eval ("CreatedBy") %>--%>" (planlagt til v.1.1)-->
                        <span class="col-xs-1"></span><span class="col-xs-1"></span>
                        <span class="col-xs-3"></span><!--her skal forfatteren af seneste indlæg stå "Sidste indlæg af <a href="#">brugernavn</a>" (planlagt til v.1.1)-->
                        <a href='DeleteScript.aspx?Model=Thread&Id=<%# Eval ("ThreadId") %>' class="col-xs-1 glyphicon glyphicon-trash"></a>
                        
                    </div>



                </ItemTemplate>

            </asp:Repeater>



        </div>

        <div class="panel-footer"></div>
    </div>
    
    
    <%--<table class="table table-striped">
        <tr>
            <td>hej</td>
            <td>med</td>
            <td>dig</td>
        </tr>
        <tr>
            <td>hej</td>
            <td>med</td>
            <td>dig</td>
        </tr>
        <tr>
            <td>hej</td>
            <td>med</td>
            <td>dig</td>
        </tr>
    </table>--%>
    
</asp:Content>

