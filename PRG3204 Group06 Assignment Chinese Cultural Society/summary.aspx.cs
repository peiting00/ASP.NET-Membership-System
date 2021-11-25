using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class summary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCatalogue_Click(object sender, EventArgs e)
        {
            Response.Redirect("catalogue.aspx");
        }

        protected void btnVieworder_Click(object sender, EventArgs e)
        {
            Response.Redirect("myOrder.aspx");
        }
    }
}