﻿using System;
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
            //ShapeServiceReference.ShapeServiceSoapClient client = new ShapeServiceReference.ShapeServiceSoapClient();

            if (!IsPostBack)
            {
                // Populate dropdown list with supported shapes

                //string[] supportedShapes = new ShapeService().GetSupportedShapes();

                /*foreach (string shape in supportedShapes)
                {
                    SelectShape.Items.Add(shape);
                }*/
            }

            /*Length.Visible = true;
            Width.Visible = true;
            Radius.Visible = false;
            Base.Visible = false;
            CenterX.Visible = false;
            CenterY.Visible = false;
            */
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
            try
            {
                // Get selected shape and parameters
                string shape = SelectShape.SelectedValue;
                Dictionary<string, double> parameters = new Dictionary<string, double>();
                if (shape == "Circle")
                {
                    parameters.Add("Radius", double.Parse(Radius.Text));
                    //parameters.Add("CenterX", double.Parse(CenterX.Text));
                    //parameters.Add("CenterY", double.Parse(CenterY.Text));
                }
                else if (shape == "Triangle")
                {
                    parameters.Add("Base", double.Parse(Base.Text));
                    parameters.Add("Length", double.Parse(Length.Text));
                }
                else if (shape == "Rectangle")
                {
                    parameters.Add("Width", double.Parse(Width.Text));
                    parameters.Add("Length", double.Parse(Length.Text));
                }

                // Calculate required dots
               // int requiredDots = new ShapeService().CalculateRequiredDots(shape, parameters);

                // Display result
                LabelPreview.Text = "Required dots: " + requiredDots;
            }
            catch (Exception ex)
            {
                LabelPreview.Text = ex.Message;
            }

            /*// get the input parameters
            string LengthParam = Length.Text;
            string WidthParam = Width.Text;
            string RadiusParam = Radius.Text;
            string BaseParam = Base.Text;

            // redirect to the service page with the input parameters
            Response.Redirect("ShapeService.asmx?LengthParam=" + LengthParam + "&WidthParam=" + WidthParam + "&RadiusParam=" + RadiusParam + "&BaseParam=" + BaseParam);
*/
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Length.Text = "";
            Width.Text = "";
            Radius.Text = "";
            Base.Text = "";
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

        protected void Circle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Length.Visible = false;
            Width.Visible = false;
            Radius.Visible = true;
            Base.Visible = false;
            //CenterX.Visible = true;
            //CenterY.Visible = true;
        }
        protected void Rectangle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Length.Visible = true;
            Width.Visible = true;
            Radius.Visible = false;
            Base.Visible = false;
            //CenterX.Visible = false;
            //CenterY.Visible = false;
        }
        protected void Triangle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Length.Visible = true;
            Width.Visible = false;
            Radius.Visible = false;
            Base.Visible = true;
           // CenterX.Visible = false;
            //CenterY.Visible = false;
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
                //CenterX.Visible = false;
                //CenterY.Visible = false;
            }
            else if (selectedShape == "Circle")
            {
                // Show input field for radius
                Length.Visible = false;
                Width.Visible = false;
                Radius.Visible = true;
                Base.Visible = false;
                //CenterX.Visible = true;
                //CenterY.Visible = true;
            }
            else if (selectedShape == "Triangle")
            {
                // Show input fields for base and height
                Length.Visible = true;
                Width.Visible = false;
                Radius.Visible = false;
                Base.Visible = true;
                //CenterX.Visible = false;
                //CenterY.Visible = false;

            }
        }

        /*protected void CenterX_TextChanged(object sender, EventArgs e)
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
        }*/
    }



}