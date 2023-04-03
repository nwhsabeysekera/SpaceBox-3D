using SpaceBoxService.ShapesService.App_Code;
using SpaceBoxService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SpaceBoxService.ShapesService
{
    /// <summary>
    /// Summary description for ShapesService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ShapesService : System.Web.Services.WebService
    {
        [WebMethod]
        public int CalculateRequiredDotsForShape(string shapeType, ShapeParameters shapeParameters)
        {
            try
            {
                // Create a new instance of the ShapeFactory
                ShapeFactory shapeFactory = new ShapeFactory();

                // Get the IShape object for the specified shape type
                IShape shape = shapeFactory.GetShape(shapeType);

                // Set the parameters of the shape
                shape.SetParameters(shapeParameters);

                // Calculate the required dots for the shape
                int requiredDots = shape.CalculateRequiredDots();

                return requiredDots;
            }
            catch (ArgumentException ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
