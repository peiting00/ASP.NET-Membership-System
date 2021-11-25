<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/style.css" />
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="cpHome" runat="server">
    <div id="form1" class="form-product">
        <div class="product_wrapper">
            <div class="product_container">
                <asp:DataList ID="dlProduct" runat="server">
                    <ItemTemplate>
                        <table class="tb_product">
                            <tr>
                                <td>
                                    <asp:Image ID="imgProduct" Width="350px" Height="300px" runat="server" ImageUrl='<%# Eval("imageFile", "~/images/{0}") %>' />
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
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("longDescription") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnBackCat" runat="server" OnClick="btnBackCat_Click" Text="E-Catalogue" />
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <div class="btnViewCart">
                    <asp:Button ID="btnViewCart" runat="server" OnClick="btnViewCart_Click" Text="View Cart" />
                </div>
                <br />
                <asp:Label ID="lblItem" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
