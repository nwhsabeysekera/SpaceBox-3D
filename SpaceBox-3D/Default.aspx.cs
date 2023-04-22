using NLog;
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
        private static Logger Logger = LogManager.GetCurrentClassLogger();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShapes_Click(object sender, EventArgs e)
        {
            Logger.Info("Click the btnShapes_Click.");
            Response.Redirect("Shapes.aspx");
        }

        protected void btnBraille_Click(object sender, EventArgs e)
        {
            Logger.Info("Click the btnbraille_Click.");
            Response.Redirect("Braille.aspx");
        }
    }
}