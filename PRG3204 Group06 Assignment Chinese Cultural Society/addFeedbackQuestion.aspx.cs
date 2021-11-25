using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class addFeedbackQuestion : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);
        protected void Page_PreRender(object sender, EventArgs e)
        {
            lblHeader.Text = "ADD NEW FEEDBACK QUESTION";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = "";

            if (Session["userType"] != null)
                userType = Session["userType"].ToString();

            if (userType != "AD")
                Response.Redirect("serviceSupport.aspx");
        }

        protected void btnAddFeedQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO feedbackForm(feedbackQuesDesc,feedbackFormQuesType)values (@quesDesc, 'LA')", conn);

                cmd.Parameters.AddWithValue("@quesDesc", txtFeedQuesDesc.Text);

                cmd.ExecuteNonQuery(); //inserting

                conn.Close();
            }
            catch (Exception ex)
            {

            }

            txtFeedQuesDesc.Text = "";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("serviceSupport.aspx");
        }
    }
}