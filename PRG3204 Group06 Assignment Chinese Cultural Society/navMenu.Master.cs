using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class navMenu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userEmail"] != null)
            {
                string userType = "";

                if (Session["userType"] != null)
                    userType = Session["userType"].ToString();

                if (userType == "ME") //member
                {
                    lblUserEmail.Text = Session["userEmail"].ToString();
                    imageMember.ImageUrl = "~/images/login/" + Session["profileImage"].ToString();
                    lblUserEmail.Text = Session["userEmail"].ToString();
                    member.Visible = true;
                    admin.Visible = false;
                    nonMember.Visible = false;

                }
                else if (userType == "AD")//admin
                {
                    imageAdmin.ImageUrl = "~/images/login/" + Session["profileImage"].ToString();
                    lblAdminEmail.Text = Session["userEmail"].ToString();
                    admin.Visible = true;
                    member.Visible = false;
                    nonMember.Visible = false;
                }
            }
            else
            {
                nonMember.Visible = true;
                member.Visible = false;
                admin.Visible = false;
            }
        }

        protected void viewProfile_click(object sender, EventArgs e)
        {
            Response.Redirect("editProfile.aspx?userEmail=" + Session["userEmail"].ToString() + "");
        }
    }
}