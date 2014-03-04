<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Kategorier</h3>
        </div>
        <div class="panel-body">
            <h5 class="col-xs-6">Kategorier</h5><h5 class="col-xs-1">Tråde</h5><h5 class="col-xs-1">Indlæg</h5><h5 class="col-xs-4">Sidste indlæg</h5>
            
                <asp:Repeater ID="CategoriesRpt" runat="server">

                    <ItemTemplate>

                        <a href="#" class="col-xs-6">hej</a><span class="col-xs-1">med</span><span class="col-xs-1">dig,</span><span class="col-xs-4">champ</span>

                    </ItemTemplate>

                </asp:Repeater>

                
        </div>

        <div class="panel-footer">Panel footer</div>
    </div>



</asp:Content>

