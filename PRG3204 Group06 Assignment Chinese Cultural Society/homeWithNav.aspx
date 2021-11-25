<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="homeWithNav.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.homeWithNav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="homePageCSS.css" rel="stylesheet" type="text/css" />
    <link href="ccsWeb.css" rel="stylesheet" type="text/css" />
    <title>Home Page</title>
</asp:Content>

<asp:Content ID="contentHome" ContentPlaceHolderID="cpHome" runat="server">
    <div class ="headerBackground">
        <div class ="headerPlace">
            <h3>Welcome To</h3>
            <h1 class="headerTitle">INTI-IU CHINESE CULTURAL SOCIETY</h1>
        </div>
    </div>

    <div class ="divBodyHome">
        <div class ="marginLeftClass">
            <p class="paraVision">
            " Our vision is to promote Chinese Cultures among students and through our mission, 
            organizing more quality Chinese based events. "
            </p>

            <h1 class="headerHome">About Us</h1>

            <p class="paraDesc">Chinese Cultural Society (CCS) the only Chinese-based society in INTI-IU. 
                It was established with the purpose of promoting Chinese culture among INTI-IU 
                students as well as encouraging students to learn Chinese through meaningful 
                and interesting activities, reinstate the glory and splendour of Chinese traditions 
                particularly among them. Moreover CCS is aimed to produce students who are equally 
                developed intellectually, spiritually, emotionally and physically.
            </p>

            <asp:Image ID="imgHomeCalli" class="imgCenter" runat="server" />
        </div>
    </div>

    <div class ="divSpacing"></div>

    <div class ="divBodyHome">
        <div class ="marginLeftClass">
            <h1 class="headerHome">What've we organize?</h1>

            <p class="paraDesc">Our weekly activities include Diabolo, 
                Chinese Orchestra, Chinese Chess, Chinese Debate. Besides, we
                have some <a class="linkStyle" href ="eventActivities.aspx"> events and activities </a> in our club
            </p>

            <div class="divGridImg">
                <asp:Image ID="imgDiabolo" class="imgGrid" runat="server" /> 
                <asp:Image ID="imgChineseInstru" class="imgGrid" runat="server" />
                <asp:Image ID="imgDebate" class="imgGrid" runat="server" />
            </div>

            <p>
                Besides Chinese New Year Night, Chinese Cultural Society also host variety of events 
                which are related to Chinese culture such as, CNY Calligraphy Competition, Chinese Cultural Week, 
                Chinese Chess Competition, Mid-Autumn Celebration, Book Fair, summer trip as well as the 
                Youth Leadership/Motivation Camp (YLC/YMC) and much more.
            </p>
        </div>
    </div>

    <div class ="divSpacing"></div>
        
</asp:Content>

