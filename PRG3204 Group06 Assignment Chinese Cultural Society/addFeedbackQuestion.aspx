<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="addFeedbackQuestion.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.addFeedbackQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="serSupCSS.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet'>
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
                            <asp:TextBox ID="txtFeedQuesDesc" class="txtStyle" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td colspan="2">
                            &nbsp
                        </td>
                    </tr>
                </table>
            </div> 

            <div class="btnRight" style="padding:20px;">
                <asp:Button ID="btnAddFeedQuestion" class="btnInsertFAQ dropShadow" runat="server" OnClick="btnAddFeedQuestion_Click" Text="Add" />
            </div>
        </div>

        <div style="padding:20px;"></div>
    </div>
</asp:Content>
