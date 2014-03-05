<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateCategory.aspx.cs" Inherits="CreateCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">


    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="CreateCategoryNameLbl" AssociatedControlID="CreateCategoryNameTxt" class="input-group-addon" runat="server" Text="Kategori Navn"></asp:Label>
                <asp:TextBox ID="CreateCategoryNameTxt" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>

    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="CreateCategoryDescriptionLbl" AssociatedControlID="CreateCategoryDescriptionTxt" class="input-group-addon" runat="server" Text="Beskrivelse"></asp:Label>
                <asp:TextBox ID="CreateCategoryDescriptionTxt" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>

    <hr />
    <asp:Button ID="Discard" class="btn btn-default" runat="server" Text="Annuler" OnClick="Discard_Click" />
    <asp:Button ID="CreateCategoriesBtn" class="btn btn-default" runat="server" Text="Gem" OnClick="CreateCategoriesBtn_Click" />

</asp:Content>

