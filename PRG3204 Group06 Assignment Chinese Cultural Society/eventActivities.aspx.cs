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
    public partial class eventActivities : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);

        string[] eventTitles = {"Event Name", "Event Type", "Date & Time", "Duration (hours)", "Description", "Details", "Event Fees (RM)"};
        string[] menuEventAdmin = { "Add Events", "Idea From Members", "Manage Participants"};
        protected void Page_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "EVENT & ACTIVITIES";

            string userType = "";

            if (Session["userType"] != null)
                userType = Session["userType"].ToString();

            if (userType == "AD")
            {
                panelIdea.Visible = true;

                for(int menuIndex = 0; menuIndex < menuEventAdmin.Length; menuIndex++)
                {
                    Button btnMenuEvent = new Button();
                    btnMenuEvent.Text = menuEventAdmin[menuIndex];
                    btnMenuEvent.ID = "btnEventMenu_" + menuIndex;
                    btnMenuEvent.CssClass = "btnEventMenu";
                    btnMenuEvent.Click += new EventHandler(this.btnEventMenu_Click);
                    panelIdea.Controls.Add(btnMenuEvent);

                    if(menuIndex != menuEventAdmin.Length - 1)
                    {
                        Label lblSpace = new Label();
                        lblSpace.Text = "<hr/>";
                        panelIdea.Controls.Add(lblSpace);
                    }     
                }
            }
            else
            {
                if(userType == "ME")
                {
                    hypLinkToIdeaSubmit.Text = "Any IDEA about our upcoming events? <br/> " +
                    "<a href = 'ideaGathering.aspx'>Click here</a>";
                }
                else
                {
                    hypLinkToIdeaSubmit.Text = "Can't wait to join us? <br/>" +
                        "<a href = 'signup.aspx'>Register Now!</a>";
                }
            }  
            
            conn.Open();

            SqlCommand sqlCmd = new SqlCommand("" +
                "SELECT eventName, eventType, eventStartTime, eventDuration, eventDesc, eventFiles, eventFee, eventPoster" +
                " from [eventsActivities]", conn);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            sqlDa.Fill(dt);

            sqlCmd = new SqlCommand("SELECT eventID from [eventsActivities]", conn);
            sqlDa = new SqlDataAdapter(sqlCmd);

            DataTable dtEventID = new DataTable();
            sqlDa.Fill(dtEventID);

            for (int tableIndex = 0; tableIndex < dt.Rows.Count; tableIndex++)
            {
                Table tb = new Table();
                tb.ID = tableIndex.ToString();
                //tb.BorderColor = System.Drawing.Color.Black;
                //tb.BorderWidth = 1;
                for (int rowIndex = 0; rowIndex < 7; rowIndex++)
                {
                    TableRow tr = new TableRow();
                    tb.Controls.Add(tr);

                    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                    {
                        TableCell td = new TableCell();
                        if(columnIndex == 0)
                        {
                            td.CssClass = "tdHeaderEvent";
                            Label lblHeader = new Label();
                            lblHeader.CssClass = "lblHeaderEvent";

                            lblHeader.Text = eventTitles[rowIndex] + " : ";
                            td.Controls.Add(lblHeader);
                        }
                        else if(columnIndex == 1){
                            td.CssClass = "tdContentEvent";
                            if (rowIndex == 5)
                            {
                                HyperLink hypLinkFile = new HyperLink();
                                hypLinkFile.NavigateUrl = dt.Rows[tableIndex][rowIndex].ToString();
                                hypLinkFile.Text = "Download Files for more details";
                                td.Controls.Add(hypLinkFile);
                            }
                            else
                            {
                                Label lblContent = new Label();
                                lblContent.CssClass = "lblContentEvent";
                                lblContent.Text = dt.Rows[tableIndex][rowIndex].ToString();
                                if(lblContent.Text == "NE" || lblContent.Text == "CO")
                                {
                                    lblContent.Text = (lblContent.Text == "NE") ? "Event" : "Competition";
                                }
                                td.Controls.Add(lblContent); 
                            }    
                        }
                        else
                        {
                            if(rowIndex == 0)
                            {
                                td.RowSpan = 6;
                                td.CssClass = "tdImages";
                                Image imgEvent = new Image();
                                imgEvent.ImageUrl = dt.Rows[tableIndex]["eventPoster"].ToString();
                                imgEvent.CssClass = "imgEvent";
                                td.Controls.Add(imgEvent);
                            }

                            if(rowIndex == 6)
                            {
                                td.CssClass = "tdBtnRegister";
                                if(userType != "AD")
                                {
                                    Button btnRegisterEvent = new Button();
                                    btnRegisterEvent.ID = "register_"+ dtEventID.Rows[tableIndex]["eventID"].ToString();
                                    btnRegisterEvent.Text = "Register";
                                    btnRegisterEvent.CssClass = "btnRegisterEvent";
                                   
                                    btnRegisterEvent.Click += new EventHandler(this.BtnRegister_Click);
                                    td.Controls.Add(btnRegisterEvent);
                                }
                                else
                                {
                                    Button btnRegisterEvent = new Button();
                                    btnRegisterEvent.ID = "update_" + dtEventID.Rows[tableIndex]["eventID"].ToString();
                                    btnRegisterEvent.Text = "Update";
                                    btnRegisterEvent.CssClass = "btnRegisterEvent";

                                    btnRegisterEvent.Click += new EventHandler(this.BtnUpdate_Click);
                                    td.Controls.Add(btnRegisterEvent);
                                }
                            }
                        }
                        if(!(columnIndex == 2 && (rowIndex >= 1 && rowIndex <= 5)))
                            tr.Controls.Add(td);
                    }

                }
                tb.CssClass = "tableEvent";

                Panel panelEventDiv = new Panel();
                panelEventDiv.CssClass = "divTableEvent";

                panelEventDiv.Controls.Add(tb);
                
                Label lbl = new Label();
                lbl.Text = "<br/><br/>";
                panelEvent.Controls.Add(panelEventDiv);
                panelEvent.Controls.Add(lbl);
            }
            conn.Close();                  
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            
        }

        void BtnRegister_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
           
            int eventID = int.Parse(senderButton.ID.Split('_')[1]); //or int.TryParse (better)
                                                                    //work with itemID 
            Session["doneRegistration"] = 0;
            Response.Redirect("eventRegistration.aspx?id=" + eventID);
        }

        void BtnUpdate_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
           
            int eventID = int.Parse(senderButton.ID.Split('_')[1]); //or int.TryParse (better)

            Response.Redirect("updateEvent.aspx?id=" + eventID);
        }

        void btnEventMenu_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
           
            int eventMenuID = int.Parse(senderButton.ID.Split('_')[1]); //or int.TryParse (better)

            switch (eventMenuID)
            {
                case 0: 
                    Response.Redirect("addEvent.aspx");
                    break;

                case 1:
                    Response.Redirect("IdeaGathering.aspx");
                    break;

                case 2:
                    Response.Redirect("manageParticipants.aspx");
                    break;
            }
        }
        void BtnIdeaMem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ideaGathering.aspx");
        }
    }
}