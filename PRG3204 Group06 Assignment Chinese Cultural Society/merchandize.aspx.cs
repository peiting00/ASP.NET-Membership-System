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
    public partial class merchandize : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);
       

        protected void Page_Load(object sender, EventArgs e)
        {
            //Uncomment when combine
            //if (Session["isAdmin"] == 1)
            //{
            if (!IsPostBack)
            {
                conn.Open();
                string CatID = Request.QueryString["categoryID"];
                SqlCommand menuCmd = new SqlCommand("SELECT * FROM [category]", conn);
                SqlCommand prodCmd = new SqlCommand("SELECT * FROM [product] WHERE categoryID= '" + CatID + "'", conn);
                SqlDataAdapter sda = new SqlDataAdapter();
                {
                    prodCmd.Connection = conn;
                    sda.SelectCommand = prodCmd;
                    using (DataTable dt = new DataTable())
                    {
                        if (CatID != null)
                        {
                            sda.Fill(dt);
                            gridViewProduct.DataSource = dt;
                            gridViewProduct.DataBind();
                        }
                    }
                    conn.Close();
                }

                this.BindGrid();
                ddlCategories.DataSource = SqlDataSourceCategories;
                ddlCategories.DataBind();

                ListItem myDefaultItem = new ListItem("Please select one...", string.Empty);
                myDefaultItem.Selected = true;
                ddlCategories.Items.Insert(0, myDefaultItem);
            }
            //}
            //else
            //{
            //Response.Redirect("");   (Redirect to homepage)
            //}
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT productID, productName, shortDescription, longDescription, unitPrice, imageFile, categoryID, inventory FROM [product] WHERE categoryID=@catID"))
                {
                    string cat = ddlCategories.SelectedValue.ToString();
                    cmd.Parameters.AddWithValue("@catID", cat);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = conn;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gridViewProduct.DataSource = dt;
                            gridViewProduct.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [product] WHERE productID=@prodID"))
                {
                    cmd.Parameters.AddWithValue("@prodID", txtSearch.Text);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gridViewProduct.DataSource = dt;
                            gridViewProduct.DataBind();
                        }
                    }
                }
            }
        }

        protected void gridViewProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewProduct.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}