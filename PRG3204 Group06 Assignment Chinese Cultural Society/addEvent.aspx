<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="addEvent.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.addEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="serSupCSS.css" rel="stylesheet" type="text/css" />
    <link href="ccsWeb.css" rel="stylesheet" type="text/css" />
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

            <div class="marginClass">
                <table class="tableEventss">
                    <tr>
                        <td class="tdHeaderEvent"><asp:Label class="lblHeaderEvent" runat="server" Text="Event Name : " /></td>
                        <td class="tdContentEventt"> <asp:TextBox CssClass="txtEvents"  ID="txtEventName" runat="server" /></td> 
                    </tr>

                    <tr><td>&nbsp</td></tr>

                    <tr class="">
                        <td class="tdHeaderEvent"><asp:Label class="lblHeaderEvent" runat="server" Text="Event Type : " /></td>
                        <td class="tdContentEventt"> 
                            <asp:DropDownList  class="ddlEventStyle"  ID="ddlEventType" runat="server">
                                <asp:ListItem>Normal Event</asp:ListItem>
                                <asp:ListItem>Competition</asp:ListItem>
                            </asp:DropDownList> <br/>
                        </td> 
                    </tr>

                     <tr><td>&nbsp</td></tr>

                    <tr class="">
                        <td class="tdHeaderEvent"><asp:Label class="lblHeaderEvent" runat="server" Text="Date & time : " /></td>
                        <td class="tdContentEventt"> <asp:TextBox CssClass="txtEvents" ID="txtDateTime" placeholder="DD/MM/YYYY hh:mm:ss" runat="server" />  <br/> </td>
                    </tr>

                    <tr><td>&nbsp</td></tr>

                    <tr class="">
                        <td class="tdHeaderEvent"><asp:Label class="lblHeaderEvent" runat="server" Text="Duration (hours) : " /></td>
                        <td class="tdContentEventt"> <asp:TextBox CssClass="txtEvents"  ID="txtDuration" TextMode="Number" runat="server" />  <br/> </td>
                    </tr>

                    <tr><td>&nbsp</td></tr>

                    <tr class="">
                        <td class="tdHeaderEvent"><asp:Label class="lblHeaderEvent" runat="server" Text="Description : " /></td>
                        <td class="tdContentEventt"> <asp:TextBox CssClass="txtEvents"  ID="txtDescription" TextMode="MultiLine" runat="server" />  <br/> </td>
                    </tr>

                    <tr><td>&nbsp</td></tr>

                    <tr class="">
                        <td class="tdHeaderEvent"><asp:Label class="lblHeaderEvent" runat="server" Text="Attached Files : " /></td>
                        <td class="tdContentEventt"> <asp:FileUpload CssClass="txtEvents"  ID="fileUploadEventFile" runat="server" />  <br/> </td>
                    </tr>
                    
                    <tr><td>&nbsp</td></tr>

                    <tr class="">
                        <td class="tdHeaderEvent"><asp:Label class="lblHeaderEvent" runat="server" Text="Event Fees : " /></td>
                        <td class="tdContentEventt"> <asp:TextBox CssClass="txtEvents"  ID="txtEventFee" TextMode="Number" runat="server" />  <br/> </td>
                    </tr>

                    <tr><td>&nbsp</td></tr>

                    <tr class="">
                        <td><asp:Label class="lblHeaderEvent" runat="server" Text="Event Poster : " /></td>
                        <td class="tdContentEventt"> <asp:FileUpload CssClass="txtEvents"  ID="fileUploadPoster" runat="server" /> </td>
                    </tr>
                </table>

                <asp:Label ID="lblStatus" CssClass="lblErrorMsg" runat="server"></asp:Label>

                <div class="btnRight" style="padding:20px;">
                    <asp:Button ID="btnAddFAQ" class="btnInsertFAQ dropShadow" runat="server" Text="Add" OnClick="btnAddFAQ_Click" />
                </div>
            </div>
            <div style="padding:20px;"></div>
        </div>

        <div style="padding:20px;"></div>
    </div>
</asp:Content>

