using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpaceBox_3D
{
    public partial class Shapes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                // Register the drawPreviewRectangle() function
                string script = "<script type='text/javascript'>" +
                                "function drawPreviewRectangle() {" +
                                "   // Get the values from the form" +
                                "   var width = document.getElementById('width').value;" +
                                "   var height = document.getElementById('height').value;" +
                                "   // Get the canvas element" +
                                "   var canvas = document.getElementById('previewCanvas');" +
                                "   // Check if the canvas is supported" +
                                "   if (canvas.getContext) {" +
                                "       var ctx = canvas.getContext('2d');" +
                                "       // Clear the canvas" +
                                "       ctx.clearRect(0, 0, canvas.width, canvas.height);" +
                                "       // Draw the preview rectangle" +
                                "       ctx.fillStyle = 'blue';" +
                                "       ctx.fillRect(10, 10, width, height);" +
                                "   }" +
                                "}" +
                                "</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script);
            }

        }

        protected void Length_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            // Code to handle the button click event

            // Register a script block to execute a JavaScript function
            string script = "<script type='text/javascript'>drawPreviewRectangle();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script);
        }
    }
    }
    
}