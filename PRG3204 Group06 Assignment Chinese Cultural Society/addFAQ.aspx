<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="addFAQ.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.addFAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="serSupCSS.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet'>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 272px;
        }
        .auto-style3 {
            width: 272px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpHome" runat="server">
    <div class="divBody">
        <div style="padding:20px;"></div>

        <div class="divServiceContentContain">
            <div class="divHeader">
                <asp:Label ID="lblHeader" class="header" runat="server" />
            </div>

            <div style="padding:20px;">
                <asp:Button ID="btnBack" CssClass=" btnInsertFAQ dropShadow" runat="server" Text="Back" OnClick="btnBack_Click" />
            </div>

            <div style="padding:10px;"></div>

            <div class="tableInsert">
                <table class="tableStyle marginClass">
                    <tr>
                        <td class="tableColTitle">
                            <asp:Label ID="lblQuesDesc" CssClass="lblStyle" runat="server" Text="Question Description : "></asp:Label>
                        </td>
                        <td class="tablecolBox">
                            <asp:TextBox ID="txtFAQDesc" class="txtStyle" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            &nbsp
                        </td>
                    </tr>

                    <tr>
                        <td class="tableColTitle">
                            <asp:Label ID="lblAnsFAQ" CssClass="lblStyle" runat="server" Text="Answer : "></asp:Label>
                        </td>
                        <td class="tablecolBox">
                            <asp:TextBox ID="txtFAQAns" class="txtStyle" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div> 

            <div class="btnRight" style="padding:20px;">
                <asp:Button ID="btnAddFAQ" class="btnInsertFAQ dropShadow" runat="server" OnClick="btnAddFAQ_Click" Text="Add" />
            </div>
        </div>

        <div style="padding:20px;"></div>
    </div>
</asp:Content>
