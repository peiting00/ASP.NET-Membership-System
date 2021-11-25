using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();

            if (Request.Cookies["userEmail"] != null)
            {
                Response.Cookies["userEmail"].Expires = DateTime.Now.AddDays(-1);
            }

            Response.Redirect("homeWithNav.aspx");
        }
    }
}