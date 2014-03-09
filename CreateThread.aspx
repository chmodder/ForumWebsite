<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateThread.aspx.cs" Inherits="CreateThread" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubmenuPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">


    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="CreateThreadTitleLbl" AssociatedControlID="CreateThreadTitleTxt" class="input-group-addon" runat="server" Text="Overskrift"></asp:Label>
                <asp:TextBox ID="CreateThreadTitleTxt" class="form-control" runat="server"></asp:TextBox>
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>

    <br />

    <div class="row">
        <div class="col-xs-6">
            <div class="input-group">
                <asp:Label ID="CreateThreadContentLbl" AssociatedControlID="CreateThreadContentTxt" class="input-group-addon" runat="server" Text="Indhold"></asp:Label>
                <asp:TextBox ID="CreateThreadContentTxt" class="form-control" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
                
            </div>
            <!-- /input-group -->
        </div>
        <!-- /.col-lg-6 -->
    </div>
    
    <hr />
    <asp:Button ID="Discard" class="btn btn-default" runat="server" Text="Annuler" OnClick="Discard_Click" />
    <asp:Button ID="CreateThreadBtn" class="btn btn-default" runat="server" Text="Gem" OnClick="CreateThreadBtn_Click" />

</asp:Content>

