using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class carts : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["databaseConstr"].ConnectionString);
        string items, quantity = "", strUP, discount;
        string[] itemsList;
        double subtotal = 0, unitPrice, total;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            string userType = "";

            if (Session["userType"] != null)
                userType = Session["userType"].ToString();

            if (userType != "ME")
                Response.Redirect("catalogue.aspx");
            */
            if (!IsPostBack)
            {
                conn.Open();
                string ProductID = Request.QueryString["ProductID"];
                /*Get Database user cart items*/
                SqlCommand cartItems = new SqlCommand("SELECT * FROM [cart] WHERE membershipID=@memberID", conn);
                SqlCommand updateCart = new SqlCommand("UPDATE cart SET items=@product", conn);
                cartItems.Parameters.AddWithValue("@memberID", Session["membershipID"]);
                SqlDataReader dr = cartItems.ExecuteReader();
                if (dr.Read())
                {
                    /*Store Database result*/
                    items = dr["items"].ToString();

                    //Remove cart item
                    if (ProductID != null)
                    {
                        /*Split item lists into array*/
                        itemsList = items.Split(',');
                        for (int i = 0; i < itemsList.Length; i++)
                        {
                            if (ProductID == itemsList[i])
                            {
                                items = "";
                                for (int j = 0; j < itemsList.Length; j++)
                                {
                                    if (j != i)
                                    {
                                        if (items == "")
                                        {
                                            items = itemsList[j];
                                        }
                                        else
                                        {
                                            items = items + "," + itemsList[j];
                                        }
                                    }
                                }
                            }
                        }

                    }

                    dr.Close();
                    updateCart.Parameters.AddWithValue("@product", items);
                    updateCart.ExecuteNonQuery();
                }

                /*Split into array again if user remove item*/
                if (items != null)
                {
                    itemsList = items.Split(',');

                    /*Combine splited array, formatted SQL command*/
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

                        //Bind multiple address to dropdownlist
                        string userAddr = "SELECT addressLine_1 + ' ' + addressLine_2 + ', ' + CONVERT(nvarchar(10),postcode) + ' ' + city + ', ' + state + '.' as Address, userEmail FROM [address] WHERE userEmail=@email";
                        SqlCommand addrCmd = new SqlCommand(userAddr, conn);
                        addrCmd.Parameters.AddWithValue("@email", Session["userEmail"]);
                        SqlDataAdapter addrSda = new SqlDataAdapter();
                        {
                            addrCmd.Connection = conn;
                            addrSda.SelectCommand = addrCmd;
                            using (DataTable dt = new DataTable())
                            {
                                addrSda.Fill(dt);
                                ddlAddress.DataSource = dt;
                                ddlAddress.DataValueField = "userEmail";
                                ddlAddress.DataTextField = "Address";
                                ddlAddress.DataBind();
                            }
                        }

                        lblEmail.Text = Session["userEmail"].ToString();

                        SqlCommand username = new SqlCommand("SELECT * FROM [user] WHERE userEmail=@email", conn);
                        username.Parameters.AddWithValue("@email", Session["userEmail"]);
                        SqlDataReader userReader = username.ExecuteReader();
                        if (userReader.Read())
                        {
                            lblUserName.Text = userReader["lastname"].ToString() + " " + userReader["firstname"].ToString();
                            lblPhone.Text = userReader["phone"].ToString();
                            userReader.Close();
                        }

                        if (items == "" || items == null)
                        {
                            summary_container.Visible = false;
                            noItem_wrapper.Visible = true;
                            btnBackCat.Visible = false;
                            //lbltest.Text = "no item";
                        }
                        else
                        {
                            summary_container.Visible = true;
                            noItem_wrapper.Visible = false;
                            btnBackCat.Visible = true;
                            //lbltest.Text = "got item";
                        }

                        conn.Close();
                    }
                }
            }




            foreach (DataListItem item in dlProduct.Items)
            {
                if (itemsList != null)
                {
                    strUP = ((((Label)(item.FindControl("lblPrice"))).Text).ToString()).TrimStart('$');
                    unitPrice = Convert.ToDouble(strUP);
                     
                    subtotal = subtotal + (unitPrice * Convert.ToDouble(((TextBox)(item.FindControl("txtQty"))).Text));
                }
            }
            lblSubtotalPrice.Text = "$ " + string.Format("{0:0.00}", subtotal);
            discount = string.Format("{0:0.00}", (subtotal * 0.1));
            lblDiscount.Text = "($ " + discount + ")";
            lblShippingfee.Text = " $ 4.00";
            total = subtotal + 4 - Convert.ToDouble(discount);
            lblTotal.Text = "$ " + string.Format("{0:0.00}", total);

        }

        protected void btnBackCat_Click(object sender, EventArgs e)
        {
            Response.Redirect("catalogue.aspx");
        }

        protected void btnCat_Click(object sender, EventArgs e)
        {
            Response.Redirect("catalogue.aspx");
        }

        protected void btnPlaceorder_Click(object sender, EventArgs e)
        {
            if (Session["membershipID"] != null)
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                        SqlCommand cart = new SqlCommand("SELECT * FROM [cart] WHERE membershipID=@memberID", conn);
                        cart.Parameters.AddWithValue("@memberID", Session["membershipID"]);
                        SqlDataReader dr = cart.ExecuteReader();
                        if (dr.Read())
                        {
                            /*Store Database result*/
                            items = dr["items"].ToString();
                            itemsList = items.Split(',');
                            dr.Close();
                        }

                        items = "";

                        foreach (DataListItem item in dlProduct.Items)
                        {
                            if (quantity == "")
                            {
                                quantity = ((TextBox)(item.FindControl("txtQty"))).Text;
                                items = ((Label)(item.FindControl("lblStoreProdID"))).Text;
                            }
                            else
                            {
                                quantity = quantity + "," + ((TextBox)(item.FindControl("txtQty"))).Text;
                                items = items + "," + ((Label)(item.FindControl("lblStoreProdID"))).Text;
                            }

                            if (itemsList != null)
                            {
                                strUP = ((((Label)(item.FindControl("lblPrice"))).Text).ToString()).TrimStart('$');
                                unitPrice = Convert.ToDouble(strUP);
                                subtotal = subtotal + (unitPrice * Convert.ToDouble(((TextBox)(item.FindControl("txtQty"))).Text));
                            }
                        }
                        lblSubtotalPrice.Text = string.Format("{0:0.00}", subtotal);
                        discount = string.Format("{0:0.00}", (subtotal * 0.1));
                        lblDiscount.Text = "(" + discount + ")";
                        lblShippingfee.Text = "4.00";
                        total = subtotal + Convert.ToDouble(lblShippingfee.Text) - Convert.ToDouble(discount);
                        lblTotal.Text = string.Format("{0:0.00}", total);

                        //insert order record
                        string insertQuery = "INSERT INTO orderRecord (items, quantity, payment,membershipID, date, address)values(@item, @qty, @payment,@memID, @date, @address)";
                        SqlCommand insertOrder = new SqlCommand(insertQuery, conn);
                        insertOrder.Parameters.AddWithValue("@item", items);
                        insertOrder.Parameters.AddWithValue("@qty", quantity);
                        insertOrder.Parameters.AddWithValue("@payment", lblTotal.Text);
                        insertOrder.Parameters.AddWithValue("@memID", Session["membershipID"]);
                        insertOrder.Parameters.AddWithValue("@date", DateTime.Now.ToString("D"));
                        insertOrder.Parameters.AddWithValue("@address", ddlAddress.SelectedItem.Text);
                        insertOrder.ExecuteNonQuery();

                        //clear cart items
                        string clearQuery = "UPDATE cart SET items=@clear";
                        SqlCommand clearCart = new SqlCommand(clearQuery, conn);
                        clearCart.Parameters.AddWithValue("@clear", "");
                        clearCart.ExecuteNonQuery();

                        //Update product stock
                        int inventory, purchased;
                        string updateQuery = "UPDATE product SET inventory=@inventory where productID=@prodID";
                        SqlCommand updateStock = new SqlCommand(updateQuery, conn);
                        foreach (DataListItem item in dlProduct.Items)
                        {
                            inventory = Convert.ToInt32(((Label)(item.FindControl("lblInventory"))).Text);
                            purchased = Convert.ToInt32(((TextBox)(item.FindControl("txtQty"))).Text);

                            if (updateStock.Parameters.Contains("@inventory"))
                            {
                                updateStock.Parameters["@inventory"].Value = inventory - purchased;
                                updateStock.Parameters["@prodID"].Value = ((Label)(item.FindControl("lblStoreProdID"))).Text;
                            }
                            else
                            {
                                //updateStock.Parameters.Add("@inventory", SqlDbType.Int);
                                updateStock.Parameters.AddWithValue("@inventory", inventory - purchased);
                                updateStock.Parameters.AddWithValue("@prodID", ((Label)(item.FindControl("lblStoreProdID"))).Text);
                            }
                            updateStock.ExecuteNonQuery();
                        }

                        conn.Close();
                        Response.Redirect("summary.aspx");
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Response.Write("<script>alert('Only member allow to purchase items')</script>");
            }
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cart = new SqlCommand("SELECT * FROM [cart] WHERE membershipID=@memberID", conn);
            cart.Parameters.AddWithValue("@memberID", Session["membershipID"]);
            SqlDataReader dr = cart.ExecuteReader();
            if (dr.Read())
            {
                /*Store Database result*/
                items = dr["items"].ToString();
                itemsList = items.Split(',');
            }

            if (itemsList != null)
            {
                foreach (DataListItem item in dlProduct.Items)
                {
                    if (itemsList != null)
                    {
                        if (Int32.Parse(((TextBox)(item.FindControl("txtQty"))).Text) > Int32.Parse(((Label)(item.FindControl("lblInventory"))).Text))
                        {
                            ((TextBox)(item.FindControl("txtQty"))).Text = "1";
                            ((Label)(item.FindControl("lblExceed"))).Text = "Only " + ((Label)(item.FindControl("lblInventory"))).Text + " stock(s) last";
                            ((Label)(item.FindControl("lblExceed"))).ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            ((Label)(item.FindControl("lblExceed"))).Text = "";
                        }

                        strUP = ((((Label)(item.FindControl("lblPrice"))).Text).ToString()).TrimStart('$');
                        unitPrice = Convert.ToDouble(strUP);

                        if (((TextBox)(item.FindControl("txtQty"))).Text == "")
                        {
                            ((TextBox)(item.FindControl("txtQty"))).Text = "1";
                        }
                        subtotal = subtotal + (unitPrice * Convert.ToDouble(((TextBox)(item.FindControl("txtQty"))).Text));
                    }
                }

                lblSubtotalPrice.Text = string.Format("{0:0.00}", subtotal);
                discount = string.Format("{0:0.00}", (subtotal * 0.1));
                lblDiscount.Text = "(" + discount + ")";
                lblShippingfee.Text = "4.00";
                total = subtotal + Convert.ToDouble(lblShippingfee.Text) - Convert.ToDouble(discount);
                lblTotal.Text = string.Format("{0:0.00}", total);
            }
        }
    }
}