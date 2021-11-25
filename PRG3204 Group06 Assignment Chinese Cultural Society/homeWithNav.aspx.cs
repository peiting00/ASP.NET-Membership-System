using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRG3204_Group06_Assignment_Chinese_Cultural_Society
{
    public partial class homeWithNav : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            imgHomeCalli.ImageUrl = "~/images/calligraphy.jpg";

            imgDiabolo.ImageUrl = "~/images/diabolo.jpg";
            imgChineseInstru.ImageUrl = "~/images/chineseInstrument.jpg";
            imgDebate.ImageUrl = "~/images/debate.png";
        }

            protected void Page_Load(object sender, EventArgs e)
        {
            /*see what usertype
            
            */
        }
    }
}