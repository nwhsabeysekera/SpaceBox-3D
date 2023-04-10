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

        private bool ValidateInputs()
        {
            bool isValid = true;
            lblRadiusValidate.Text = "";
            lblCenterPointValidate.Text = "";
            lblLengthValidate.Text = "";
            lblWidthValidate.Text = "";
            lblSideALengthValidate.Text = "";
            lblSideBLengthValidate.Text = "";
            lblSideCLengthValidate.Text = "";
            lblAnglesValidate.Text = "";

            if (SelectShape.SelectedValue == "Circle")
            {
                double radius;
                if (string.IsNullOrEmpty(Radius.Text))
                {
                    lblRadiusValidate.Text = "Please enter a radius.";
                    isValid = false;
                }
                else if (!double.TryParse(Radius.Text, out radius) || radius <= 0)
                {
                    lblRadiusValidate.Text = "Please enter a valid radius.";
                    isValid = false;
                }

                if (string.IsNullOrEmpty(CenterX.Text) || string.IsNullOrEmpty(CenterY.Text))
                {
                    lblCenterPointValidate.Text = "Please enter values for both X and Y coordinates.";
                    isValid = false;
                }
            }
            else if (SelectShape.SelectedValue == "Rectangle")
            {
                double length, width;
                if (string.IsNullOrEmpty(Length.Text))
                {
                    lblLengthValidate.Text = "Please enter a length.";
                    isValid = false;
                }
                else if (!double.TryParse(Length.Text, out length) || length <= 0)
                {
                    lblLengthValidate.Text = "Please enter valid length.";
                    isValid = false;
                }

                if (string.IsNullOrEmpty(Width.Text))
                {
                    lblWidthValidate.Text = "Please enter a width.";
                    isValid = false;
                }
                else if (!double.TryParse(Width.Text, out width) || width <= 0)
                {
                    lblWidthValidate.Text = "Please enter valid width.";
                    isValid = false;
                }
            }
            else if (SelectShape.SelectedValue == "Triangle")
            {
                double sideA, sideB, sideC;
                if (string.IsNullOrEmpty(SideALength.Text))
                {
                    lblSideALengthValidate.Text = "Please enter a length for side A.";
                    isValid = false;
                }
                else if (!double.TryParse(SideALength.Text, out sideA) || sideA <= 0)
                {
                    lblSideALengthValidate.Text = "Please enter valid length for side A.";
                    isValid = false;
                }

                if (string.IsNullOrEmpty(SideBLength.Text))
                {
                    lblSideBLengthValidate.Text = "Please enter a length for side B.";
                    isValid = false;
                }
                else if (!double.TryParse(SideBLength.Text, out sideB) || sideB <= 0)
                {
                    lblSideBLengthValidate.Text = "Please enter valid length for side B.";
                    isValid = false;
                }

                if (string.IsNullOrEmpty(SideCLength.Text))
                {
                    lblSideCLengthValidate.Text = "Please enter a length for side C.";
                    isValid = false;
                }
                else if (!double.TryParse(SideCLength.Text, out sideC) || sideC <= 0)
                {
                    lblSideCLengthValidate.Text = "Please enter valid length for side C.";
                    isValid = false;
                }

                if (string.IsNullOrEmpty(txtAngleA.Text) || string.IsNullOrEmpty(txtAngleB.Text) || string.IsNullOrEmpty(txtAngleC.Text))
                {
                    lblAnglesValidate.Text = "Please enter values for the Angles A, B and C.";
                    isValid = false;
                }
            }

            return isValid;
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {

            if (ValidateInputs())
            {
                try
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

                    lblDisplayDotAmount.Text = DotAmount.ToString();
                }
                catch (System.ServiceModel.EndpointNotFoundException ex)
                {
                    // redirect to custom error page for 404
                    Response.Redirect("~/404.aspx");
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Length.Text = "";
            lblLengthValidate.Text = "";
            Width.Text = "";
            lblWidthValidate.Text = "";

            Radius.Text = "";
            lblRadiusValidate.Text = "";
            CenterX.Text = "";
            CenterY.Text = "";

            SideALength.Text = "";
            lblSideALengthValidate.Text = "";
            SideBLength.Text = "";
            lblSideBLengthValidate.Text = "";
            SideCLength.Text = "";
            lblSideCLengthValidate.Text = "";

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