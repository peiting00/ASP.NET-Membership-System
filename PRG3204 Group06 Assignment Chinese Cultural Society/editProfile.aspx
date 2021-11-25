<%@ Page Title="" Language="C#" MasterPageFile="~/navMenu.Master" AutoEventWireup="true" CodeBehind="editProfile.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.editProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .image{
	height:30px;
	width:30px;
	border-radius:50%;
}
.background{
	background-image: url("images/login/Loginbackground.jpg");
	background-repeat: no-repeat;
	background-size: cover;
	background-attachment: fixed;
	margin: 0;
}

        .circleMapping{
            margin-left:20px;
            height:130px;
            width:130px;
            border-radius:50%;
        }
        .btn {
            background-color:lightskyblue;
            color: white;
            margin-top: 20px;
            height: 30px;
            width:200px;
            font-size: 12px;
        }

        .control {
            margin-top: 50px;
        }

        .top{
            margin-top:90px;
        }

        .content {
            margin-top: 50px;
            background-color: rgba(255,255,255,0.7);
        }
        .left-control-top{
            margin-top:50px;
        }

        .left-control{
            padding:15px;
            border:solid 1px;
            width:auto;
        }
        .table{
            border:solid 1px;
        }

       .padding{
           padding-bottom:100px;
       }

       .tablestyle{
           width:80%;
       }
       
       .gridviewStyle input[type=text]{ /*grid view -edit mode textbox*/
           width:120px;
       }

       .member{
           font-size:20px;
           font-weight:700; /*bold*/
       }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top content">
        <div class="row">
            <div class="col-3 control">
                <div class="left-control-top">
                   <h6 class="text-center">Menu Bar</h6>
                </div>
                <div class="left-control">
                   <h6><i class="fa fa-user"></i> <asp:LinkButton ID="myProfile" OnClick="myProfile_Click" class="text-info" runat="server" Text="My Profile" /></h6>
                </div>
                <div class="left-control">
                    <h6><i class="fa fa-address-book-o"></i> <asp:LinkButton ID="myAddress" OnClick="myAddress_Click" class="text-info" runat="server" Text="My Address" /></h6>
                </div>
                <div class="left-control">
                    <h6><i class="fa fa-id-badge"></i> <asp:LinkButton ID="myMembership" OnClick="myMembership_Click" class="text-info" runat="server" Text="My Membership" /></h6>
                </div>
            </div>

            <div class="col-9 control">
                <div>
                    <h4 class="text-center"><asp:label id="lblTitle" runat="server" /></h4>
                    <br /><br />
                    <asp:Image ID="profileImage" class=" circleMapping" runat="server" />
                    <asp:Label ID="lblMember" Text="CCS Member | " CssClass="text-black member" runat="server" />
                    <asp:Label ID="lblLastVisit"  runat="server" CssClass="member" />
                    <br /><br />
                    
                    <div id="profile" runat="server">
                        <table class="table table-hover abc" runat="server">
                                    <tr >
                                        <td>Email</td>
                                        <td><asp:Label ID="lblEmail" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td>First Name</td>
                                        <td><asp:textbox id="txtFirstName" BackColor="transparent"  ReadOnly="true" runat="server" BorderStyle="None" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Last Name</td>
                                        <td><asp:textbox id="txtLastName" BackColor="transparent"  ReadOnly="true" runat="server" BorderStyle="None"    />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Phone</td>
                                        <td><asp:textbox id="txtPhone" BackColor="transparent" runat="server" ReadOnly="true" BorderStyle="None" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Please provide valid Malaysia number!" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^(\+?6?01)[0-46-9]-*[0-9]{7,8}$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Gender</td>
                                        <td><asp:textbox id="txtGender" BackColor="transparent" runat="server" ReadOnly="true" BorderStyle="None" />
                                            <asp:RadioButtonList ID="rbGender" Visible="false" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="M" Selected="True">Male</asp:ListItem>
                                                <asp:ListItem Value="F">Female</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Course ID</td>
                                        <td><asp:textbox id="txtCourse" BackColor="transparent" runat="server" ReadOnly="true" BorderStyle="None" />
                                            <asp:DropDownList ID="ddlCourse" Visible="false" class="custom-select ddlsetting" runat="server" DataSourceID="sdsCourse" DataTextField="courseName" DataValueField="courseID"></asp:DropDownList>
                                            <br />
                                            <asp:SqlDataSource ID="sdsCourse" runat="server" ConnectionString="<%$ ConnectionStrings:databaseConstr %>" SelectCommand="SELECT * FROM [course]"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Faculty ID</td>
                                        <td><asp:textbox id="txtFaculty" BackColor="transparent" runat="server" ReadOnly="true" BorderStyle="None" />
                                            <asp:DropDownList ID="ddlFaculty" visible="false" class="custom-select ddlsetting" runat="server" DataSourceID="sdsFaculty" DataTextField="facultyName" DataValueField="facultyID">
                                            </asp:DropDownList>
                                                <br />
                                            <asp:SqlDataSource ID="sdsFaculty" runat="server" ConnectionString="<%$ ConnectionStrings:databaseConstr %>" SelectCommand="SELECT * FROM [faculty]"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Profile Image</td>
                                        <td><asp:textbox ID="txtProfile"  BackColor="transparent" runat="server" ReadOnly="true" BorderStyle="None"/>
                                            <asp:FileUpload ID="fuImage" Visible="false" class="form-control-file" runat="server" />
                                            <asp:Label ID="lblImageError" runat="server" visible="False" ForeColor="Red"/>
                                        </td>
                                    </tr>
                         </table>
                                <div class="padding">
                                    <asp:Button Text="Edit" ID="btnEdit" CssClass="btn" OnClick="btnEdit_Click" runat="server" />
                                     <asp:Button Text="Update" ID="btnUpdate" Visible="false" CssClass="btn" OnClick="btnUpdate_Click" runat="server" />
                                </div>
                    </div><%--END OF PROFILE--%> 


                    <div id="address" runat="server">
                        <asp:GridView ID="GridView1" runat="server" class="table table-hover" AutoGenerateColumns="False" DataKeyNames="addressID" DataSourceID="sdsAddress">
                            <Columns>
                                <asp:BoundField DataField="addressLine_1" HeaderText="Address Line 1" SortExpression="addressLine_1" />
                                <asp:BoundField DataField="addressLine_2" HeaderText="Address Line 2" SortExpression="addressLine_2" />
                                <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                <asp:BoundField DataField="postcode" HeaderText="Postcode" SortExpression="postcode" />
                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            </Columns>
                            <EditRowStyle CssClass="gridviewStyle" />
                        </asp:GridView>

                        <asp:SqlDataSource ID="sdsAddress" runat="server"  ConnectionString="<%$ ConnectionStrings:databaseConstr %>" DeleteCommand="DELETE FROM [address] WHERE [addressID] = @original_addressID AND [addressLine_1] = @original_addressLine_1 AND [addressLine_2] = @original_addressLine_2 AND [city] = @original_city AND [state] = @original_state AND [postcode] = @original_postcode" InsertCommand="INSERT INTO [address] ([addressLine_1], [addressLine_2], [city], [state], [postcode]) VALUES (@addressLine_1, @addressLine_2, @city, @state, @postcode)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [addressID], [addressLine_1], [addressLine_2], [city], [state], [postcode] FROM [address] WHERE ([userEmail] = @userEmail)" UpdateCommand="UPDATE [address] SET [addressLine_1] = @addressLine_1, [addressLine_2] = @addressLine_2, [city] = @city, [state] = @state, [postcode] = @postcode WHERE [addressID] = @original_addressID AND [addressLine_1] = @original_addressLine_1 AND [addressLine_2] = @original_addressLine_2 AND [city] = @original_city AND [state] = @original_state AND [postcode] = @original_postcode">
                            <DeleteParameters>
                                <asp:Parameter Name="original_addressID" Type="Int32" />
                                <asp:Parameter Name="original_addressLine_1" Type="String" />
                                <asp:Parameter Name="original_addressLine_2" Type="String" />
                                <asp:Parameter Name="original_city" Type="String" />
                                <asp:Parameter Name="original_state" Type="String" />
                                <asp:Parameter Name="original_postcode" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="addressLine_1" Type="String" />
                                <asp:Parameter Name="addressLine_2" Type="String" />
                                <asp:Parameter Name="city" Type="String" />
                                <asp:Parameter Name="state" Type="String" />
                                <asp:Parameter Name="postcode" Type="Int32" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:QueryStringParameter Name="userEmail" QueryStringField="userEmail" Type="String" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="addressLine_1" Type="String" />
                                <asp:Parameter Name="addressLine_2" Type="String" />
                                <asp:Parameter Name="city" Type="String" />
                                <asp:Parameter Name="state" Type="String" />
                                <asp:Parameter Name="postcode" Type="Int32" />
                                <asp:Parameter Name="original_addressID" Type="Int32" />
                                <asp:Parameter Name="original_addressLine_1" Type="String" />
                                <asp:Parameter Name="original_addressLine_2" Type="String" />
                                <asp:Parameter Name="original_city" Type="String" />
                                <asp:Parameter Name="original_state" Type="String" />
                                <asp:Parameter Name="original_postcode" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>

                    </div>

                    <div id="membership" runat="server">
                        <table class="table table-hover " runat="server">
                                    <tr class="tablestyle">
                                        <td>Member ID</td>
                                        <td><asp:Label ID="lblMemberID" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td>Member Since</td>
                                        <td><asp:Label ID="lblMemberSince" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td>Member Valid till</td>
                                        <td><asp:Label ID="lblExpired" runat="server" /></td>
                                    </tr>
                        </table>
                    </div>
                 </div>
            </div>
        </div>
    </div>
</asp:Content>
