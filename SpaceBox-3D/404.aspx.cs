using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpaceBox_3D
{
    public partial class _404 : System.Web.UI.Page
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Logger.Info("Redirect to the Home page from Braille translator page.");
            Response.Redirect("~/Default.aspx");
        }
    }
}