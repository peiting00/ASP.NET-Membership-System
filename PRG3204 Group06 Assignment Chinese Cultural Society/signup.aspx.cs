using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class signup : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)//first load
            {
                section1.Visible = true;
                section2.Visible = false;
                section3.Visible = false;
                lblImageError.Visible = false;
                registerSuccess.Visible = false;
            }
        }

        public void checkUniqueEmail_OnTextChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE userEmail=@userEmail", conn);
            //SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Parameters.AddWithValue("@userEmail", txtEmail.Text);
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)//userEmail exist
            {
                lblExistEmail.Text = "You have an account with us! Please register with a new email";
                lblExistEmail.ForeColor = System.Drawing.Color.Red;
                btnNext.Enabled = false;
            }
            else
            {
                lblExistEmail.Text = "Valid email address.";
                lblExistEmail.ForeColor = System.Drawing.Color.Green;
                btnNext.Enabled = true;
            }
            conn.Close();
        }

        /* Section 1  */
        protected void btnNext_Click(object sender, EventArgs e)
        {
            int status = 1;

            conn.Open();
            //INSERT QUERY
            SqlCommand cmd = new SqlCommand("INSERT INTO [user](userEmail,firstName,lastName,phone,gender,isAdmin,isBlocked,profileImage,courseID,facultyID,password_hash)values" +
                "(@uE,@fN,@lN,@phone,@gender,0,0,@pImage,@courseID,@facultyID,@password_hash)", conn);

            cmd.Parameters.AddWithValue("@uE", txtEmail.Text);
            cmd.Parameters.AddWithValue("@fN", txtFN.Text);
            cmd.Parameters.AddWithValue("@lN", txtLN.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);

            //gender
            if (rbGender.SelectedValue == "M")
                cmd.Parameters.AddWithValue("@gender", "M");
            else
                cmd.Parameters.AddWithValue("@gender", "F");

            //profileImage
            if (fuImage.HasFile)
            {
                if (fuImage.PostedFile.ContentType == "image/jpg" || fuImage.PostedFile.ContentType == "image/jpeg")
                {
                    string filename = Path.GetFileName(fuImage.FileName);
                    fuImage.SaveAs(Server.MapPath("~/images/login/") + filename);
                    cmd.Parameters.AddWithValue("@pImage", filename);
                }
                else //wrong file format
                {
                    status = 0; //cannot proceed to insert
                    lblImageError.Visible = true;
                    lblImageError.ForeColor = System.Drawing.Color.Red;
                    lblImageError.Text = "Please upload only 'jpg' or 'jpeg' file.";
                }
            }


            //courseID
            if (ddlCourse.SelectedValue != string.Empty)
            {
                cmd.Parameters.AddWithValue("@courseID", ddlCourse.SelectedValue);
            }

            //facultyID
            if (ddlFaculty.SelectedValue != string.Empty)
            {
                cmd.Parameters.AddWithValue("@facultyID", ddlFaculty.SelectedValue);
            }

            //password_hash
            var passwordTohash = txtPassword.Text;
            string hashedPassword = PasswordHashing(passwordTohash);
            cmd.Parameters.AddWithValue("@password_hash", hashedPassword);

            if (status != 0)
            {
                cmd.ExecuteNonQuery(); //inserting
                conn.Close();
                Session["userEmail"] = txtEmail.Text;


                conn.Open();
                //insert membership
                SqlCommand cmd2 = new SqlCommand("INSERT INTO [membership](creationDate,activationDate,userEmail)values" +
                    "(@createDate,@activateDate,@userEmail)", conn);
                //today date
                var dateNow = DateTime.Now.ToString("dd/M/yyyy"); // format : 4/22/2021
                cmd2.Parameters.AddWithValue("@createDate", dateNow);
                cmd2.Parameters.AddWithValue("@activateDate", dateNow);
                cmd2.Parameters.AddWithValue("@userEmail", Session["userEmail"]);
                cmd2.ExecuteNonQuery();
                conn.Close();

                section1.Visible = false;
                section2.Visible = true;
            }


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
            return Convert.ToBase64String(salt) + "|" + iterations + "|" + Convert.ToBase64String(hash);
        }


        /* Section 2  */
        protected void btnNext2_Click(object sender, EventArgs e)
        {
            conn.Open();
            //INSERT INTO address table
            SqlCommand cmd = new SqlCommand("INSERT INTO [address](addressLine_1,addressLine_2,city,state,postcode,userEmail)values" +
                "(@L1,@L2,@city,@state,@postcode,@uEmail)", conn);

            cmd.Parameters.AddWithValue("@L1", txtAddLine1.Text);
            cmd.Parameters.AddWithValue("@L2", txtAddLine2.Text);
            cmd.Parameters.AddWithValue("@city", txtCity.Text);
            cmd.Parameters.AddWithValue("@state", txtState.Text);
            cmd.Parameters.AddWithValue("@postcode", txtPostcode.Text);
            cmd.Parameters.AddWithValue("@uEmail", Session["userEmail"]);

            cmd.ExecuteNonQuery(); //inserting
            Session["userEmail"] = txtEmail.Text;
            section2.Visible = false;
            section3.Visible = true;

            conn.Close();

            //SELECT MEMBERSHIP
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM [membership] WHERE userEmail=@userEmail", conn);
            cmd2.Parameters.AddWithValue("@userEmail", Session["userEmail"]);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            string memberID = "";
            while (dr2.Read())
            {
                memberID = dr2["membershipID"].ToString();
            }
            conn.Close();

            //INSERT SHOPPING CART
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("INSERT INTO [cart](membershipID)values(@memberID)", conn);
            cmd3.Parameters.AddWithValue("@memberID", memberID);
            cmd3.ExecuteNonQuery();
            conn.Close();



        }

        /* Section 3  */
        protected void btnNext3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO securityAnswer(answer,userEmail,secQID)values(@answer,@userEmail,@secQID)", conn);

            //-------------Security Question 1------------------------//
            //secQuestionID
            if (ddlSQ1.SelectedValue != string.Empty)
            {
                cmd.Parameters.AddWithValue("@secQID", Convert.ToInt32(ddlSQ1.SelectedValue.ToString()));
            }
            //answer
            cmd.Parameters.AddWithValue("@answer", txtSA1.Text);
            //userEmail
            cmd.Parameters.AddWithValue("@userEmail", Session["userEmail"]);

            cmd.ExecuteNonQuery(); //inserting



            cmd.Parameters.Clear();//clear all the parameters in SQ1

            //-------------Security Question 2 ------------------------//

            //secQuestionID2
            if (ddlSQ1.SelectedValue != string.Empty)
            {
                cmd.Parameters.AddWithValue("@secQID", ddlSQ2.SelectedValue);
            }
            //answer2
            cmd.Parameters.AddWithValue("@answer", txtSA2.Text);
            //userEmail2
            cmd.Parameters.AddWithValue("@userEmail", Session["userEmail"]);

            cmd.ExecuteNonQuery(); //inserting

            cmd.Parameters.Clear();//clear all the parameters in SQ2

            //-------------Security Question 3 ------------------------//
            //secQuestionID3
            if (ddlSQ1.SelectedValue != string.Empty)
            {
                cmd.Parameters.AddWithValue("@secQID", ddlSQ3.SelectedValue);
            }
            //answer3
            cmd.Parameters.AddWithValue("@answer", txtSA3.Text);
            //userEmail3
            cmd.Parameters.AddWithValue("@userEmail", Session["userEmail"]);

            cmd.ExecuteNonQuery(); //inserting
                                   //register successfull
            section3.Visible = false;
            successEmail.Text = Session["userEmail"].ToString();
            registerSuccess.Visible = true;
            Response.AddHeader("REFRESH", "3;URL=login.aspx"); //3sec

            conn.Close();
        }
    }
}