<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

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
                        <asp:Label ID="UserPasswordLbl" AssociatedControlID="UserPasswordTxt" class="input-group-addon" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="UserPasswordTxt" runat="server" class="form-control" Text='<%# Eval ("UserPassword") %>'></asp:TextBox>
                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /.col-lg-6 -->
            </div>

    <hr />
    <asp:Button ID="Discard" class="btn btn-default" runat="server" Text="Annuller" OnClick="Discard_Click" />
    <asp:Button ID="LoginBtn" class="btn btn-default" runat="server" Text="Udfør" OnClick="LoginBtn_Click"/>

</asp:Content>

