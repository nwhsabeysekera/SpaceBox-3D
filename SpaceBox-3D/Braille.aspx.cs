using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpaceBox_3D
{
    public partial class Braille : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblDisplayDotAmount.Text = "";
            txtInput.Text = "";
            lblBraillePreview.Text = "";
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                BrailleServiceReference.BrailleServiceSoapClient client = new BrailleServiceReference.BrailleServiceSoapClient();
                string output = client.ConvertTextToBraille(txtInput.Text);
                int dotAmount = client.GetDotsAmount(txtInput.Text);

                this.lblBraillePreview.Text = output;
                this.lblDisplayDotAmount.Text = dotAmount.ToString();
            }
            catch (System.ServiceModel.EndpointNotFoundException ex)
            {
                Response.Redirect("~/404.aspx");
            }
        }
    }
}