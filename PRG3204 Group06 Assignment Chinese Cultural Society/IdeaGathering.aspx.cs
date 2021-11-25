using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class IdeaGathering : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = "";

            if (Session["userType"] != null)
                userType = Session["userType"].ToString();

            if (userType != "AD" && userType != "ME")
                Response.Redirect("eventActivities.aspx");

            lblHeader.Text = "EVENTS IDEA GATHERING";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("eventActivities.aspx");
        }
    }
}