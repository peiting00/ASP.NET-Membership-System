using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class addEvent : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = "";

            if (Session["userType"] != null)
                userType = Session["userType"].ToString();

            if (userType != "AD")
                Response.Redirect("eventActivities.aspx");
            
            lblHeader.Text = "ADD EVENTS";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("eventActivities.aspx");
        }

        protected void btnAddFAQ_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            if(txtEventName.Text != "" && txtDateTime.Text != "" && txtDescription.Text != "" && txtDuration.Text != "" && txtEventFee.Text != "")
            {
                SqlCommand cmd = new SqlCommand("" +
                    "INSERT INTO eventsActivities(eventName, eventType, eventDesc, eventStartTime, eventDuration, eventFiles, eventPoster, eventFee) " +
                    "VALUES (@eventName,@eventType, @eventDesc, @eventStartTime, @eventDuration, @eventFiles, @eventPoster, @eventFee)", conn);

                cmd.Parameters.AddWithValue("@eventName", txtEventName.Text);
                string eventType = (ddlEventType.SelectedItem.Text == "Normal Event") ? "NE" : "CO";

                cmd.Parameters.AddWithValue("@eventType", eventType);
                cmd.Parameters.AddWithValue("@eventDesc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@eventStartTime", txtDateTime.Text);
                cmd.Parameters.AddWithValue("@eventDuration", txtDuration.Text);
                cmd.Parameters.AddWithValue("@eventFiles", "~/filesUploaded/" + Path.GetFileName(fileUploadEventFile.FileName));
                cmd.Parameters.AddWithValue("@eventPoster", "~/images/" + Path.GetFileName(fileUploadPoster.FileName));
                cmd.Parameters.AddWithValue("@eventFee", txtEventFee.Text);

                cmd.ExecuteNonQuery(); //inserting

                conn.Close();
           

                if (fileUploadEventFile.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(fileUploadEventFile.FileName);
                        fileUploadEventFile.SaveAs(Server.MapPath("~/filesUploaded/") + filename);
                    }
                    catch (Exception ex)
                    {
                    
                    }
                }

                if (fileUploadPoster.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(fileUploadPoster.FileName);
                        fileUploadPoster.SaveAs(Server.MapPath("~/images/") + filename);
                    }
                    catch (Exception ex)
                    {
                    
                    }
                }

                txtEventName.Text = "";
                txtDescription.Text = "";
                txtDateTime.Text = "";
                txtDuration.Text = "";
                txtEventFee.Text = "";

                lblStatus.Text = "Event successfully added!";
                lblStatus.ForeColor = System.Drawing.Color.LimeGreen;
            }
            else
            {
                lblStatus.Text = "Information incomplete!";
                lblStatus.ForeColor = System.Drawing.Color.Crimson;
            }
        }
    }
}