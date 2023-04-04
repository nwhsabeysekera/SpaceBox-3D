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