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
    public partial class participantsInfo : System.Web.UI.Page
    {
        string[] header = { "participant ID", "participant Name", "participant Email", "Status" };
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = "";

            if (Session["userType"] != null)
                userType = Session["userType"].ToString();

            if (userType != "AD" || Request.QueryString["id"] == null)
                Response.Redirect("eventActivities.aspx");

            Session["eventID"] = Request.QueryString["id"];
            lblHeader.Text = "PARTICIPANT'S INFO";

            Table tableParticipant = new Table();
            TableRow trHeader = new TableRow();
            tableParticipant.CssClass = "tablePar";

            for(int headerIndex = 0; headerIndex < header.Length; headerIndex++)
            {
                TableCell tdHeader = new TableCell();
                tdHeader.Text = header[headerIndex];
                tdHeader.CssClass = "tdHeaderPar tdParWidth";
                trHeader.Controls.Add(tdHeader);
            }
            tableParticipant.Controls.Add(trHeader);

            conn.Open();

            SqlCommand sqlCmd = new SqlCommand("" +
            "SELECT participantID, CONCAT(parFName, parLName) as parName, parEmail, isPaid" +
            " from [participant] " +
            " WHERE eventID = @passEventID", conn);

            sqlCmd.Parameters.AddWithValue("@passEventID", Request.QueryString["id"]);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();
            sqlDa.Fill(dt);

            sqlCmd = new SqlCommand("SELECT participantID from [participant]", conn);
            sqlDa = new SqlDataAdapter(sqlCmd);

            DataTable dtParID = new DataTable();
            sqlDa.Fill(dtParID);

            conn.Close();
            for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
            {
                TableRow tr = new TableRow();
                for(int columnIndex = 0; columnIndex < header.Length; columnIndex++)
                {
                    TableCell td = new TableCell();
                    
                    if(columnIndex == header.Length - 1)
                    {                        
                        if(dt.Rows[rowIndex]["isPaid"].ToString() == "0")
                        {
                            Button btnApprove = new Button();
                            btnApprove.ID = "btnApprove_"+ dt.Rows[rowIndex]["participantID"].ToString();
                            btnApprove.Text = "Approve";
                            btnApprove.CssClass = "btnApprovePar dropShadow";
                            btnApprove.Click += new EventHandler(this.btnApprove_Click);
                            td.Controls.Add(btnApprove);
                            td.CssClass = "tdParWidth tdBtnPar";
                        }
                        else
                        {
                            Button btnApproved = new Button();
                            btnApproved.Text = "Approved";
                            btnApproved.CssClass = "lblApproved";
                            btnApproved.Enabled = false;
                            td.Controls.Add(btnApproved);
                            td.CssClass = "tdParWidth tdBtnPar";
                        }                        
                    }
                    else
                    {
                        td.Text = dt.Rows[rowIndex][columnIndex].ToString();
                        td.CssClass = "tdParWidth";
                    }
                    //td.CssClass = "tdParWidth";
                    tr.Controls.Add(td);
                }
                tableParticipant.Controls.Add(tr);
            }
            panelParticipants.Controls.Add(tableParticipant);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("manageParticipants.aspx");
        }

         protected void btnApprove_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;

            int parID = int.Parse(senderButton.ID.Split('_')[1]); //or int.TryParse (better)
                                                                  //work with itemID 
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE [participant] SET isPaid = 1 " +
                "WHERE participantID = @parID", conn);

            cmd.Parameters.AddWithValue("@parID", parID);

            cmd.ExecuteNonQuery(); //updating

            conn.Close();

            Response.Redirect("participantsInfo.aspx?id=" + Session["eventID"].ToString());
        }
    }
}