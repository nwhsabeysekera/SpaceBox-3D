using SpaceBoxService.BrailleService.App_Code;
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
        public string ConvertTextToBraille(string input)
        {
            var service = new App_Code.BrailleService();
            string output = service.ConvertTextToBraille(input);
            return output;
        }

        [WebMethod]
        public int GetDotsAmount(string input)
        {
            input = ConvertTextToBraille(input);
            var DotsCounter = new DotsCounter();
            var DotAmount = DotsCounter.GetDotsAmount(input);
            return DotAmount;
        }
    }
}
