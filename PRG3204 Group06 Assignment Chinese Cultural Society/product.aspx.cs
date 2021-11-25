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
    public partial class product : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);
        string items;
        string[] itemsList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn.Open();
                string ProductID = Request.QueryString["ProductID"];
                //Page.Header.Title = "Product " + ProductID;
                SqlCommand cmd = new SqlCommand("SELECT * FROM [product] WHERE productID= '" + ProductID + "'", conn);

                SqlDataAdapter sda = new SqlDataAdapter();
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        if (ProductID != null)
                        {
                            sda.Fill(dt);
                            dlProduct.DataSource = dt;
                            dlProduct.DataBind();
                        }
                    }
                    conn.Close();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(Session["membershipID"] != null)
            {
                try
                {
                    conn.Open();
                    string ProductID = Request.QueryString["ProductID"];

                    SqlCommand cartItems = new SqlCommand("SELECT * FROM [cart] WHERE membershipID=@memberID", conn);
                    cartItems.Parameters.AddWithValue("@memberID", Session["membershipID"]);
                    SqlDataReader dr = cartItems.ExecuteReader();
                    SqlCommand cmd = new SqlCommand("UPDATE cart SET items=@product", conn);
                    {
                        if (dr.Read())
                        {
                            items = dr["items"].ToString();
                            itemsList = items.Split(',');
                            //lblItem.Text = items;
                            dr.Close();
                            if (items == "")
                            {
                                cmd.Parameters.AddWithValue("@product", ProductID.ToString());
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                for (int i = 0; i < itemsList.Length; i++)
                                {
                                    if (ProductID == itemsList[i])
                                    {
                                        cmd.Parameters.AddWithValue("@product", items);
                                        cmd.ExecuteNonQuery();
                                        break;
                                    }
                                    if (i == itemsList.Length - 1)
                                    {
                                        cmd.Parameters.AddWithValue("@product", items + "," + ProductID.ToString());
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            Response.Write("<script>alert('Item added to your Cart')</script>");

                        }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblItem.Text = ex.ToString();
                }
            }
            else
            {
                Response.Write("<script>alert('Only member allow to purchase items')</script>");
            }
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            if (Session["membershipID"] != null)
            {
                try
                {
                    Response.Redirect("carts.aspx");
                }
                catch (Exception ex)
                {
                    lblItem.Text = ex.ToString();
                }
            }
            else
            {
                Response.Write("<script>alert('Only member allow to purchase items')</script>");
            }
        }

        protected void btnBackCat_Click(object sender, EventArgs e)
        {
            Response.Redirect("catalogue.aspx");
        }
    }
}