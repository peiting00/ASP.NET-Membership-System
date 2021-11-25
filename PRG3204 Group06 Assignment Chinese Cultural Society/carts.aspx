<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="carts.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.carts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/style.css" />
    <script src="https://kit.fontawesome.com/17766c5115.js" crossorigin="anonymous"></script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cpHome" runat="server">
    <div id="form1" >
        <div class="cart_wrapper">
            <br />
            <div class="cart_container">
                <asp:Button ID="btnBackCat" runat="server" Text="E-Catalogue" OnClick="btnBackCat_Click" />
                <asp:DataList ID="dlProduct" CssClass="dl_product" runat="server">
                    <ItemTemplate>
                        <asp:Label ID="lblStoreProdID" runat="server" Text='<%# Eval("productID") %>' Visible="false"></asp:Label>
                        <table cellpadding="0" cellspacing="0" class="tb_cart">
                            <tr>
                                <td rowspan="2" class="td_imgProduct">
                                    <asp:Image ID="imgProduct" CssClass="imgProduct" runat="server"  ImageUrl='<%# Eval("imageFile", "~/images/{0}") %>' />
                                </td>
                                <td class="td_desc-inventory td_desc">
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("longDescription") %>'></asp:Label>
                                </td>
                                <td class="td_qty-remove">
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("unitPrice", "{0:c}") %>'></asp:Label>
                                </td>
                                <td class="td_qty-remove">
                                    <asp:Label ID="Label2" runat="server" Text="Quantity"></asp:Label>
                                    <asp:TextBox ID="txtQty" runat="server" AutoPostBack="true" OnTextChanged="txtQty_TextChanged" Width="50px">1</asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="td_desc-inventory td_inventory">
                                    <asp:Label ID="lblInventory" runat="server" Text='<%# Eval("inventory") %>'></asp:Label>
                                    <asp:Label ID="Label5" runat="server" Text="item(s) in stock"></asp:Label>
                                </td>
                                <td class="td_qty-remove">
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "carts.aspx?ProductID=" + Eval("productID") %>' Text="Remove">
                                        <i class="fas fa-trash-alt"></i>
                                    </asp:HyperLink>
                                </td>
                                <td class="td_qty-remove td_exceed">
                                    <asp:Label ID="lblExceed" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <br />
            </div>
        </div>
        <div id="noItem_wrapper" class="noItem_wrapper" runat="server">
            <div class="noItem-container">
                <i class="fas fa-shipping-fast txt-noItem">
                    <span class="txt-noItem">No Item</span>
                </i>
                <br />
                <asp:Button ID="btnHome" CssClass="btn_noItem" runat="server" Text="Home"/>
                <asp:Button ID="btnCat" CssClass="btn_noItem" runat="server" Text="View Catalogue" OnClick="btnCat_Click" />
            </div>
        </div>

        <div id="summary_container" class="summary_container" runat="server">
            <table cellpadding="0" cellspacing="0" class="tb_summary">
                <tr>
                    <td colspan="2">
                        <i class="fas fa-shipping-fast"></i>
                        <asp:Label ID="Label1" runat="server" Text="Shipping Address"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <i class="fas fa-map-marker-alt"></i>
                        <asp:DropDownList Width="280px" ID="ddlAddress" runat="server"></asp:DropDownList>
                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <i class="fas fa-user"></i>
                        <asp:Label ID="lblUserName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <i class="fas fa-phone"></i>
                        <asp:Label ID="lblPhone" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <i class="fas fa-envelope-open-text"></i>
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width:100%; height: 1.5px; background: grey; padding: 0"></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label3" runat="server" Text="Order Summary"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal"></asp:Label>
                    </td>
                    <td class="td_summary-text-left">
                        <asp:Label ID="lblSubtotalPrice" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Discount (10%)
                    </td>
                    <td class="td_summary-text-left">
                        <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Shipping Fee</td>
                    <td class="td_summary-text-left">
                        <asp:Label ID="lblShippingfee" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width:100%; height: 1.5px; background: grey; padding: 0"></td>
                </tr>
                <tr>
                    <td>
                        Total</td>
                    <td class="td_summary-text-left">
                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="td_btnPlaceorder">
                        <asp:Button ID="btnPlaceorder" runat="server" Text="Place Order" OnClick="btnPlaceorder_Click" />
                    </td>
                </tr>
            </table>
        </div>
            <asp:Label ID="lbltest" runat="server"></asp:Label>
    </div>
</asp:Content>

