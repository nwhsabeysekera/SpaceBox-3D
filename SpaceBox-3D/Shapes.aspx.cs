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
            UpdateShapeVisibility();
        }

        private void UpdateShapeVisibility()
        {
            if (SelectShape.SelectedValue == "Circle")
            {
                circle.Visible = true;
                rectangle.Visible = false;
                triangle.Visible = false;
            }

            if (SelectShape.SelectedValue == "Rectangle")
            {
                circle.Visible = false;
                rectangle.Visible = true;
                triangle.Visible = false;
            }

            if (SelectShape.SelectedValue == "Triangle")
            {
                circle.Visible = false;
                rectangle.Visible = false;
                triangle.Visible = true;
            }
        }

        protected void SelectShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateShapeVisibility();
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            // Validate inputs before calling the web service
            if (SelectShape.SelectedValue == "Circle")
            {
                if (!double.TryParse(Radius.Text, out double radius) || radius <= 0)
                {
                    lblRadiusValidate.Text = "Please enter a valid radius.";
                    return;
                }
            }

            else if (SelectShape.SelectedValue == "Rectangle")
            {
                if (!double.TryParse(Length.Text, out double length) || length <= 0)
                {
                    lblLengthValidate.Text = "Please enter valid length.";
                    return;
                }
                else if
                    (!double.TryParse(Width.Text, out double width) || width <= 0)
                {
                    lblWidthValidate.Text = "Please enter valid width.";
                    return;
                }
            }


            else if (SelectShape.SelectedValue == "Triangle")
            {
                if (!double.TryParse(SideALength.Text, out double sideA) || sideA <= 0)
                {
                    lblSideALengthValidate.Text = "Please enter valid length.";
                    return;
                }
                else if
                    (!double.TryParse(SideBLength.Text, out double sideB) || sideB <= 0)
                {
                    lblSideBLengthValidate.Text = "Please enter valid length.";
                    return;
                }

                else if
                    (!double.TryParse(SideCLength.Text, out double sideC) || sideC <= 0)
                {
                    lblSideCLengthValidate.Text = "Please enter valid length.";
                    return;
                }                  
            }
            
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

            lblDisplayDotAmount.Text = DotAmount.ToString();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Length.Text = "";
            Width.Text = "";

            Radius.Text = "";
            CenterX.Text = "";
            CenterY.Text = "";

            SideALength.Text = "";
            SideBLength.Text = "";
            SideCLength.Text = "";

            txtAngleA.Text = "";
            txtAngleB.Text = "";
            txtAngleC.Text = "";
            
            SelectShape.SelectedIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {         
            Response.Redirect(Request.RawUrl);
        }

    }
}