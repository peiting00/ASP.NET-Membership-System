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
    public partial class updateEvent : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = "";

            if (Session["userType"] != null)
                userType = Session["userType"].ToString();

            if (userType != "AD")
                Response.Redirect("eventActivities.aspx");

            if (Request.QueryString["id"] == null)
                Response.Redirect("eventActivities.aspx");

            string eventID = Request.QueryString["id"];

            conn.Open();

            SqlCommand sqlCmd = new SqlCommand("" +
                    "SELECT eventName from [eventsActivities] " +
                    "WHERE eventID = @passEventID", conn);

            sqlCmd.Parameters.AddWithValue("@passEventID", Request.QueryString["id"]);
            SqlDataReader sqlRead = sqlCmd.ExecuteReader();

            string eventName = "";

            if (sqlRead.Read())
                eventName = sqlRead["eventName"].ToString();
            
            conn.Close();

            lblHeader.Text = "EVENT UPDATING - " + eventName;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("eventActivities.aspx");
        }
    }
}