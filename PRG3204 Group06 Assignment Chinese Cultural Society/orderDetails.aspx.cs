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
    public partial class orderDetails : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);
        string items, quantity = "", strUP, discount;

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("myOrder.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            //Response.Redirect("");
        }

        string[] itemsList, qtyList;
        double subtotal = 0, unitPrice, total;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conn.Open();
                string OrderID = Request.QueryString["orderID"];
                Page.Header.Title = "Order " + OrderID;
                SqlCommand details = new SqlCommand("SELECT * FROM [orderRecord] WHERE orderID=@orderID", conn);
                details.Parameters.AddWithValue("@orderID", OrderID);
                SqlDataReader dr = details.ExecuteReader();
                if (dr.Read())
                {
                    items = dr["items"].ToString();
                    quantity = dr["quantity"].ToString();
                    itemsList = items.Split(',');
                    qtyList = quantity.Split(',');

                    lblAddress.Text = dr["address"].ToString();

                    dr.Close();
                }


                //Select command for select all Product ID
                string selectCommand = "SELECT * FROM [product] WHERE productID IN (";
                for (int i = 0; i < itemsList.Length; i++)
                {
                    if (i == 0)
                        selectCommand = selectCommand + "'" + itemsList[i] + "'";
                    else
                        selectCommand = selectCommand + "," + "'" + itemsList[i] + "'";
                }
                selectCommand = selectCommand + ")";

                /*Display cart items*/
                SqlCommand cmd = new SqlCommand(selectCommand, conn);
                SqlDataAdapter sda = new SqlDataAdapter();
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        dlProduct.DataSource = dt;
                        dlProduct.DataBind();
                    }
                    conn.Close();
                }

                foreach (DataListItem item in dlProduct.Items)
                {
                    for (int i = 0; i < itemsList.Length; i++)
                    {
                        if ((((Label)(item.FindControl("lblStoreProdID"))).Text).ToString() == itemsList[i])
                        {
                            ((Label)(item.FindControl("lblQty"))).Text = qtyList[i];
                        }
                    }

                    if (itemsList != null)
                    {
                        strUP = ((((Label)(item.FindControl("lblPrice"))).Text).ToString()).TrimStart('$');
                        unitPrice = Convert.ToDouble(strUP);
                        subtotal = subtotal + (unitPrice * Convert.ToDouble(((Label)(item.FindControl("lblQty"))).Text));
                    }
                    float shipping = 4;
                    lblSubtotalPrice.Text = "$ " + string.Format("{0:0.00}", subtotal);
                    discount = string.Format("{0:0.00}", (subtotal * 0.1));
                    lblDiscount.Text = "($ " + discount + ")";
                    lblShippingfee.Text = "$ 4.00";
                    total = subtotal + shipping - Convert.ToDouble(discount);
                    lblTotal.Text = "$ " + string.Format("{0:0.00}", total);
                }
            }
        }
    }
}