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
    public partial class manageParticipants : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = "";

            if (Session["userType"] != null)
                userType = Session["userType"].ToString();

            if (userType != "AD")
                Response.Redirect("eventActivities.aspx");

            lblHeader.Text = "MANAGE PARTICIPANTS";

            conn.Open();

            SqlCommand sqlCmd = new SqlCommand("" +
                "SELECT eventID,  eventName" +
                " from [eventsActivities]", conn);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            sqlDa.Fill(dt);

            conn.Close();
            
           
            for (int tableIndex = 0; tableIndex < dt.Rows.Count; tableIndex++)
            {
                Button btnEventItem = new Button();
                btnEventItem.ID = "btnEvent_" + dt.Rows[tableIndex][0].ToString();
                btnEventItem.CssClass = "btnEventItem dropShadow";
                conn.Open();

                SqlCommand sqlCmd2 = new SqlCommand("" +
                "SELECT COUNT(participantID) as participantAmount" +
                " from [participant] WHERE eventID = @eventID", conn);

                sqlCmd2.Parameters.AddWithValue("@eventID", dt.Rows[tableIndex][0].ToString());
                SqlDataReader sqlRead = sqlCmd2.ExecuteReader();

                int participantAmount = 0;
                if (sqlRead.Read())
                {
                    participantAmount = Convert.ToInt32(sqlRead["participantAmount"]);
                }
                conn.Close();

                string btnText = dt.Rows[tableIndex][1].ToString() + " -------- " + 
                    participantAmount + " participant(s)";
                
                btnEventItem.Text = btnText;
                btnEventItem.Click += new EventHandler(this.BtnEvent_Click);

                Label lblSpace = new Label();
                lblSpace.Text = "<br/><br/>";
                panelEventList.Controls.Add(lblSpace);

                panelEventList.Controls.Add(btnEventItem);
            }
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("eventActivities.aspx");
        }

        protected void BtnEvent_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;

            int eventID = int.Parse(senderButton.ID.Split('_')[1]); //or int.TryParse (better)
                                                                    //work with itemID 
            Response.Redirect("participantsInfo.aspx?id=" + eventID);
        }
    }
}