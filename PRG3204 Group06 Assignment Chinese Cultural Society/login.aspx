<%@ Page Title="" Language="C#" MasterPageFile="~/AccountMaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="body">
        <div class="opacity">


        <!--Padding modification here-->
            <div style="padding: 68px;"></div>
        <!--Padding modification here-->


        <div class="form-block">
            <div class="form-group" >
                <br /><br /><br />
                <h3 class="align-content-center">Welcome to Chinese Cultural Society</h3>
                <asp:Label ID="lblTitle1" Text="Login to get more information and enjoy member only benefits!" runat="server" class="form-text text-muted " />
                <br />
               <asp:Image id="loginImage" class="circleMapping" ImageUrl="~/images/login/user.jpg" runat="server" AlternateText="user image" />
            </div>
            <div class="form-group" id="loginEmail" runat="server">
                <br />
                <asp:TextBox ID="txtEmail" class="form-control " runat="server" placeholder="Enter email" />
                <asp:Label ID="lblEmailHelp" Text="Use institutional email address to log in." runat="server" class="form-text text-dark float-sm-left" />
                <br />
                <asp:Label ID="lblError" class="form-text font-weight-bold" ForeColor="red" runat="server" Visible="false" />
                <asp:LinkButton ID="lb" Text="Click me to activate" OnClick="Memberactivation" ForeColor="Red" runat="server" />
                <asp:Button ID="btnContinue" Text="Continue" class="btn btn-block" runat="server" OnClick="btnContinue_Click" />
                <br /><br />
                <asp:Label ID="lblPageLink" Text="New Chinese Cultural Society member?" class="form-text text-black float-left" runat="server" />
                <asp:HyperLink ID="hlPageLink" NavigateUrl="signup.aspx"  Text="Sign Up Now" class="form-text float-left" runat="server"/>

            </div>

            <div class="form-group" id="confirmation" runat="server" visible="false">
                <h5><asp:Label ID="lblWelcome" runat="server" class="text-center"/></h5><br />
                <h5><asp:Label ID="lblRole" runat="server" /></h5><br /><br />
                <asp:Button ID="btnYES" Text="Yes, it's me" Class="btn-success" runat="server" OnClick="btnYES_Click" />
                <asp:Button ID="btnNO" Text="Not me" Class="btn-secondary" runat="server" OnClick="btnNO_Click" />
            </div>

            <div class="form-group" id="loginPassword" runat="server" >
                <asp:Label ID="lblWelcome2" runat="server" class="text-center"/><br />
                <br />
                <asp:Label ID="lblPassword" Text="Password" runat="server"/>
                <asp:TextBox ID="txtpwd"  class="form-control " TextMode="Password" runat="server" placeholder="Your password"/>
                <asp:Label ID="lblError2" class="form-text font-weight-bold" ForeColor="red" runat="server"  />
                <br />
                <asp:Button ID="btnLogin" Text="Login" class="btn btn-block" runat="server" OnClick="btnLogin_Click" />
            </div>

            <div class="form-group" id="activation" runat="server" visible="false">
                <br />
                <h6><asp:Label ID="Label2" Text="Membership Reactivation success!" runat="server" class="text-center"/></h6><br />
                <h6><asp:Label ID="lblActivate" Text="" runat="server" class="text-center"/></h6><br />
                <h6><asp:Label ID="lblActivate2" runat="server" /></h6><br /><br />
                <asp:Label ID="Label1" Text="Login again " class="form-text text-black " runat="server" />
                <asp:HyperLink ID="HyperLink1" NavigateUrl="login.aspx"  Text="Click here" class="form-text " runat="server"/>
            </div>

            
          </div>
          </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>