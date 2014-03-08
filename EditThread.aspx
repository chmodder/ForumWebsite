<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditThread.aspx.cs" Inherits="EditThread" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" runat="Server">


    <ol class="breadcrumb">
        <li><a href="Default.aspx">Home</a></li>

        <asp:Repeater ID="BreadCrumbRpt" runat="server">
            <ItemTemplate>
                <li class="active"><%# Eval ("Name") %></li>
            </ItemTemplate>
        </asp:Repeater>

    </ol>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">

    <asp:Repeater ID="EditThreadRpt" runat="server">
        <ItemTemplate>

            <div class="row">
                <div class="col-xs-6">
                    <div class="input-group">
                        <asp:Label ID="EditThreadTitleLbl" AssociatedControlID="EditThreadTitleTxt" class="input-group-addon" runat="server" Text="Overskrift"></asp:Label>
                        <asp:TextBox ID="EditThreadTitleTxt" class="form-control" runat="server" Text='<%# Eval ("Title") %>'></asp:TextBox>
                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /.col-lg-6 -->
            </div>

            <br />

            <div class="row">
                <div class="col-xs-6">
                    <div class="input-group">
                        <asp:Label ID="EditThreadContentLbl" AssociatedControlID="EditThreadContentTxt" class="input-group-addon" runat="server" Text="Indhold"></asp:Label>
                        <asp:TextBox ID="EditThreadContentTxt" class="form-control" TextMode="MultiLine" Rows="5" runat="server" Text='<%# Eval ("Content") %>'></asp:TextBox>

                    </div>
                    <!-- /input-group -->
                </div>
                <!-- /.col-lg-6 -->
            </div>

        </ItemTemplate>
    </asp:Repeater>

    <hr />
    <asp:Button ID="Discard" class="btn btn-default" runat="server" Text="Annuler" OnClick="Discard_Click" />
    <asp:Button ID="EditThreadBtn" class="btn btn-default" runat="server" Text="Gem" OnClick="EditThreadBtn_Click" />

</asp:Content>

