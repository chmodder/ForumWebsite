<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">

    <asp:Repeater ID="EditUserInfoRpt" runat="server">
        <ItemTemplate>

            <div class="row">
                <div class="col-xs-6">
                    <div class="input-group">
                        <asp:Label ID="UserNameLbl" AssociatedControlID="UserNameTxt" class="input-group-addon" runat="server" Text="Brugernavn"></asp:Label>
                        <asp:TextBox ID="UserNameTxt" runat="server" class="form-control" Text='<%# Eval ("UserName") %>'></asp:TextBox>
                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /.col-lg-6 -->
            </div>

            <br />

            <div class="row">
                <div class="col-xs-6">
                    <div class="input-group">
                        <asp:Label ID="EmailLbl" AssociatedControlID="EmailTxt" class="input-group-addon" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="EmailTxt" runat="server" class="form-control" Text='<%# Eval ("Email") %>'></asp:TextBox>
                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /.col-lg-6 -->
            </div>

            <br />

            <div class="row">
                <div class="col-xs-6">
                    <div class="input-group">
                        <asp:Label ID="UserPasswordLbl" AssociatedControlID="UserPasswordTxt" class="input-group-addon" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="UserPasswordTxt" runat="server" class="form-control" Text='<%# Eval ("UserPassword") %>'></asp:TextBox>
                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /.col-lg-6 -->
            </div>

        </ItemTemplate>
    </asp:Repeater>

    <hr />
    <asp:Button ID="Discard" class="btn btn-default" runat="server" Text="Annuller" OnClick="Discard_Click" />
    <asp:Button ID="SaveEditedUserBtn" class="btn btn-default" runat="server" Text="Gem" OnClick="SaveEditedUserBtn_Click"/>

</asp:Content>

