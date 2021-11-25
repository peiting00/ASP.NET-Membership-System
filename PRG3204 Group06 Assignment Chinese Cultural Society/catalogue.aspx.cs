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
    public partial class catalogue : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn.Open();
                string CategoryID = Request.QueryString["CategoryID"];
                SqlCommand menuCmd = new SqlCommand("SELECT * FROM [Category]", conn);
                SqlCommand catCmd = new SqlCommand("SELECT * FROM [Product] WHERE CategoryID= '" + CategoryID + "'", conn);
                SqlDataAdapter sda = new SqlDataAdapter();
                {
                    menuCmd.Connection = conn;
                    sda.SelectCommand = menuCmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        dlMenu.DataSource = dt;
                        dlMenu.DataBind();
                    }
                    catCmd.Connection = conn;
                    sda.SelectCommand = catCmd;
                    using (DataTable dt = new DataTable())
                    {
                        if (CategoryID != null)
                        {
                            sda.Fill(dt);
                            dlCategory.DataSource = dt;
                            dlCategory.DataBind();
                        }
                    }
                    conn.Close();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ChineseCulturalSociety"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [product] WHERE productName=@prodName"))
                {
                    cmd.Parameters.AddWithValue("@prodName", txtSearch.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dlCategory.DataSource = dt;
                            dlCategory.DataBind();
                        }
                    }
                }
            }
        }
    }
}