<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="passwordRecovery.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.passwordRecovery" %>
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

            <div style="padding:20px;">
                <asp:Button ID="btnBack" CssClass=" btnInsertFAQ dropShadow" runat="server" Text="Back" OnClick="btnBack_Click" />
            </div>

            <div style="padding:20px;"></div>

            <div class="marginClass">
                <asp:MultiView ID="mvPassRe" runat="server">
                    <asp:View ID="viewEmail" runat="server">
                        <div style="text-align: center;"><asp:Label ID="lblStep1" CssClass="lblStep lblStepColor" runat="server" /></div> <br/>
                        <asp:TextBox ID="txtEmail" CssClass="txtStyle2" runat="server" />
                        
                        <div style="padding:10px;"></div>

                        <asp:Label CssClass="lblErrorMsg" ID="lblStatusEmail" runat="server"></asp:Label>

                        <div style="padding:10px;"></div>

                        <div class="btnRight">
                            <asp:Button ID="btnNextEmail"  CssClass="btnInsertFAQ dropShadow" runat="server" Text ="Next" OnClick="btnNextEmail_Click" />
                        </div>
                    </asp:View>

                    <asp:View ID="viewQuestion" runat="server">
                        <div style="text-align: center;"><asp:Label ID="lblStep2" CssClass="lblStep lblStepColor" runat="server" /></div> <br/>
                        <div style="padding:5px;"></div>
                        
                        <div style="text-align: center;"><asp:Label ID="lblSecQues" style="font-size: 23px;" CssClass="lblStep" runat="server" /></div> <br/>                        
                        <asp:TextBox ID="txtSecurityAns" CssClass="txtStyle2" runat="server" />
                        
                        <div style="padding:10px;"></div>

                        <asp:Label CssClass="lblErrorMsg" ID="lblStatusSecQues" runat="server"></asp:Label>

                        <div class="btnRight">
                            <asp:Button ID="btnSubmitSecQues"  CssClass="btnInsertFAQ dropShadow" runat="server" Text ="Submit" OnClick="btnSubmitSecQues_Click" />
                        </div>
                    </asp:View>

                    <asp:View ID="viewResult" runat="server">
                        <div style="padding:10px;"></div>

                        <div style ="text-align: center;">
                            <asp:Label CssClass="lblRecoverStatusMsg" ID="lblRecoverStatusMsg" runat="server"></asp:Label>
                        </div>

                        <div style="padding:10px;"></div>
                        <div class="btnRight">
                            <asp:Button ID="btnConfirm"  CssClass="btnInsertFAQ dropShadow" runat="server" Text ="Confirm" OnClick="btnConfirm_Click" />
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>

            <div style="padding:20px;"></div>
        </div>

        <div class ="divSpacing"></div>
    </div>
</asp:Content>

