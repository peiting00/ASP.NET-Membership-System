<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="eventRegistration.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.eventRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="serSupCSS.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet'>
    <style type="text/css">
        .auto-style1 {
            width: 157px;
        }
        .auto-style3 {
            width: 50%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpHome" runat="server">
     <div class="divBody">
        <div class ="divSpacing"></div>
        <div class="divServiceContentContain">
            <div class="divHeader">
                <asp:Label ID="lblHeader" class="header" runat="server" />
            </div>

            <div style="padding:20px;"></div>

            <div style=" text-align: center;" class="marginClass">
                <asp:Label ID="lblEventName" CssClass="lblEventName" runat="server" />
            </div>

            <div style="padding:20px;"></div>

            <div class="marginClass">
            <div class="divEventReContainer">
                <div style="padding:20px;">
                    <asp:Button ID="btnBack" CssClass=" btnInsertFAQ dropShadow" runat="server" Text="Back" OnClick="btnBack_Click" />
                </div>
                <asp:MultiView ID="mvEventRegisterProcess" runat="server">
                    <asp:View ID="viewbasicInfoInput" runat="server">
                        <div class="divTableEventRegis">
                            <table class="auto-style3 tableRegis">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEmail" class="lblStep" runat="server" Text="Email : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" CssClass="txtRegisEvent" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td> &nbsp </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFName" class="lblStep"  runat="server" Text="First Name : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFName" CssClass="txtRegisEvent"  runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td> &nbsp </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblLName" class="lblStep"  runat="server" Text="Last Name : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLName" CssClass="txtRegisEvent"  runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                            <br/>

                            <div style ="text-align: center;"><asp:Label ID="lblStatus" CssClass="lblErrorMsg" runat="server"></asp:Label></div>
                           
                            <div style="padding:20px;"></div>

                            <div class="btnRight">
                                <asp:Button ID="btnRegister" class="btnInsertFAQ" runat="server" Text="Register" OnClick="btnRegister_Click" />
                            </div>
                        </div>
                    </asp:View>

                    <asp:View ID="viewPayment" runat="server">
                        <div>
                            <div style ="text-align: center;">
                                <asp:Label ID="lblRegistrationStatus" CssClass="lblSuccess" runat="server"></asp:Label>
                            </div>
                            <br/>
                            <div class ="divPaymentEvent dropShadow">
                                <asp:Label ID="lblFees" CssClass="" runat="server"></asp:Label>
                                <br/><br/>
                                <div class="divBtnRegisterEvent">
                                    <asp:Button ID="btnPayOnline" Style="background-color:chartreuse;" CssClass ="btnPayment" runat="server" Text="Pay Online" OnClick="btnPayOnline_Click" /> &nbsp &nbsp
                                    <asp:Button ID="btnPayBycash" style="background-color:darkorange;" CssClass="btnPayment" runat="server" Text="Pay By Cash" OnClick="btnPayBycash_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>

                
               
            </div>
            </div>
            <div style="padding:20px;"></div>
        </div>
        <div class ="divSpacing"></div>
    </div>

</asp:Content>
