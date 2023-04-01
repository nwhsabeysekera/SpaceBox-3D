using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpaceBox_3D
{
    public partial class Shapes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Length.Visible = true;
            Width.Visible = true;
            Radius.Visible = false;
            Base.Visible = false;
        }

        protected void Length_TextChanged(object sender, EventArgs e)
        {
            // Get the entered text
            string text = Length.Text;

            // Check if the text is not null and can be converted to a decimal
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out decimal result))
            {
                // Update the textbox to show the validated value
                Length.Text = result.ToString();
            }
            


        }

        protected void Width_TextChanged(object sender, EventArgs e)
        {
            // Get the entered text
            string text = Width.Text;

            // Check if the text is not null and can be converted to a decimal
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out decimal result))
            {
                // Update the textbox to show the validated value
                Width.Text = result.ToString();
            }
        }

        protected void Radius_TextChanged(object sender, EventArgs e)
        {
            // Get the entered text
            string text = Radius.Text;

            // Check if the text is not null and can be converted to a decimal
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out decimal result))
            {
                // Update the textbox to show the validated value
                Radius.Text = result.ToString();
            }
        }
        protected void Base_TextChanged(object sender, EventArgs e)
        {
            // Get the entered text
            string text = Base.Text;

            // Check if the text is not null and can be converted to a decimal
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out decimal result))
            {
                // Update the textbox to show the validated value
                Base.Text = result.ToString();
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            // get the input parameters
            string LengthParam = Length.Text;
            string WidthParam = Width.Text;
            string RadiusParam = Radius.Text;
            string BaseParam = Base.Text;

            // redirect to the service page with the input parameters
            Response.Redirect("ShapeService.asmx?LengthParam=" + LengthParam + "&WidthParam=" + WidthParam + "&RadiusParam=" + RadiusParam + "&BaseParam=" + BaseParam);

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Length.Text = "";
            Width.Text = "";
            Radius.Text = "";
            Base.Text = "";
            SelectShape.SelectedIndex = 0;
        }
    

    

        protected void btnShowPreview_Click(object sender, EventArgs e)
        {
           // try
            //{
                // Create a new instance of the SOAP client proxy
               // PreviewService.PreviewServiceSoapClient client = new PreviewService.PreviewServiceSoapClient();

                // Call the method on the SOAP service to generate the preview
                //string previewData = client.GeneratePreview("Some data to generate the preview");

                // Display the preview in the client side
               // PreviewPictureBox.Image = Image.FromStream(new MemoryStream(Encoding.UTF8.GetBytes(previewData)));
           // }
            //catch (Exception ex)
           // {
                // Handle any exceptions that may occur
               
            //}

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.example.com/page2.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
          
            Response.Redirect(Request.RawUrl);
        }

        protected void Circle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Length.Visible = false;
            Width.Visible = false;
            Radius.Visible = true;
            Base.Visible = false;


        }
        protected void Rectangle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Length.Visible = true;
            Width.Visible = true;
            Radius.Visible = false;
            Base.Visible = false;


        }
        protected void Triangle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Length.Visible = true;
            Width.Visible = false;
            Radius.Visible = false;
            Base.Visible = true;


        }

        protected void SelectShape_SelectedIndexChanged(object sender, EventArgs e)
        {


            
            // Get the selected shape from the dropdown list
            string selectedShape = SelectShape.SelectedValue;

            // Load the parameters for the selected shape
            if (selectedShape == "Rectangle")
            {
                // Show input fields for length and width
               
                Length.Visible = true;
                Width.Visible = true;
                Radius.Visible = false;
                Base.Visible = false;
            }
            else if (selectedShape == "Circle")
            {
                // Show input field for radius
                Length.Visible = false;
                Width.Visible = false;
                Radius.Visible = true;
                Base.Visible = false;
            }
            else if (selectedShape == "Triangle")
            {
                // Show input fields for base and height
                Length.Visible = true;
                Width.Visible = false;
                Radius.Visible = false;
                Base.Visible = true;

                
            }
        }
    }

    
    
}