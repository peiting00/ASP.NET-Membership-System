<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="updateMerchandize.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.updateMerchandize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://kit.fontawesome.com/17766c5115.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="css/updateMerchandize.css" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cpHome" runat="server">
    <asp:HyperLink ID="hlBack" runat="server" NavigateUrl="~/merchandize.aspx">
        <i class="fas fa-chevron-circle-left" style="font-size:50px;padding: 0 20px"></i>
        <span  style="font-size:50px">Edit other product</span>
    </asp:HyperLink>
    <br />
    <div id="form1" runat="server">
        <div class="main_wrapper">
            <div id="btn_add" class="buttons" runat="server">
                <asp:Button ID="btnProdAdd" runat="server" Text="Add Product" OnClick="btnProdAdd_Click" />
            </div>
            <table id="editing" runat="server">
                <tr>
                    <td colspan="2" rowspan="8">
                        <asp:Image ID="imgProduct" runat="server" Width="400px" Height="350px" />
                    </td>
                    <td>
                        Product ID: </td>
                    <td class="td_input">
                        <asp:TextBox ID="txtProdID" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProdID" Display="Dynamic" ErrorMessage="Value required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Product Name:</td>
                    <td class="td_input">
                        <asp:TextBox ID="txtProdName" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProdName" Display="Dynamic" ErrorMessage="Value required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Short Description: </td>
                    <td class="td_input">
                        <asp:TextBox ID="txtShortDesc" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtShortDesc" Display="Dynamic" ErrorMessage="Value required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Long Description: </td>
                    <td class="td_input">
                        <asp:TextBox ID="txtLongDesc" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLongDesc" Display="Dynamic" ErrorMessage="Value required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Category ID:</td>
                    <td class="td_input">
                        <asp:DropDownList ID="ddlCat" runat="server">
                            <asp:ListItem Value="tools">tools</asp:ListItem>
                            <asp:ListItem Value="chess">chess</asp:ListItem>
                            <asp:ListItem Value="fan">fan</asp:ListItem>
                            <asp:ListItem Value="handkerchief">handkerchief</asp:ListItem>
                            <asp:ListItem Value="pendant">pendant</asp:ListItem>
                            <asp:ListItem Value="teaset">teaset</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Image File:</td>
                    <td class="td_input">
                        <asp:FileUpload ID="imgUploadCtrl" runat="server" CssClass="imgUpload" />
                        <br />
                        <asp:Button ID="btnUpload" runat="server" CssClass="imgUpload" OnClick="btnUpload_Click" Text="Upload" />
                        <asp:Label ID="lblImageUploaded" runat="server"></asp:Label>
                        <br />
                    </td>
                    <td>
                        <asp:Label ID="lblUploadStatus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Unit Price:</td>
                    <td class="td_input">
                        <asp:TextBox ID="txtUnitprice" runat="server" />
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtUnitprice" Display="Dynamic" ErrorMessage="Positive number is required" ValidationExpression="([0-9])[0-9]*[.]?[0-9]*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUnitprice" Display="Dynamic" ErrorMessage="Value required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        In Stock</td>
                    <td class="td_input">
                        <asp:TextBox ID="txtInventory" runat="server" />
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtInventory" Display="Dynamic" ErrorMessage="Positive interger number required" ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtInventory" Display="Dynamic" ErrorMessage="Value required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td class="td_button">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td class="td_input">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
