using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//first load
            {
                loginEmail.Visible = true;
                confirmation.Visible = false;
                loginPassword.Visible = false;
                activation.Visible = false;
                lblError2.Visible = false;
                lb.Visible = false; //link for activation
                lblError.Visible = false;
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE userEmail=@userEmail", conn);
                SqlDataAdapter sda = new SqlDataAdapter();
                cmd.Parameters.AddWithValue("@userEmail", txtEmail.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                int block = 0;
                int userRole = 0;
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["userFirstName"] = dr["firstName"].ToString();
                        Session["userEmail"] = dr["userEmail"].ToString();
                        Session["profileImage"] = dr["profileImage"].ToString();
                        lblWelcome.Text = "Hi," + Session["userFirstName"] + " !";
                        loginImage.ImageUrl = "~/images/login/" + dr["profileImage"].ToString();
                        block = Convert.ToInt16(dr["isBlocked"].ToString());
                        userRole = Convert.ToInt16(dr["isAdmin"].ToString());

                    }
                    conn.Close();
                    membershipValidate(block, userRole);
                }
                else
                {
                    //Error message No user found.
                    loginImage.ImageUrl = "~/images/login/user.jpg";
                    lblError.Visible = true;
                    lblError.Text = "User not found!";
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error found:" + ex.ToString();
            }
            conn.Close();
        }

        public void membershipValidate(int block, int userRole)
        {
            if (block == 1)
            {
                lblError.Visible = true;
                lblError.Text = "Opps! You have been blocked by the system.";
            }
            else
            {
                switch (userRole)
                {
                    case 0:
                        //member
                        //check membership
                        conn.Open();
                        SqlCommand cmd2 = new SqlCommand("SELECT * FROM [membership] WHERE userEmail = @userEmail", conn);
                        SqlDataAdapter sda2 = new SqlDataAdapter();
                        cmd2.Parameters.AddWithValue("@userEmail", Session["userEmail"]);
                        SqlDataReader dr2 = cmd2.ExecuteReader();

                        while (dr2.Read())
                        {
                            //get member's activation date
                            var date = dr2["activationDate"].ToString();
                            //parse string date into DateTime
                            DateTime dateExpired = DateTime.Parse(date);
                            //membership valid until 365days after activate date
                            dateExpired = dateExpired.AddDays(365);
                            //date today
                            DateTime dateNow = DateTime.Now;
                            //check if today larger than expiry date
                            int daysLeft = DateTime.Compare(dateNow, dateExpired);

                            //save cookie for activation
                            HttpCookie cookie = new HttpCookie("activation");
                            //DateTime to string
                            cookie["expired"] = dateExpired.ToString();
                            Response.Cookies.Add(cookie);

                            if (daysLeft > 0)//Expired
                            {
                                lblError.Visible = true;
                                lblError.Text = "Opps! Your membership has been expired at " + dateExpired;
                                lb.Visible = true; // link for activation
                                break;
                            }
                            else if (daysLeft == 0)
                            {
                                lblRole.Text = "You're CCS Member. <br/>Your membership is valid until TODAY <br/> Please activate your membership by Today! " + dateExpired;
                                Session["userType"] = "ME";
                                Session["membershipID"] = dr2["membershipID"];
                                loginEmail.Visible = false;
                                confirmation.Visible = true;
                                break;

                            }
                            else //active
                            {
                                lblRole.Text = "You're CCS Member. <br/>Your membership valid until " + dateExpired;
                                Session["userType"] = "ME";
                                Session["membershipID"] = dr2["membershipID"];
                                loginEmail.Visible = false;
                                confirmation.Visible = true;
                                break;
                            }
                        }
                        conn.Close();
                        break;

                    case 1://admin
                        lblRole.Text = "You're CCS Admin.";
                        Session["userType"] = "AD";
                        loginEmail.Visible = false;
                        confirmation.Visible = true;
                        break;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            conn.Open();
            //get password from database
            SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE userEmail = @userEmail", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Parameters.AddWithValue("@userEmail", Session["userEmail"].ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            string hashedPassword = "";
            string passwordTohash = "";
            while (dr.Read())
            {
                //Verify password
                hashedPassword = dr["password_hash"].ToString();
                passwordTohash = txtpwd.Text;

            }
            conn.Close();

            if (Validation(passwordTohash, hashedPassword))
            {
                // password correct
                Response.Cookies["PageLastVist"].Value = DateTime.Now.ToString();
                Response.Redirect("homeWithNav.aspx");

            }
            else
            {
                // password failed
                lblError.Visible = true;
                lblError2.Text = "Wrong password!";
                // password attempt cookie
                int counter;
                HttpCookie cookie = Request.Cookies["pwdAttempt"];
                if (cookie == null)
                {
                    counter = 0; // new password attempt
                }
                else
                {

                    counter = int.Parse(Request.Cookies["pwdAttempt"].Value);
                }
                counter++; //increase the attempt time
                Response.Cookies["pwdAttempt"].Value = counter.ToString();
                Response.Cookies["pwdAttempt"].Expires = DateTime.Now.AddDays(1);

                if (counter > 5)//5 password attempt
                {
                    blockAcc();
                    loginPassword.Visible = false;
                    loginEmail.Visible = true;
                    txtEmail.Text = Session["userEmail"].ToString();
                    Response.Cookies["pwdAttempt"].Expires = DateTime.Now.AddDays(-1); //to delete the cookie
                }
            }
        }

        public void blockAcc()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [user] SET isBlocked = 1 WHERE userEmail=@userEmail", conn);
            cmd.Parameters.AddWithValue("@userEmail", Session["userEmail"]);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public bool Validation(string passwordTohash, string hashedPassword)
        {
            //get original hash values from delimited hash password
            var oriHashedParts = hashedPassword.Split('|'); //3 arrays
            var oriSalt = Convert.FromBase64String(oriHashedParts[0]);
            var oriIterations = Int32.Parse(oriHashedParts[1]);
            var oriHash = oriHashedParts[2];

            //generate hash from test password and original salt and iterations
            var pbkdf2 = new Rfc2898DeriveBytes(passwordTohash, oriSalt, oriIterations);
            byte[] testHash = pbkdf2.GetBytes(24);

            //if hash values match then return success
            if (Convert.ToBase64String(testHash) == oriHash)
                return true;

            //no match return false
            return false;

        }

        protected void btnYES_Click(object sender, EventArgs e)
        {
            confirmation.Visible = false;
            loginPassword.Visible = true;
            lblWelcome2.Text = "Welcome, " + Session["userFirstName"] + " !";
        }

        protected void btnNO_Click(object sender, EventArgs e)
        {
            confirmation.Visible = false;
            loginPassword.Visible = false;
            loginImage.ImageUrl = "~/images/login/user.jpg";
            txtEmail.Text = "";
            loginEmail.Visible = true;
            lblError.Text = "";
        }

        protected void Memberactivation(object sender, EventArgs e)
        {
            loginEmail.Visible = false;
            activation.Visible = true;
            HttpCookie cookie = Request.Cookies["activation"];
            object expiredDate = cookie["expired"];
            string expireDate = expiredDate.ToString();
            lblActivate.Text = "Membership Expired Date: " + expireDate;

            //date today
            var dateNow = DateTime.Now.ToString("dd/M/yyyy");
            //parse string to dateTime
            DateTime newExpiry = DateTime.Parse(dateNow);
            //add 365days
            newExpiry = newExpiry.AddDays(365);

            //display their new membership
            lblActivate2.Text = "Your new membership valid " + newExpiry.ToString();

            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE membership SET activationDate=@today WHERE userEmail=@userEmail", conn);
            cmd.Parameters.AddWithValue("@today", dateNow.ToString());
            cmd.Parameters.AddWithValue("@userEmail", Session["userEmail"]);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();



        }




    }
}