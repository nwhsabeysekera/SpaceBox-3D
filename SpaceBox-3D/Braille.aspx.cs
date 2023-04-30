using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpaceBox_3D
{
    public partial class Braille : System.Web.UI.Page
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        BrailleServiceReference.BrailleServiceSoapClient client = new BrailleServiceReference.BrailleServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Logger.Info("Click the btnClear_Click.");
            txtInput.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Logger.Info("Click the btnCancel_Click.");
            Response.Redirect(Request.RawUrl);
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.Info("Click the btnConvert_Click.");
                string output = client.ConvertTextToBraille(txtInput.Text);
                int dotAmount = client.GetDotsAmount(txtInput.Text);
               
                this.lblBraillePreview.Text = output;
                Logger.Info("The translation to Braille is successful.");
                this.lblDisplayDotAmount.Text = dotAmount.ToString();
                Logger.Info("Successfully displayed the dot-amount.");
            }
            catch (System.ServiceModel.EndpointNotFoundException ex)
            {
                Response.Redirect("~/404.aspx");
                Logger.Error(ex,"Error! the output did not dispayed.");
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Logger.Info("Click the btnHomeClick.");
            Response.Redirect("~/Default.aspx");
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Print.aspx");
        }
    }
}