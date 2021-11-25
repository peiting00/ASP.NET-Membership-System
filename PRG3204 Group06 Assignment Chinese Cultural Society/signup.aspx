<%@ Page Title="" Language="C#" MasterPageFile="~/AccountMaster.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="PRG3204_Group06_Assignment_Chinese_Cultural_Society.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .padding {
            margin-bottom: 1rem;
            height: 310px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="body" class="container " runat="server">
    <div class="opacity">
        <div class="form-block" style="text-align:left;">
            <br /><br />
            <h3 class="align-content-center">SIGN UP FOR CHINESE CULTURAL SOCIETY MEMBERSHIP</h3>
            <asp:Label ID="lblTitle1" Text="Fill all form field to go to next step. Take note that each step is not RETUNRABLE." runat="server" class="form-text text-muted " />
            <br />
            <%-- Section 1 /////// Profile Form --%>
            <div class="form-group" id="section1" runat="server">
                <div class="progress"> 
                  <div class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col">
                         <h4 class="text-primary">Profile Information</h4>
                    </div>
                    <div class="col-3">
                        <h5 class="text-secondary">Step 1 of 3 </h5>
                    </div>
                </div>
                
                <br />
                <asp:Label ID="lblEmail" runat="server" Text="Email Address" />
                <asp:TextBox ID="txtEmail" class="form-control" runat="server" Placeholder="Your Email" AutoPostBack="true" OnTextChanged="checkUniqueEmail_OnTextChanged" />
                <asp:Label ID="lblExistEmail" runat="server" ForeColor="Red" />
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email address cannot be empty!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please provide valid institutional email @student.newinti.edu.my" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@student.newinti.edu.my$" Display="Dynamic" SetFocusOnError="True" EnableViewState="False"></asp:RegularExpressionValidator>
               
                       <br />
                <asp:Label ID="lblPassword" runat="server" Text="Password" />
                <asp:TextBox ID="txtPassword"  TextMode="Password" class="form-control" runat="server" Placeholder="Your password" />
                <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password cannot be empty!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                       <br />
                <div>
                    <div class="form-row">
                        <div class="col">
                            <asp:Label ID="lblFN" runat="server" Text=" First Name" />
                            <asp:TextBox ID="txtFN" class="form-control" runat="server" Placeholder="Your First Name" />
                            <br />
                        </div>
                        <div class="col">
                            <asp:Label ID="lblLN" runat="server" Text="Last Name" />
                            <asp:TextBox ID="txtLN" class="form-control" runat="server" Placeholder="Your Last Name" />
                            <br />
                        </div>
                    </div>
                    <asp:RequiredFieldValidator ID="rfvFname" runat="server" ControlToValidate="txtFN" Display="Dynamic" ErrorMessage="First Name cannot be empty!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvLname" runat="server" ControlToValidate="txtLN" Display="Dynamic" ErrorMessage="Last Name cannot be empty!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="lblPhone" runat="server" Text="Phone" />
                <asp:TextBox ID="txtPhone" class="form-control" runat="server" Placeholder="Your phone number" />
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Phone cannot be empty!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Please provide valid Malaysia number!" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^(\+?6?01)[0-46-9]-*[0-9]{7,8}$"></asp:RegularExpressionValidator>
                        <br />
                <asp:Label ID="lblGender" runat="server" Text="Gender" />
                <asp:RadioButtonList ID="rbGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="rfvGender" ControlToValidate="rbGender" runat="server" Display="Dynamic" ErrorMessage="Please choose your gender!" ForeColor="Red" EnableClientScript="False" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <br />

                <div class="input-group-sm mb-3 ">
                    <div class="input-group-prepend">
                        <asp:Label ID="lblCourse" class="input-group-text ddlsetting" runat="server" Text="Course" />
                    </div>
                    <asp:DropDownList ID="ddlCourse" class="custom-select ddlsetting" runat="server" DataSourceID="sdsCourse" DataTextField="courseName" DataValueField="courseID"></asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="frvCourse" runat="server" ControlToValidate="ddlCourse" Display="Dynamic" ErrorMessage="Please select your course!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:SqlDataSource ID="sdsCourse" runat="server" ConnectionString="<%$ ConnectionStrings:databaseConstr %>" SelectCommand="SELECT * FROM [course]"></asp:SqlDataSource>
                </div>

                <div class="input-group-sm mb-3">
                    <div class="input-group-prepend">
                        <asp:Label ID="lblFaculty" class="input-group-text ddlsetting" runat="server" Text="Faculty" />
                    </div>
                <asp:DropDownList ID="ddlFaculty" class="custom-select ddlsetting" runat="server" DataSourceID="sdsFaculty" DataTextField="facultyName" DataValueField="facultyID">
                   
                </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="frvFaculty" runat="server" ControlToValidate="ddlFaculty" Display="Dynamic" ErrorMessage="Please select your faculty!" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="sdsFaculty" runat="server" ConnectionString="<%$ ConnectionStrings:databaseConstr %>" SelectCommand="SELECT * FROM [faculty]"></asp:SqlDataSource>
                </div>

                <asp:Label ID="lblprofileImage" runat="server" Text="Profile Image" />
                <asp:FileUpload ID="fuImage" class="form-control-file" runat="server" />
                <asp:Label ID="lblImageError" runat="server" visible="false"/>
                    <asp:RequiredFieldValidator ID="rfvImage" runat="server" ControlToValidate="fuImage" Display="Dynamic" ErrorMessage="Please select your profile image!" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                    <br />
                <asp:Button ID="btnNext"  class="btn btn-block" runat="server" Text="Next" OnClick="btnNext_Click" />
                <br /><br />
                <asp:Label ID="lblPageLink" Text="Already a Chinese Cultural Society member?" class="form-text text-black float-left" runat="server" />
                <asp:HyperLink ID="hlPageLink" NavigateUrl="login.aspx" Text="Login Now" class="form-text float-left" runat="server"/>
            </div>

            <%-- SECTION 2 //////// address form  --%>
            <div class="form-group" id="section2" runat="server" visible="false">
                <div class="progress">
                  <div class="progress-bar" role="progressbar" style="width: 75%" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col">
                         <h4 class="text-primary">Address Information</h4>
                    </div>
                    <div class="col-3">
                        <h5 class="text-secondary">Step 2 of 3 </h5>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <asp:Label ID="lblAddLine1" runat="server" Text="Address Line 1" />
                    <asp:TextBox ID="txtAddLine1" class="form-control" placeholder="Address Line 1" runat="server"/>
                    <asp:RequiredFieldValidator ID="rfvAdd1" runat="server" ControlToValidate="txtAddLine1" ErrorMessage="Address Line 1 should not be empty!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblAddLine2" runat="server" Text="Address Line 2" />
                    <asp:TextBox ID="txtAddLine2" class="form-control" placeholder="Address Line 2 " runat="server"/>
                    <asp:RequiredFieldValidator ID="rfvAddL2" runat="server" ControlToValidate="txtAddLine2" Display="Dynamic" ErrorMessage="Address Line 2 should not be empty!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </div>
               
                <div class="form-row">
                    <div class="col-7">
                      <asp:Label ID="lblCity" runat="server" Text="City" />
                      <asp:TextBox ID="txtCity" class="form-control" placeholder="City" runat="server"/>
                    </div>
                    <div class="col">
                       <asp:Label ID="lblState" runat="server" Text="State" />
                       <asp:TextBox ID="txtState" class="form-control" placeholder="State" runat="server"/>
                    </div>
                    <div class="col">
                       <asp:Label ID="lblPostcode" runat="server" Text="Postcode" />
                       <asp:TextBox ID="txtPostcode" class="form-control" placeholder="Postcode" runat="server"/>
                        <br />
                    </div>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCity" ErrorMessage="City should not be empty!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="State should ot be empty!" ForeColor="Red" ControlToValidate="txtState" Display="Dynamic"></asp:RequiredFieldValidator>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvPostcode" runat="server" ControlToValidate="txtPostcode" Display="Dynamic" ErrorMessage="Postcode should not be empty!" ForeColor="Red"></asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="rfvPostcode2" runat="server" ControlToValidate="txtPostcode" Display="Dynamic" ErrorMessage="Postcode should be 5 digit!" SetFocusOnError="True" ValidationExpression="\d{5}" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>  
                <br />
                <asp:Button ID="btnNext2" class="btn btn-block " runat="server" Text="Next" OnClick="btnNext2_Click" />
                <br /><br />
            </div>

            <%-- Secion 3 //// Security Question --%>
            <div class="form-group" id="section3" runat="server"  visible="false">
                <div class="progress">
                  <div class="progress-bar" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col">
                         <h4 class="text-primary">Security Questions</h4>
                    </div>
                    <div class="col-3">
                        <h5 class="text-secondary">Step 3 of 3 </h5>
                    </div>
                </div>
                <br />
                <asp:Label ID="lblSQTitle" runat="server" Text="Choose 3 security questions that only you can answer" /><br />
                <asp:Label CssClass="text-danger text-muted" runat="server" Text="If you forget your password, you will need to answer the security question to get your password back. " />
                <br />
                <br />
                <div class="form-group">
                    <div class="input-group-sm mb-3 ">
                        <div class="input-group-prepend">
                            <asp:Label ID="lblSQ1" class="input-group-text ddlsetting" runat="server" Text="Security Question 1" />
                        </div>
                        <asp:DropDownList ID="ddlSQ1" class="custom-select ddlsetting" runat="server" DataSourceID="sdsSecurityQuestion" DataTextField="securityQuestion" DataValueField="secQID" ></asp:DropDownList>
                        <asp:SqlDataSource ID="sdsSecurityQuestion" runat="server" ConnectionString="<%$ ConnectionStrings:databaseConstr %>" SelectCommand="SELECT * FROM [securityQuestion] WHERE ([secQID] &lt; @secQID)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="6" Name="secQID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <asp:Label ID="lblSA1" runat="server" Text="Security Answer 1" />
                    <asp:textbox ID="txtSA1" class="form-control" placeholder="Your security answer 1" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvSA1" runat="server" ControlToValidate="txtSA1" Display="Dynamic" ErrorMessage="Security Answer 1 should not be empty!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </div>

                <div class="form-group">
                    <div class="input-group-sm mb-3 ">
                        <div class="input-group-prepend">
                            <asp:Label ID="lblSQ2" class="input-group-text ddlsetting" runat="server" Text="Security Question 2" />
                        </div>
                        <asp:DropDownList ID="ddlSQ2" class="custom-select ddlsetting" runat="server" DataSourceID="sdsSecurityQuestion2" DataTextField="securityQuestion" DataValueField="secQID"></asp:DropDownList>

                        <br />
                        <asp:SqlDataSource ID="sdsSecurityQuestion2" runat="server" ConnectionString="<%$ ConnectionStrings:databaseConstr %>" SelectCommand="SELECT * FROM [securityQuestion] WHERE (([secQID] &gt; @secQID) AND ([secQID] &lt; @secQID2))">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="5" Name="secQID" Type="Int32" />
                                <asp:Parameter DefaultValue="11" Name="secQID2" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                        </div>
                    <asp:Label ID="lblSA2" runat="server" Text="Security Answer 2" />
                    <asp:textbox ID="txtSA2" class="form-control" placeholder="Your security answer 2" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvSA2" runat="server" ControlToValidate="txtSA2" Display="Dynamic" ErrorMessage="Security question 2 should not be empty!" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </div>
                
                 <div class="form-group">
                    <div class="input-group-sm mb-3 ">
                        <div class="input-group-prepend">
                            <asp:Label ID="lblSQ3" class="input-group-text ddlsetting" runat="server" Text="Security Question 3" />
                        </div>
                        <asp:DropDownList ID="ddlSQ3" class="custom-select ddlsetting" runat="server" DataSourceID="sdsSecurityQuestion3" DataTextField="securityQuestion" DataValueField="secQID"></asp:DropDownList>

                        <br />
                        <asp:SqlDataSource ID="sdsSecurityQuestion3" runat="server" ConnectionString="<%$ ConnectionStrings:databaseConstr %>" SelectCommand="SELECT * FROM [securityQuestion] WHERE ([secQID] &gt; @secQID)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="10" Name="secQID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                        </div>
                    <asp:Label ID="lblSA3" runat="server" Text="Security Answer 3" />
                    <asp:textbox ID="txtSA3" class="form-control" placeholder="Your security answer 3" runat="server" />
                     <asp:RequiredFieldValidator ID="rfvSA3" runat="server" ControlToValidate="txtSA3" Display="Dynamic" ErrorMessage="Security Question 3 should not be empty!" ForeColor="Red"></asp:RequiredFieldValidator>
                     <br />
                </div>
                <div>
                    <asp:Button ID="btnSubmit" class="btn btn-block " runat="server" Text="Submit" OnClick="btnNext3_Click" />
                    <br /><br />
                </div>
            </div>

            <div class="padding" id="registerSuccess" runat="server">
                <br />
                <br />
                <h3 class="align-content-center text-success">Registration Successful!</h3>
                <h5 class="align-content-center text-success">You will be redirected to Login page in a while.</h5>
                <h5 class="align-content-center text-success"><asp:Label ID="successEmail"  runat="server" /></h5>
            </div>
            <br /><br />
        </div>
       </div>
    </div>

</asp:Content>