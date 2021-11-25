<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="eventActivities.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.eventActivities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="serSupCSS.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Poppins|DM Sans' rel='stylesheet'>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpHome" runat="server">
    <div class="divBody">
        <div class ="divSpacing"></div>

        <div class="divfloatingIdea dropShadow">
            <asp:Panel ID="panelIdea" runat="server">
                <asp:Label ID="hypLinkToIdeaSubmit" CssClass="linkToIdea" runat="server"></asp:Label>
                
            </asp:Panel>
        </div>

        <div class="divEventContainer">
            <div class="divHeader">
                <asp:Label ID="lblHeader" class="header" runat="server" />
            </div>

            <div style ="padding: 20px"></div>

            <div class="marginClass">
                <asp:Panel ID="panelEvent" runat="server"></asp:Panel>
            </div>
           
            <div style="padding:20px;"></div>
        </div>

        <div style="padding:20px;"></div>
    </div>
</asp:Content>
