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
            
            Length.Visible = true;
            Width.Visible = true;
            Radius.Visible = false;
            Base.Visible = false;
        }

        protected void Length_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Width_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Radius_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Base_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {

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

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

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