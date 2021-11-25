<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="viewResponse.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.viewResponse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="serSupCSS.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet'>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpHome" runat="server">
   
    <div class="divBody">
        <div style="padding:40px;"></div>

        <div class="divServiceContentContain">
            <div class="divHeader">
                <asp:Label ID="lblHeader" class="header" runat="server" />
            </div>

            <div style="padding:20px;">
                <asp:Button ID="btnBack" CssClass=" btnInsertFAQ dropShadow" runat="server" Text="Back" OnClick="btnBack_Click" />
                <br />
                <br />
                <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
                    <EmptyDataTemplate>
                        No data was returned.
                    </EmptyDataTemplate>
                    <ItemSeparatorTemplate>
                        <br />
                    </ItemSeparatorTemplate>
                    <ItemTemplate>
                        <li style="">
                            <asp:Label ID="feedBackResponseLabel" runat="server" Text='<%# Eval("feedBackResponse") %>' />
                            <br />
                        </li>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <ul id="itemPlaceholderContainer" runat="server" style="">
                            <li runat="server" id="itemPlaceholder" />
                        </ul>
                        <div style="">
                        </div>
                    </LayoutTemplate>
                    </asp:ListView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:databaseConstr %>" SelectCommand="SELECT [feedBackResponse] FROM [feedbackFromUser]"></asp:SqlDataSource>
            </div>

            <div style="padding:10px;"></div>
        </div>
        <div style="padding:100px;"></div>
    </div>
    
</asp:Content>
