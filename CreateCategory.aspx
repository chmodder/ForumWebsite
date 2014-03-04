<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateCategory.aspx.cs" Inherits="CreateCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">


    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="EditCategoryNameLbl" AssociatedControlID="EditCategoryNameTxt" class="input-group-addon" runat="server" Text="Kategori Navn"></asp:Label>
                <asp:TextBox ID="EditCategoryNameTxt" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>

    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="EditCategoryDescriptionLbl" AssociatedControlID="EditCategoryDescriptionTxt" class="input-group-addon" runat="server" Text="Beskrivelse"></asp:Label>
                <asp:TextBox ID="EditCategoryDescriptionTxt" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>

    <hr />
    <asp:Button ID="Discard" class="btn btn-default" runat="server" Text="Annuler" />
    <asp:Button ID="EditCategoriesBtn" class="btn btn-default" runat="server" Text="Gem" />
<%--    <a href="#" class="btn btn-default glyphicon glyphicon-floppy-remove"></a>
    <a href="#" class="btn btn-default glyphicon glyphicon-floppy-saved"></a>--%>

</asp:Content>

