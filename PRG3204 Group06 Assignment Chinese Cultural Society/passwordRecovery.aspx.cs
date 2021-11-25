using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class passwordRecovery : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);

        protected void Page_PreRender(object sender, EventArgs e)
        {
            lblHeader.Text = "PASSWORD RECOVERY";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = "";

            if (Session["userType"] != null)
                userType = Session["userType"].ToString();

            if (userType == "AD" || userType == "ME")
                Response.Redirect("serviceSupport.aspx");

            int pageNo = Convert.ToInt32(Session["pageNo"]);
            if(pageNo == 0)
            {
                mvPassRe.ActiveViewIndex = pageNo;
                lblStep1.Text = "Step 1 : Please enter your email";
            }
            else if(pageNo == 1)
            {
                mvPassRe.ActiveViewIndex = pageNo;
                lblStep2.Text = "Step 2 : Please answer the security question(s) required carefully";

                string[] quesID = (string[])Session["secQuestionIDs"];

                int currentquesNo = Convert.ToInt32(Session["questionNo"]);

                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT securityQuestion from [securityQuestion] WHERE secQID = @userSecQID", conn);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);

                sqlCmd.Parameters.AddWithValue("@userSecQID", quesID[currentquesNo]);

                DataTable dt = new DataTable();
                sqlDa.Fill(dt);

                lblSecQues.Text = (Convert.ToInt32(Session["questionNo"]) + 1).ToString() + ".   " + dt.Rows[0]["securityQuestion"].ToString();
            }
            else
            {
                mvPassRe.ActiveViewIndex = pageNo;
                int correctOrNot = Convert.ToInt32(Session["correctSecAns"]);
                if (correctOrNot == 1)
                {
                    lblRecoverStatusMsg.Text = "Security question answer is verified. Please click 'Confirm' and then retrieve your new password";
                    lblRecoverStatusMsg.ForeColor = System.Drawing.Color.LimeGreen;
                    btnConfirm.Visible = true;
                }
                else
                {
                    conn.Open();
                    lblRecoverStatusMsg.Text = "Security question verification is unsuccessful. Your account has been blocked. Please kindly contact with our admin";
                    lblRecoverStatusMsg.ForeColor = System.Drawing.Color.Crimson;
                    btnConfirm.Visible = false;

                    SqlCommand cmd = new SqlCommand("UPDATE [user] SET isBlocked = 1 WHERE userEmail = @userEmail", conn);

                    cmd.Parameters.AddWithValue("@userEmail", Session["email"]);

                    cmd.ExecuteNonQuery(); //updating

                    conn.Close();
                }
            }
            conn.Close();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            btnResetSession();
        }

        protected void btnResetSession()
        {
            Session["pageNo"] = 0;
            Session["email"] = "";
            Session["questionNo"] = 0;
            Session["secQuestionIDs"] = "";
            Session["correctSecAns"] = 0;

            Response.Redirect("serviceSupport.aspx");
        }

        protected void btnNextEmail_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text != "")
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT userEmail from [user] WHERE userEmail = @userEmail", conn);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);

                sqlCmd.Parameters.AddWithValue("@userEmail", txtEmail.Text);

                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                 
                if (dt.Rows.Count > 0) //user email found and go to 'next page'
                {
                    sqlCmd = new SqlCommand("SELECT isBlocked FROM [user] WHERE userEmail = @userEmail", conn);

                    sqlCmd.Parameters.AddWithValue("@userEmail", txtEmail.Text);

                    sqlDa = new SqlDataAdapter(sqlCmd);
                    dt = new DataTable();
                    sqlDa.Fill(dt);

                    int isBlocked = Convert.ToInt32(dt.Rows[0]["isBlocked"]);

                    if (isBlocked == 0)
                    {
                        Session["pageNo"] = 1;
                        Session["email"] = txtEmail.Text;
                        Session["questionNo"] = 0;

                        sqlCmd = new SqlCommand("" +
                            "SELECT secQID FROM securityAnswer " +
                            "WHERE userEmail = @userEmail", conn);

                        sqlCmd.Parameters.AddWithValue("@userEmail", txtEmail.Text);

                        sqlDa = new SqlDataAdapter(sqlCmd);
                        dt = new DataTable();
                        sqlDa.Fill(dt);

                        string[] secQuestionIDs = new string[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                            secQuestionIDs[i] = dt.Rows[i]["secQID"].ToString();

                        Session["secQuestionIDs"] = secQuestionIDs;

                        lblStatusEmail.Text = "";

                        conn.Close();

                        Response.Redirect("passwordRecovery.aspx");
                    }
                    else
                    {
                        lblStatusEmail.Text = "Oops! Your account has been blocked due to suspicious activity detected. Please try to contact with our admin";
                    }
                }
                else
                {
                    lblStatusEmail.Text = "You should use the email you used to register for your account";
                }

                conn.Close();

            }
            else
            {
                lblStatusEmail.Text = "User email is required";
            }
        }

        protected void btnSubmitSecQues_Click(object sender, EventArgs e)
        {
            if(txtSecurityAns.Text != "")
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("" +
                    "SELECT secAID from [securityAnswer] WHERE userEmail = @userEmail" +
                    " AND secQID = @currentSecQID" +
                    " AND answer = @answerFromUserText", conn);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);

                sqlCmd.Parameters.AddWithValue("@userEmail", Session["email"].ToString());

                int currentquesNo = Convert.ToInt32(Session["questionNo"]);

                string[] secQuesIDs = (string[])Session["secQuestionIDs"];
                int currentQuesID = Convert.ToInt32(secQuesIDs[currentquesNo]);
     
                sqlCmd.Parameters.AddWithValue("@currentSecQID", currentQuesID);
                sqlCmd.Parameters.AddWithValue("@answerFromUserText", txtSecurityAns.Text);

                DataTable dt = new DataTable();
                sqlDa.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Session["pageNo"] = 2;
                    Session["correctSecAns"] = 1;
                    txtSecurityAns.Text = "";
                    lblStatusSecQues.Text = "";

                    conn.Close();

                    Response.Redirect("passwordRecovery.aspx");
                }
                else
                {
                    Session["questionNo"] = currentquesNo + 1;
                    int questionNo = currentquesNo + 1;
                    if (questionNo != 3)
                    {
                        Session["pageNo"] = 1;
                    }
                    else
                    {
                        Session["pageNo"] = 2;
                        Session["correctSecAns"] = 0;
                    }

                    txtSecurityAns.Text = "";
                    lblStatusSecQues.Text = "";

                    conn.Close();

                    Response.Redirect("passwordRecovery.aspx");
                }

                conn.Close();
            }
            else
            {
                lblStatusSecQues.Text = "The answer for your security question is required";
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            string newRandomizedPassword = randomPasswordGenerator();
            string newHashedRandomizedPassword = PasswordHashing(newRandomizedPassword);


            //lblRecoverStatusMsg.Text = newHashedRandomizedPassword;

            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE [user] SET password_hash = @newPassword WHERE userEmail = @userEmail", conn);

            cmd.Parameters.AddWithValue("@newPassword", newHashedRandomizedPassword);
            cmd.Parameters.AddWithValue("@userEmail", Session["email"]);

            cmd.ExecuteNonQuery(); //updating

            conn.Close();

            lblRecoverStatusMsg.Text = "Your new password is: " + newRandomizedPassword;

            btnConfirm.Visible = false;
        }

        private string randomPasswordGenerator()
        {
            int length = 8;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }

        public string PasswordHashing(string passwordTohash, int iterations = 100)
        {
            //generate a random salt for hashing
            var salt = new byte[24];
            new RNGCryptoServiceProvider().GetBytes(salt);

            //hash password given salt and iterations (default to 100)
            //iterations provide difficulty when cracking
            var pbkdf2 = new Rfc2898DeriveBytes(passwordTohash, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(24);


            //return delimited string with salt | #iterations | hash
            return Convert.ToBase64String(salt) + "|" + iterations + "|" +
                Convert.ToBase64String(hash);

        }

        private void sendEmail(string emailTo, string newPassword)
        {
           /*
            MailMessage message = new MailMessage(emailTo, "chineseculturalinti54321@gmail.com", "Password Reset Notification", "Hi there! Your new password is: " + newPassword); 
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("chineseculturalinti54321@gmail.com", "ccs12345");
            client.Send(message);
           */
        }
    }
}