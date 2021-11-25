<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="myOrder.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.myOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/order.css" />
    <script src="https://kit.fontawesome.com/17766c5115.js" crossorigin="anonymous"></script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cpHome" runat="server">
    <div id="form1">
        <div class="gv_wrapper">
            <asp:Label ID="lblUsername" runat="server"></asp:Label>
            <br />
             <asp:GridView
                ID="gvOrder"
                runat="server"
                AutoGenerateColumns="False"
                OnPageIndexChanging="gridViewProduct_PageIndexChanging"
                AllowPaging="true" BackColor="#F4F4F4"
                HeaderStyle-BackColor="#3E3025"
                HeaderStyle-ForeColor="#F4F4F4" HeaderStyle-Height="50px">
                <AlternatingRowStyle BackColor="#DCD4CD" />
                <Columns>
                    <asp:BoundField DataField="orderID" HeaderText="Order ID" />
                    <asp:BoundField DataField="items" HeaderText="Items" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:TemplateField HeaderText="Payment">
                        <ItemTemplate>
                            <asp:Label ID="label1" runat="server" Text='<%# Eval("payment", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="date" HeaderText="Date Purchased" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="hlVieworder" runat="server" NavigateUrl='<%# "orderDetails.aspx?OrderID=" + Eval("orderID") %>'>
                                <i class="fas fa-external-link-alt"> Edit</i>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lbltest" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
