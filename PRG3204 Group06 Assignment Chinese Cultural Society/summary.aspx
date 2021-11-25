<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="summary.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://kit.fontawesome.com/17766c5115.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="css/style.css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cpHome" runat="server">
    <div id="form1">
        <div id="noItem_wrapper" class="noItem_wrapper " runat="server">
            <div class="noItem-container lastpage-container">
                 <i class="fas fa-handshake txt-noItem txt-lastpage">
                    <span class="txt-noItem txt-lastpage">THANK YOU FOR YOUR PURCHASE!!!</span>
                </i>
                <br />
                <asp:Button ID="btnCatalogue" CssClass="btn_noItem btn_lastpage" runat="server" Text="Continue Shopping" OnClick="btnCatalogue_Click" />
                <asp:Button ID="btnVieworder" CssClass="btn_noItem btn_lastpage" runat="server" Text="My Order" OnClick="btnVieworder_Click" />
            </div>
        </div>
    </div>
</asp:Content>
