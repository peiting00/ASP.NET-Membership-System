<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="catalogue.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.catalogue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/style.css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cpHome" runat="server">
    <div class="form-catalogue">
        <div class="catalogue_wrapper">
            <div class="catalogue_container">
                <asp:TextBox ID="txtSearch" CssClass="search-engine" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" CssClass="search-engine" runat="server" OnClick="btnSearch_Click" Text="Search" />
                <br />
                <div class="dl_container">
                    <asp:DataList ID="dlMenu" runat="server" Width="200px">
                        <ItemTemplate>
                            <asp:HyperLink
                                ID="dlMenu"
                                runat="server"
                                NavigateUrl='<%# "catalogue.aspx?CategoryID=" + Eval("CategoryID") %>'
                                Text='<%# Eval("Name") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:DataList>

                    <asp:DataList ID="dlCategory" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" Width="885px">
                        <ItemTemplate>
                            <table class="tb_category" >
                                <tr>
                                    <td>
                                        <asp:Image ID="imgProduct" Width="250px" Height="200px" runat="server" ImageUrl='<%# Eval("imageFile", "~/images/{0}") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("unitPrice", "{0:c}") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HyperLink ID="hlProdID" CssClass="hl" runat="server" NavigateUrl='<%# "product.aspx?ProductID=" + Eval("productID") %>' Text='<%# Eval("shortDescription") %>'></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
