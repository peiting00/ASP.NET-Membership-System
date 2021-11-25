using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class editProfile : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] == null)
                Response.Redirect("serviceSupport.aspx");

            if (!IsPostBack)
            {
                lblTitle.Text = "My Profile";
                profile.Visible = true;
                address.Visible = false;
                membership.Visible = false;
                bindProfile();
                clear();
            }

            lblLastVisit.Text = " | Last Visit: " + Request.Cookies["PageLastVist"].Value;

        }

        private void bindProfile()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE userEmail=@userEmail", conn);
            cmd.Parameters.AddWithValue("@userEmail", Request.QueryString["userEmail"]);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                profileImage.ImageUrl = "~/images/login/" + dr["profileImage"].ToString();
                txtFirstName.Text = dr["firstName"].ToString();
                txtLastName.Text = dr["lastName"].ToString();
                txtPhone.Text = dr["phone"].ToString();
                txtGender.Text = dr["gender"].ToString();
                txtCourse.Text = dr["courseID"].ToString();
                txtFaculty.Text = dr["facultyID"].ToString();
                txtProfile.Text = dr["profileImage"].ToString();
                lblEmail.Text = dr["userEmail"].ToString();
            }
            conn.Close();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ddlCourse.Visible = true;
            ddlFaculty.Visible = true;
            rbGender.Visible = true;
            fuImage.Visible = true;
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtGender.Visible = false;
            txtCourse.Visible = false;
            txtFaculty.Visible = false;
            txtProfile.Visible = false;
            btnEdit.Visible = false;
            btnUpdate.Visible = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int status = 1;
            conn.Open();
            //INSERT QUERY
            SqlCommand cmd = new SqlCommand("UPDATE [user] SET firstName=@FN, lastName=@LN,phone=@phone,gender=@gender,profileImage=@pImage,@courseID,@facultyID WHERE userEmail=@userEmail", conn);

            cmd.Parameters.AddWithValue("@fN", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@lN", txtLastName.Text);
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
            else
            {
                status = 0;
                lblImageError.Visible = true;
                lblImageError.Text = "Please select your profile image.";
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

            if (status != 0)
            {
                cmd.ExecuteNonQuery();
            }
            conn.Close();


        }
        protected void clear()
        {
            ddlCourse.Visible = false;
            ddlFaculty.Visible = false;
            rbGender.Visible = false;
            fuImage.Visible = false;
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtGender.Visible = true;
            txtCourse.Visible = true;
            txtFaculty.Visible = true;
            txtProfile.Visible = true;
            btnEdit.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void myProfile_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "My Profile";
            profile.Visible = true;
            bindProfile();
            clear();
            address.Visible = false;
            membership.Visible = false;
            lblImageError.Visible = false;
        }

        protected void myAddress_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "My Adderss";
            profile.Visible = false;
            membership.Visible = false;
            address.Visible = true;
        }

        protected void myMembership_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "My Membership";
            profile.Visible = false;
            address.Visible = false;
            membership.Visible = true;

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [membership] WHERE userEmail = @userEmail", conn);
            cmd.Parameters.AddWithValue("@userEmail", Session["userEmail"]);
            SqlDataReader dr2 = cmd.ExecuteReader();

            while (dr2.Read())
            {
                lblMemberSince.Text = dr2["creationDate"].ToString();
                lblMemberID.Text = Session["membershipID"].ToString();

                //get member's activation date
                var date = dr2["activationDate"].ToString();
                //parse string date into DateTime
                DateTime dateExpired = DateTime.Parse(date);
                //membership valid until 365days after activate date
                dateExpired = dateExpired.AddDays(365);
                lblExpired.Text = dateExpired.ToString();
            }
            conn.Close();

        }
    }
}