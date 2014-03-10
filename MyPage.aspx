<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyPage.aspx.cs" Inherits="MyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">

    <div class="btn-group">
        <asp:Button ID="EditUserBtn" class="btn btn-default" runat="server" OnClick="EditUserBtn_Click" Text="Rediger brugerprofil" />
        <asp:Button ID="DeleteUserBtn" class="btn btn-default" runat="server" OnClick="DeleteUserBtn_Click" Text="Slet bruger" />
    </div>

    <hr />

    <asp:Repeater ID="MyInfoRpt" runat="server">
        <ItemTemplate>

            
            <div class="row">
                <div class="col-xs-6">
                    <div class="input-group">
                        <asp:Label ID="UserNameLbl" AssociatedControlID="UserNameLblTxt" class="input-group-addon" runat="server" Text="Brugernavn"></asp:Label>
                        <asp:Label ID="UserNameLblTxt" runat="server" class="form-control" Text='<%# Eval ("UserName") %>'></asp:Label>
                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /.col-lg-6 -->
            </div>

            <br />

            <div class="row">
                <div class="col-xs-6">
                    <div class="input-group">
                        <asp:Label ID="EmailLbl" AssociatedControlID="EmailLblTxt" class="input-group-addon" runat="server" Text="Email"></asp:Label>
                        <asp:Label ID="EmailLblTxt" runat="server" class="form-control" Text='<%# Eval ("Email") %>'></asp:Label>
                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /.col-lg-6 -->
            </div>

            <br />

            <div class="row">
                <div class="col-xs-6">
                    <div class="input-group">
                        <asp:Label ID="RoleNameLbl" AssociatedControlID="RoleNameLblTxt" class="input-group-addon" runat="server" Text="Brugerrolle"></asp:Label>
                        <asp:Label ID="RoleNameLblTxt" runat="server" class="form-control" Text='<%# Eval ("RoleName") %>'></asp:Label>
                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /.col-lg-6 -->
            </div>

        </ItemTemplate>
    </asp:Repeater>
  
</asp:Content>

