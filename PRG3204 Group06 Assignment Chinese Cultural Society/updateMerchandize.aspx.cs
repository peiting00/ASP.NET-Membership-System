using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class updateMerchandize : System.Web.UI.Page
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
                string ProductID = Request.QueryString["ProductID"];
                SqlCommand cmd = new SqlCommand("SELECT * FROM [product] WHERE productID= '" + ProductID + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    imgProduct.ImageUrl = "~/images/" + dr["imageFile"].ToString();
                    txtProdID.Text = ProductID;
                    txtProdName.Text = dr["productName"].ToString();
                    txtShortDesc.Text = dr["shortDescription"].ToString();
                    txtLongDesc.Text = dr["longDescription"].ToString();
                    lblImageUploaded.Text = dr["imageFile"].ToString();
                    txtUnitprice.Text = dr["unitPrice"].ToString();
                    ddlCat.SelectedValue = dr["categoryID"].ToString();
                    txtInventory.Text = dr["inventory"].ToString();
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    txtProdID.Enabled = false;
                    btn_add.Visible = true;
                }
                else
                {
                    lblImageUploaded.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btn_add.Visible = false;
                }
            }
            //}
            //else
            //{
            //Response.Redirect("");   (Redirect to homepage)
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    if (lblImageUploaded.Text != "")
                    {
                        string imgFilename = Path.GetFileName(imgUploadCtrl.FileName);
                        string insertQuery = "INSERT INTO product(productID, productName, shortDescription, longDescription, categoryID, imageFile, unitPrice, inventory)values(@id, @prodName, @shortdesc, @longdesc,@catID, @imgfile, @price, @inventory)";
                        SqlCommand com = new SqlCommand(insertQuery, conn);
                        com.Parameters.AddWithValue("@id", txtProdID.Text);
                        com.Parameters.AddWithValue("@prodName", txtProdName.Text);
                        com.Parameters.AddWithValue("@shortdesc", txtShortDesc.Text);
                        com.Parameters.AddWithValue("@longdesc", txtLongDesc.Text);
                        com.Parameters.AddWithValue("@catID", (ddlCat.SelectedValue).ToString());
                        com.Parameters.AddWithValue("@imgfile", lblImageUploaded.Text);
                        com.Parameters.AddWithValue("@price", Convert.ToDouble(txtUnitprice.Text));
                        com.Parameters.AddWithValue("@inventory", Int64.Parse(txtUnitprice.Text));

                        com.ExecuteNonQuery(); //when not using database reader, when using INSERT command

                        Response.Write("<script>alert('Product added successfully!')</script>");
                        conn.Close();
                        Clear();
                    }
                    else
                    {
                        lblUploadStatus.Text = "Please upload an image!";
                        lblUploadStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void Clear()
        {
            txtProdID.Text = txtShortDesc.Text = txtProdName.Text = txtInventory.Text = txtLongDesc.Text = txtUnitprice.Text = "";
            lblStatus.Text = lblUploadStatus.Text = imgProduct.ImageUrl = "";


            btnSave.Visible = true;
            btnUpdate.Visible = false;
            txtProdID.Enabled = true;
            lblImageUploaded.Visible = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnDelete.Visible = true;
            lblImageUploaded.Visible = true;


        }

        //Some error need to fix
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                if (lblImageUploaded.Text != "")
                {
                    string imgFilename = Path.GetFileName(imgUploadCtrl.FileName);
                    string UpdateQuery = "UPDATE product SET productName=@prodName, shortDescription=@shortdesc, longDescription=@longdesc, categoryID=@catID, imageFile=@imgfile, unitPrice=@price, inventory=@inventory WHERE productID=@prodID";
                    SqlCommand cmd = new SqlCommand(UpdateQuery, conn);
                    {
                        cmd.Parameters.AddWithValue("@prodID", txtProdID.Text);
                        cmd.Parameters.AddWithValue("@prodName", txtProdName.Text);
                        cmd.Parameters.AddWithValue("@shortdesc", txtShortDesc.Text);
                        cmd.Parameters.AddWithValue("@longdesc", txtLongDesc.Text);
                        cmd.Parameters.AddWithValue("@catID", (ddlCat.SelectedValue).ToString());
                        cmd.Parameters.AddWithValue("@imgfile", lblImageUploaded.Text);
                        cmd.Parameters.AddWithValue("@price", Convert.ToDouble(txtUnitprice.Text));
                        cmd.Parameters.AddWithValue("@inventory", Convert.ToDecimal(txtInventory.Text));
                        cmd.ExecuteNonQuery();

                    }
                    Response.Write("<script>alert('Record updated successfully!')</script>");
                    cmd.Dispose();
                    conn.Close();
                    Clear();

                }
                else
                {
                    Response.Write("<script>alert('Product update failed, error(s) occured!')</script>");
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM product WHERE productID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtProdID.Text); //Convert.ToInt32(txtCatID.Text)
                        int rows = cmd.ExecuteNonQuery();

                        Response.Write("<script>alert('Record deleted successfully!')</script>");
                        conn.Close();
                        Clear();
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error: " + ex.ToString();
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (imgUploadCtrl.HasFile)
                try
                {
                    if (imgUploadCtrl.PostedFile.ContentType == "image/jpeg" ||
                        imgUploadCtrl.PostedFile.ContentType == "image/jpg" ||
                        imgUploadCtrl.PostedFile.ContentType == "image/pjpeg" ||
                        imgUploadCtrl.PostedFile.ContentType == "image/gif" ||
                        imgUploadCtrl.PostedFile.ContentType == "image/x-png" ||
                        imgUploadCtrl.PostedFile.ContentType == "image/png")
                    {
                        string filename = Path.GetFileName(imgUploadCtrl.FileName);
                        imgUploadCtrl.SaveAs(Server.MapPath("~/images/") + filename);
                        lblImageUploaded.Text = filename;
                        lblImageUploaded.Visible = true;
                        lblUploadStatus.Text = "Uploaded successfully!";
                        lblUploadStatus.ForeColor = System.Drawing.Color.Green;

                        imgProduct.ImageUrl = "~/images/" + lblImageUploaded.Text;
                        conn.Close();
                    }
                    else
                    {
                        lblUploadStatus.Text = "Only image files are accepted!";
                        lblUploadStatus.ForeColor = System.Drawing.Color.Red;

                    }
                }
                catch (Exception ex)
                {
                    lblUploadStatus.Text = "Upload status: File could not be uploaded. The following "
                        + ex.Message;
                    lblUploadStatus.ForeColor = System.Drawing.Color.Red;
                }
        }

        protected void btnProdAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("updateMerchandize.aspx");
        }
    }
}