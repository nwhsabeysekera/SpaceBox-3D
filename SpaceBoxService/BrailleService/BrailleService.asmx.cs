using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SpaceBoxService.BrailleService
{
    /// <summary>
    /// Summary description for BrailleService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BrailleService : System.Web.Services.WebService
    {

        [WebMethod]
        public string ConvertToBraille(string input)
        {
            //create a instance of the App_Code.BrailleService class in the MainClass class file
            App_Code.BrailleService service = new App_Code.BrailleService();
            //call SplitIntoComponents method
            string output = service.TrasnlateToBraille(input);
            return output;
        }
    }
}
