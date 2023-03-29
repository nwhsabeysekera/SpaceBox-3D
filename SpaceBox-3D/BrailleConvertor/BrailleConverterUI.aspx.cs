using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpaceBox_3D.BrailleConvertor
{
    public partial class BrailleConverterUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string jsonFilePath = Server.MapPath("~/BrailleConvertor/MapTextToBraille.json");
            string jsonContent = File.ReadAllText(jsonFilePath);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string inputText = inputTextBox.Text;

            //create an instance of the ConvertTextToBraille class in the MainClass class file
            ConvertTextToBraille obj = new ConvertTextToBraille();

            //call TranslateToBraille method
            string outputText = obj.TranslateToBraille(inputText);

            //display the output to the user
            outputTextBox.Text = outputText;
        }
    }
}