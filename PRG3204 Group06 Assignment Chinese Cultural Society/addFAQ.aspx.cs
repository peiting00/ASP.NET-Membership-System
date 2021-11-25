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
    public partial class addFAQ : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);
        protected void Page_PreRender(object sender, EventArgs e)
        {
            lblHeader.Text = "ADD NEW FAQs";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = "";

            if (Session["userType"] != null)
                userType = Session["userType"].ToString();

            if (userType != "AD")
                Response.Redirect("serviceSupport.aspx");
        }

        protected void btnAddFAQ_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
              
                SqlCommand cmd = new SqlCommand("INSERT INTO faqs(questionDesc,ansDesc)values (@quesDesc,@answerDesc)", conn);
                
                cmd.Parameters.AddWithValue("@quesDesc", txtFAQDesc.Text);
                cmd.Parameters.AddWithValue("@answerDesc", txtFAQAns.Text);
               
                cmd.ExecuteNonQuery(); //inserting

                conn.Close();
            }
            catch (Exception ex)
            {
                
            }

            txtFAQDesc.Text = "";
            txtFAQAns.Text = "";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("serviceSupport.aspx");
        }
    }
}