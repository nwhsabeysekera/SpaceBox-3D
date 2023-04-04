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
using SpaceBox_3D.ShapesServiceReference; 


namespace SpaceBox_3D
{
    public partial class Shapes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rectangle.Visible = false;
            circle.Visible = true;
            triangle.Visible = false;
        }

        protected void SelectShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected shape from the dropdown list
            string selectedShape = SelectShape.SelectedValue;

            // Load the parameters for the selected shape
            if (selectedShape == "Rectangle")
            {
                // Show input fields for length and width
                rectangle.Visible = true;
                circle.Visible = false;
                triangle.Visible = false;
            }
            else if (selectedShape == "Circle")
            {
                // Show input field for radius
                rectangle.Visible = false;
                circle.Visible = true;
                triangle.Visible = false;
            }
            else if (selectedShape == "Triangle")
            {
                // Show input fields for base and height
                rectangle.Visible = false;
                circle.Visible = false;
                triangle.Visible = true;
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            ShapesServiceReference.ShapesServiceSoapClient client = new ShapesServiceReference.ShapesServiceSoapClient();

            // call the web method
            ShapeParameters shapeParams = new ShapeParameters();

            string selectedShape = SelectShape.SelectedValue;

            // Get the values of the shape parameters from the textboxes
            if (selectedShape == "Circle")
            {
                shapeParams.Radius = double.Parse(Radius.Text);
            }
            else if (selectedShape == "Rectangle")
            {
                shapeParams.Length = double.Parse(Length.Text);
                shapeParams.Width = double.Parse(Width.Text);
            }
            else if (selectedShape == "Triangle")
            {
                shapeParams.SideA = double.Parse(SideALength.Text);
                shapeParams.SideB = double.Parse(SideBLength.Text);
                shapeParams.SideC = double.Parse(SideCLength.Text);
            }

            int DotAmount = client.CalculateRequiredDotsForShape(selectedShape, shapeParams);

            LabelPreview.Text = DotAmount.ToString();
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
          
            Response.Redirect(Request.RawUrl);
        }

    }
}