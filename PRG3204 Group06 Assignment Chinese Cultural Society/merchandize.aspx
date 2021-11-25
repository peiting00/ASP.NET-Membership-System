<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="merchandize.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.merchandize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://kit.fontawesome.com/17766c5115.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="css/updateMerchandize.css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cpHome" runat="server">
    <div id="form1">
        <div class="merchandize_wrapper">
            <div class="merchandize_container">
                <label>Product ID: </label>
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
                <br />

                <asp:SqlDataSource
                    ID="SqlDataSourceCategories"
                    runat="server"
                    ConnectionString="<%$ ConnectionStrings:databaseConstr %>"
                    SelectCommand="SELECT [categoryID], [Name] FROM [category]">
                </asp:SqlDataSource>
                <br />
                Categories:<br />
                <asp:DropDownList
                    ID="ddlCategories"
                    runat="server"
                    AutoPostBack="true"
                    DataTextField="Name"
                    DataValueField="categoryID"
                    OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:GridView
                    ID="gridViewProduct"
                    runat="server"
                    AutoGenerateColumns="False"
                    OnPageIndexChanging="gridViewProduct_PageIndexChanging"
                    AllowPaging="true" BackColor="#F4F4F4"
                    HeaderStyle-BackColor="#3E3025"
                    HeaderStyle-ForeColor="#F4F4F4"
                    HeaderStyle-Height="50px">
                    <AlternatingRowStyle BackColor="#DCD4CD" />
                    <Columns>
                        <asp:TemplateField HeaderText="Image" >
                            <ItemTemplate>
                                <asp:Image ID="prodImg" runat="server" ImageUrl='<%# Eval("imageFile", "~/images/{0}") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="productID" HeaderText="Product ID" />
                        <asp:BoundField DataField="productName" HeaderText="Name" />
                        <asp:BoundField DataField="shortDescription" HeaderText="Short Description" />
                        <asp:BoundField DataField="longDescription" HeaderText="Long Description" />
                        <asp:TemplateField HeaderText="Unit Price">
                            <ItemTemplate>
                                <asp:Label ID="label1" runat="server" Text='<%# Eval("unitPrice", "{0:c}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="inventory" HeaderText="Inventory" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" NavigateUrl='<%# "updateMerchandize.aspx?ProductID=" + Eval("productID") %>'>
                                    <i class="fas fa-edit"></i>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
