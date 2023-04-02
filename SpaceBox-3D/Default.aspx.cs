using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpaceBox_3D
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShapes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shapes.aspx");
        }

        protected void btnBraille_Click(object sender, EventArgs e)
        {
            Response.Redirect("Braille.aspx");
        }
    }
}