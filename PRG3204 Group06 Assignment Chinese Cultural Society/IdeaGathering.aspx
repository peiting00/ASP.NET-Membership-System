<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="IdeaGathering.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.IdeaGathering" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="serSupCSS.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Poppins|DM Sans' rel='stylesheet'>
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
            </div>
           
            <div style="padding:20px;"></div>

            <div class="marginClass" style="text-align: center;">
                <asp:Label ID="Label1" style="font-size: 18px; font-family:'Poppins'" runat="server" Text="Oops! This page is still under maintenance. Please wait for further announcement. "></asp:Label>
            </div>

            <div style="padding:20px;"></div>
        </div>
        <div style="padding:20px;"></div>
    </div>
</asp:Content>
