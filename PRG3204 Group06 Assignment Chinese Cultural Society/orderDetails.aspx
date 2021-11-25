<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="orderDetails.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.orderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://kit.fontawesome.com/17766c5115.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="css/orderDetail.css" />
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cpHome" runat="server">
    <div id="form1">
        <div class="detail_wrapper">
            <div class="detail_container">
                <asp:DataList ID="dlProduct" CssClass="dl_product" runat="server">
                    <ItemTemplate>
                        <asp:Label ID="lblStoreProdID" runat="server" Text='<%# Eval("productID") %>' Visible="false"></asp:Label>
                        <table cellpadding="0" cellspacing="0" class="tb_product">
                            <tr>
                                <td class="td_imgProduct">
                                    <asp:Image ID="imgProduct" width="150px" Height="150px" CssClass="imgProduct" runat="server"  ImageUrl='<%# Eval("imageFile", "~/images/{0}") %>' />
                                </td>
                                <td class="td_desc">
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("longDescription") %>'></asp:Label>
                                </td>
                                <td class="td_price">
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("unitPrice", "{0:c}") %>'></asp:Label>
                                </td>
                                <td class="td_qty">
                                    <asp:Label ID="Label2" runat="server" Text="x "></asp:Label>
                                    <asp:Label ID="lblQty" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <br />
            </div>


            <div class="summary_container">
                <table cellpadding="0" cellspacing="0" class="tb_summary">
                    <tr>
                        <td colspan="2" class="td_title">
                            <i class="fas fa-shipping-fast"></i>
                            <asp:Label ID="Label1" runat="server" Text="Ship To"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <i class="fas fa-map-marker-alt"></i>
                            <asp:Label ID="lblAddress" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblUserName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width:100%; height: 1.5px; background: grey; padding: 0"></td>
                    </tr>
                    <tr>
                        <td colspan="2" class="td_title">
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
                    </table>
            </div>
        </div>
        <div class="buttons">
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" />
        </div>
    </div>
</asp:Content>
