using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class myOrder : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn.Open();
                SqlCommand menuCmd = new SqlCommand("SELECT * FROM [category]", conn);
                SqlCommand orderRecordCmd = new SqlCommand("SELECT * FROM [orderRecord] WHERE membershipID=" + Session["membershipID"], conn);
                SqlDataAdapter sda = new SqlDataAdapter();
                {
                    orderRecordCmd.Connection = conn;
                    sda.SelectCommand = orderRecordCmd;
                    using (DataTable dt = new DataTable())
                    {
                        if (Session["membershipID"] != null)
                        {
                            sda.Fill(dt);
                            gvOrder.DataSource = dt;
                            gvOrder.DataBind();
                        }
                    }
                }
                conn.Close();
                this.BindGrid();

                //lblUsername.Text = Session["lastname"].ToString() + " " + Session["firstname"].ToString() + "'s Orders";
            }
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [orderRecord] WHERE membershipID=@memberID"))
                {
                    //string cat = ddlCategories.SelectedValue.ToString();
                    cmd.Parameters.AddWithValue("@memberID", Session["membershipID"]);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = conn;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvOrder.DataSource = dt;
                            gvOrder.DataBind();
                        }
                    }
                }
            }
        }

        protected void gridViewProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrder.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}