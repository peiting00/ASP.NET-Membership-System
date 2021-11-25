<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="participantsInfo.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.participantsInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="serSupCSS.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet'>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpHome" runat="server">
    <div class="divBody">
        <div class ="divSpacing"></div>
        <div class="divServiceContentContain">
            <div class="divHeader">
                <asp:Label ID="lblHeader" class="header" runat="server" />
            </div>

            <div style="padding:20px;"></div>

            <div class="marginClass">
                <asp:Button ID="btnBack" CssClass=" btnInsertFAQ dropShadow" runat="server" Text="Back" OnClick="btnBack_Click" />
                <div style="padding:10px;"></div>
                <div style ="text-align: right; font-family: 'Poppins';">**Participants with payment will be marked as "Approved"</div>
            </div>
           
            <div style="padding:20px;"></div>


            <div class="marginClass">
                <asp:Panel ID="panelParticipants" runat="server"></asp:Panel>
            </div>

            <div style="padding:20px;"></div>
         </div>
        <div style="padding:20px;"></div>
    </div>
</asp:Content>

