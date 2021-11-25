using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class eventRegistration : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);

        protected void Page_PreRender(object sender, EventArgs e)
        {
            conn.Open();
            string eventName = "";
            int eventFee = 0;
            if(Request.QueryString["id"] != null)
            {
                SqlCommand sqlCmd = new SqlCommand("" +
                    "SELECT eventName, eventFee from [eventsActivities] " +
                    "WHERE eventID = @passEventID", conn);

                sqlCmd.Parameters.AddWithValue("@passEventID", Request.QueryString["id"]);
                SqlDataReader sqlRead = sqlCmd.ExecuteReader();

                
                if (sqlRead.Read())
                {
                    eventName = sqlRead["eventName"].ToString();
                    eventFee = Convert.ToInt32(sqlRead["eventFee"]);
                }
                Session["eventID"] = Request.QueryString["id"];
                Session["eventFee"] = eventFee;
            }
            
            lblHeader.Text = "EVENT REGISTRATION";
            lblEventName.Text = eventName;
            conn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = "";

            if (Session["userType"] != null)
                userType = Session["userType"].ToString();

            if (userType == "AD")
                Response.Redirect("eventActivities.aspx");

            conn.Open();

            if(Convert.ToInt32(Session["doneRegistration"]) == 0)
            {
                mvEventRegisterProcess.ActiveViewIndex = 0;
            }
            else
            {
                lblRegistrationStatus.Text = "Thanks for registering for our event!";
                if(Convert.ToInt32(Session["eventFee"]) != 0)
                {
                    lblFees.Text = "The fees for this event is " + Session["eventFee"].ToString();
                }
                else
                {
                    lblFees.Text = "No payment required";
                    btnPayOnline.Visible = false;
                    btnPayBycash.Visible = false;
                }
                
                mvEventRegisterProcess.ActiveViewIndex = 1;
            }

            conn.Close();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text == "" || txtFName.Text == "" || txtLName.Text == "")
            {
                lblStatus.Text = "Information above is all required";
            }
            else
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("" +
                    "SELECT COUNT(participantID) as duplicate from [participant] " +
                    "WHERE parEmail = @parEmail " +
                    "AND eventID = @eventID", conn);

                sqlCmd.Parameters.AddWithValue("@parEmail", txtEmail.Text);
                sqlCmd.Parameters.AddWithValue("@eventID", Session["eventID"].ToString());

                SqlDataReader sqlRead = sqlCmd.ExecuteReader();

                int duplicate = 0;
                if (sqlRead.Read())
                {
                    duplicate = Convert.ToInt32(sqlRead["duplicate"]);
                }
                conn.Close();
                if (duplicate == 0)
                {
                    Session["doneRegistration"] = 1;
                    Session["email"] = txtEmail.Text;
                    Session["FName"] = txtFName.Text;
                    Session["LName"] = txtLName.Text;

                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO participant(parEmail,parFName, parLName, isPaid, eventID)values (@parEmail,@parFName, @parLName, @isPaid, @eventID)", conn);

                    cmd.Parameters.AddWithValue("@parEmail", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@parFName", txtFName.Text);
                    cmd.Parameters.AddWithValue("@parLName", txtLName.Text);

                    if (Convert.ToInt32(Session["eventFee"]) != 0)
                        cmd.Parameters.AddWithValue("@isPaid", 0);
                    else
                        cmd.Parameters.AddWithValue("@isPaid", 1);

                    cmd.Parameters.AddWithValue("@eventID", Session["eventID"].ToString());
                   
                    

                    cmd.ExecuteNonQuery(); //inserting

                    conn.Close();

                    Response.Redirect("eventRegistration.aspx");

                }
                else
                {
                    lblStatus.Text = "This email has been registered for this event";
                }

                
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["email"] = "";
            Session["FName"] = "";
            Session["LName"] = "";
            Response.Redirect("eventActivities.aspx");
        }

        protected void btnPayOnline_Click(object sender, EventArgs e)
        {
            conn.Open();
           
            SqlCommand cmd = new SqlCommand("UPDATE [participant] SET isPaid = 1 " +
                "WHERE parEmail = @parEmail " +
                "AND eventID = @eventID", conn);

            cmd.Parameters.AddWithValue("@parEmail", Session["email"].ToString());
            cmd.Parameters.AddWithValue("@eventID", Session["eventID"].ToString());

            cmd.ExecuteNonQuery(); //inserting

            conn.Close();

            Response.Redirect("eventActivities.aspx");
        }

        protected void btnPayBycash_Click(object sender, EventArgs e)
        {
            Response.Redirect("eventActivities.aspx");
        }
    }
}