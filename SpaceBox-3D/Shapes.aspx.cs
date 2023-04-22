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
using NLog;
using SpaceBox_3D.ShapesServiceReference; 


namespace SpaceBox_3D
{
    public partial class Shapes : System.Web.UI.Page
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        ShapesServiceReference.ShapesServiceSoapClient client = new ShapesServiceReference.ShapesServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateShapeVisibility();
        }

        private void UpdateShapeVisibility()
        {
            if (SelectShape.SelectedValue == "Circle")
            {
                Logger.Info("Select the Circle as the Shape.");
                circle.Visible = true;
                rectangle.Visible = false;
                triangle.Visible = false;
            }

            if (SelectShape.SelectedValue == "Rectangle")
            {
                Logger.Info("Select the Rectangle as the Shape.");
                circle.Visible = false;
                rectangle.Visible = true;
                triangle.Visible = false;
            }

            if (SelectShape.SelectedValue == "Triangle")
            {
                Logger.Info("Select the Triangle as the Shape.");
                circle.Visible = false;
                rectangle.Visible = false;
                triangle.Visible = true;
            }
        }

        protected void SelectShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateShapeVisibility();
        }

        private void ClearValidationMessages()
        {
            lblRadiusValidate.Text = "";
            lblCenterPointValidate.Text = "";
            lblLengthValidate.Text = "";
            lblWidthValidate.Text = "";
            lblSideALengthValidate.Text = "";
            lblSideBLengthValidate.Text = "";
            lblSideCLengthValidate.Text = "";
            lblAnglesValidate.Text = "";
            Logger.Info("Cleared Text fields.");
        }

        private bool ValidateCircle()
        {
            bool isValid = true;

            double radius;
            if (string.IsNullOrEmpty(Radius.Text))
            {
                lblRadiusValidate.Text = "Please enter a radius.";
                isValid = false;
                Logger.Error("Circle Radius value is Null.");
            }
            else if (!double.TryParse(Radius.Text, out radius) || radius <= 0)
            {
                lblRadiusValidate.Text = "Please enter a valid radius.";
                isValid = false;            
                Logger.Error("Circle Radius value is out of bound.");              
            }

            if (string.IsNullOrEmpty(CenterX.Text) || string.IsNullOrEmpty(CenterY.Text))
            {
                lblCenterPointValidate.Text = "Please enter values for both X and Y coordinates.";
                isValid = false;
                Logger.Error("Circle's X or Y value is Null.");
            }
            Logger.Error("Validation of the Circle is successful.");
            return isValid;         
        }

        private bool ValidateRectangle()
        {
            bool isValid = true;

            double length, width;
            if (string.IsNullOrEmpty(Length.Text))
            {
                lblLengthValidate.Text = "Please enter a length.";
                isValid = false;
                Logger.Error("Rectangle Length value is Null.");
            }
            else if (!double.TryParse(Length.Text, out length) || length <= 0)
            {
                lblLengthValidate.Text = "Please enter valid length.";
                isValid = false;
                Logger.Error("Rectangle Length value is out of bound.");
            }

            if (string.IsNullOrEmpty(Width.Text))
            {
                lblWidthValidate.Text = "Please enter a width.";
                isValid = false;
                Logger.Error("Rectangle Width value is Null.");
            }
            else if (!double.TryParse(Width.Text, out width) || width <= 0)
            {
                lblWidthValidate.Text = "Please enter valid width.";
                isValid = false;
                Logger.Error("Rectangle Width value is out of bound.");
            }
            Logger.Error("Validation of the Rectangle is successful.");
            return isValid;
        }

        private bool ValidateTriangle()
        {
            bool isValid = true;

            double sideA = 0, sideB = 0, sideC = 0, angleA = 0, angleB = 0, angleC = 0;
            double.TryParse(txtAngleA.Text, out angleA);
            double.TryParse(txtAngleB.Text, out angleB);
            double.TryParse(txtAngleC.Text, out angleC);

            //validate the sides
            if (string.IsNullOrEmpty(SideALength.Text))
            {
                lblSideALengthValidate.Text = "Please enter a length for side A.";
                isValid = false;
                Logger.Error("Triangle SideALength value is Null.");
            }
            else if (!double.TryParse(SideALength.Text, out sideA) || sideA <= 0)
            {
                lblSideALengthValidate.Text = "Please enter valid length for side A.";
                isValid = false;
                Logger.Error("Triangle SideALength value is out of bound.");
            }

            if (string.IsNullOrEmpty(SideBLength.Text))
            {
                lblSideBLengthValidate.Text = "Please enter a length for side B.";
                isValid = false;
                Logger.Error("Triangle SideBLength value is Null.");
            }
            else if (!double.TryParse(SideBLength.Text, out sideB) || sideB <= 0)
            {
                lblSideBLengthValidate.Text = "Please enter valid length for side B.";
                isValid = false;
                Logger.Error("Triangle SideBLength value is out of bound.");
            }

            if (string.IsNullOrEmpty(SideCLength.Text))
            {
                lblSideCLengthValidate.Text = "Please enter a length for side C.";
                isValid = false;
                Logger.Error("Triangle SideCLength value is Null.");
            }

            //validate the angles
            else if (!double.TryParse(SideCLength.Text, out sideC) || sideC <= 0)
            {
                lblSideCLengthValidate.Text = "Please enter valid length for side C.";
                isValid = false;
                Logger.Error("Triangle SideCLength value is out of bound.");
            }

            if (string.IsNullOrEmpty(txtAngleA.Text) || string.IsNullOrEmpty(txtAngleB.Text) || string.IsNullOrEmpty(txtAngleC.Text))
            {
                lblAnglesValidate.Text = "Please enter values for the Angles A, B and C.";
                isValid = false;
                Logger.Error("Triangle one or more Angles values are Null.");
            }

            // Check if the sides form a valid triangle
            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                lblSideCLengthValidate.Text = "The entered sides do not form a valid triangle.";
                isValid = false;
                Logger.Error("Entered Triangle values do not form a valid Triangle.");
            }

            // Check if the angles form a valid triangle
            if (angleA + angleB + angleC != 180)
            {
                lblAnglesValidate.Text = "The entered angles do not form a valid triangle.";
                isValid = false;
                Logger.Error("Entered Triangle Angles values do not form a valid Triangle.");
            }
            Logger.Error("Validation of the Triangle is successful.");
            return isValid;
        }

        protected void txtAngleA_TextChanged(object sender, EventArgs e)
        {
            // Check if txtAngleB and txtAngleA are not empty
            if (!string.IsNullOrEmpty(txtAngleA.Text) && !string.IsNullOrEmpty(txtAngleB.Text))
            {
                // Calculate the value of txtAngleC based on the sum of txtAngleA and txtAngleB
                double angleA = double.Parse(txtAngleA.Text);
                double angleB = double.Parse(txtAngleB.Text);
                double angleC = 180 - angleA - angleB;

                // Update the value of txtAngleC
                txtAngleC.Text = angleC.ToString();
            }
        }

        protected void txtAngleB_TextChanged(object sender, EventArgs e)
        {
            // Check if txtAngleA and txtAngleB are not empty
            if (!string.IsNullOrEmpty(txtAngleA.Text) && !string.IsNullOrEmpty(txtAngleB.Text))
            {
                // Calculate the value of txtAngleC based on the sum of txtAngleA and txtAngleB
                double angleA = double.Parse(txtAngleA.Text);
                double angleB = double.Parse(txtAngleB.Text);
                double angleC = 180 - angleA - angleB;

                // Update the value of txtAngleC
                txtAngleC.Text = angleC.ToString();
            }
        }


        private bool ValidateInputs()
        {
            ClearValidationMessages();

            bool isValid = true;

            if (SelectShape.SelectedValue == "Circle")
            {
                ValidateCircle();
            }
            else if (SelectShape.SelectedValue == "Rectangle")
            {
                ValidateRectangle();
            }
            else if (SelectShape.SelectedValue == "Triangle")
            {
                ValidateTriangle();
            }

            return isValid;
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            CalculateDotAmount();
            Logger.Info("Click the btnApply_Click.");
        }

        private void CalculateDotAmount()
        {
            if (ValidateInputs())
            {
                try
                {
                    

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
                    Logger.Info("Display the required Dot amount.");
                }
                catch (System.ServiceModel.EndpointNotFoundException ex)
                {
                    // redirect to custom error page for 404
                    Logger.Error(ex, "Error! There is a Error in  CalculateDotAmount() method.");
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
            Logger.Info("Click the btnClear_Click.");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {         
            Response.Redirect(Request.RawUrl);
            Logger.Info("Click the btnCancel_Click.");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
            Logger.Info("Click the btnHome_Click.");
        }
    }
}