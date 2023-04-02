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
//using SpaceBoxService; //ERROR Line////-----The service project name must be metioned in here to connect the ShapesService. 
//////but it is not connected to the project.
/////cosnsider about all the comment lines "This step must need to do here"

namespace SpaceBox_3D
{
    public partial class Shapes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShapesServiceReference.ShapesServiceSoapClient client = new ShapesServiceReference.ShapesServiceSoapClient();
            if (!IsPostBack)
            {
                // Populate dropdown list with supported shapes
      /////////////This step must need to do
                //string[] supportedShapes = new ShapesService().GetSupportedShapes(); //------ERROR LINE
            }
            /*
            Length.Visible = true;
            Width.Visible = true;
            Radius.Visible = false;
            SideALength.Visible = false;
            SideBLength.Visible = false;
            SideCLength.Visible = false;
            CenterX.Visible = false;
            CenterY.Visible = false;  */
        }

        protected void Circle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Length.Visible = false;
            Width.Visible = false;
            Radius.Visible = true;
            SideALength.Visible = false;
            SideBLength.Visible = false;
            SideCLength.Visible = false;
            CenterX.Visible = true;
            CenterY.Visible = true;
        }

        protected void Rectangle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Length.Visible = true;
            Width.Visible = true;
            Radius.Visible = false;
            SideALength.Visible = false;
            SideBLength.Visible = false;
            SideCLength.Visible = false;
            CenterX.Visible = false;
            CenterY.Visible = false;
        }

        protected void Triangle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Length.Visible = true;
            Width.Visible = false;
            Radius.Visible = false;
            SideALength.Visible = true;
            SideBLength.Visible = true;
            SideCLength.Visible = true;
            CenterX.Visible = false;
            CenterY.Visible = false;
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
                SideALength.Visible = false;
                SideBLength.Visible = false;
                SideCLength.Visible = false;
                CenterX.Visible = false;
                CenterY.Visible = false;
            }
            else if (selectedShape == "Circle")
            {
                // Show input field for radius
                Length.Visible = false;
                Width.Visible = false;
                Radius.Visible = true;
                SideALength.Visible = false;
                SideBLength.Visible = false;
                SideCLength.Visible = false;
                CenterX.Visible = true;
                CenterY.Visible = true;
            }
            else if (selectedShape == "Triangle")
            {
                // Show input fields for base and height
                Length.Visible = true;
                Width.Visible = false;
                Radius.Visible = false;
                SideALength.Visible = true;
                SideBLength.Visible = true;
                SideCLength.Visible = true;
                CenterX.Visible = false;
                CenterY.Visible = false;
            }
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

        protected void CenterX_TextChanged(object sender, EventArgs e)
        {
            // Get the entered text
            string text = CenterX.Text;

            // Check if the text is not null and can be converted to a decimal
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out decimal result))
            {
                // Update the centerY variable to the validated value
                CenterX.Text = result.ToString();
            }
        }

        protected void CenterY_TextChanged(object sender, EventArgs e)
        {
            // Get the entered text
            string text = CenterY.Text;

            // Check if the text is not null and can be converted to a decimal
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out decimal result))
            {
                // Update the centerY variable to the validated value
                CenterY.Text = result.ToString();
            }
        }

        protected void SideCLength_TextChanged(object sender, EventArgs e)
        {
            // Get the entered text
            string text = SideCLength.Text;

            // Check if the text is not null and can be converted to a decimal
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out decimal result))
            {
                // Update the textbox to show the validated value
                SideCLength.Text = result.ToString();
            }
        }

        protected void SideBLength_TextChanged(object sender, EventArgs e)
        {
            // Get the entered text
            string text = SideBLength.Text;

            // Check if the text is not null and can be converted to a decimal
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out decimal result))
            {
                // Update the textbox to show the validated value
                SideBLength.Text = result.ToString();
            }
        }

        protected void SideALength_TextChanged(object sender, EventArgs e)
        {
            // Get the entered text
            string text = SideALength.Text;

            // Check if the text is not null and can be converted to a decimal
            if (!string.IsNullOrEmpty(text) && decimal.TryParse(text, out decimal result))
            {
                // Update the textbox to show the validated value
                SideALength.Text = result.ToString();
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                // Get selected shape and parameters
                string shape = SelectShape.SelectedValue;
                Dictionary<string, double> parameters = new Dictionary<string, double>();
                if (shape == "Circle")
                {
                    parameters.Add("Radius", double.Parse(Radius.Text));
                    parameters.Add("CenterX", double.Parse(CenterX.Text));
                    parameters.Add("CenterY", double.Parse(CenterY.Text));
                }
                else if (shape == "Triangle")
                {
                    parameters.Add("SideALength", double.Parse(SideALength.Text));
                    parameters.Add("SideBLength", double.Parse(SideBLength.Text));
                    parameters.Add("SideCLength", double.Parse(SideCLength.Text));
                }
                else if (shape == "Rectangle")
                {
                    parameters.Add("Width", double.Parse(Width.Text));
                    parameters.Add("Length", double.Parse(Length.Text));
                }

                // Calculate required dots
                ShapesServiceReference.ShapesServiceSoapClient client = new ShapesServiceReference.ShapesServiceSoapClient();
            //////This step must need to do
                //int requiredDots = new ShapesService().CalculateRequiredDots(shape, parameters);//-----ERROR LINE

                // Display result
             ///////This step must need to do
                //LabelPreview.Text = "Required dots: " + requiredDots;    //---------ERROR LINE
            }
            catch (Exception ex)
            {
                LabelPreview.Text = ex.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Length.Text = "";
            Width.Text = "";
            Radius.Text = "";
            SideALength.Text = "";
            SideBLength.Text = "";
            SideCLength.Text = "";
            CenterX.Text = "";
            CenterY.Text = "";
            SelectShape.SelectedIndex = 0;
        }
    
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("Print.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
          
            Response.Redirect(Request.RawUrl);
        }

    }
}