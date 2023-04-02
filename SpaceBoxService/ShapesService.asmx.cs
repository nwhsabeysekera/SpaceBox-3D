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
        public string[] GetSupportedShapes()
        {
            return new string[] { "Circle", "Triangle", "Rectangle" };
        }

        //Returns a dictionary of parameters for a given shape.
        [WebMethod]
        public Dictionary<string, double> GetShapeParameters(string shape)
        {
            //Get the factory for the given shape
            IShapeFactory factory = ShapeFactory.GetFactory(shape);
            return factory.Create().GetParameters();
        }

        //Calculates the number of dots required to draw a shape with the given parameters.
        [WebMethod]
        public int CalculateRequiredDots(string shape, Dictionary<string, double> parameters)
        {
            //Get the factory for the given shape.
            IShapeFactory factory = ShapeFactory.GetFactory(shape);

            //Create a new shape object from the factory.
            IShape shapeObj = factory.Create();

            //Set the parameters of the shape object.
            shapeObj.SetParameters(parameters);

            //Calculate the required dots for the shape.
            return shapeObj.CalculateRequiredDots();
        }
    }


    //Define an interface for a factory that creates shapes
    public interface IShapeFactory
    {
        // Creates a new instance of a shape
        IShape Create();
    }

    // This class is an implementation of the IShapeFactory interface and is responsible for creating Rectangle objects.
    internal class RectangleFactory : IShapeFactory
    {
        //// Creates a new Rectangle object( Creates a new rectangle object by returning an instance of the rectangle class)
        IShape IShapeFactory.Create()
        {
            return new Rectangle();
        }
    }

    internal class TriangleFactory : IShapeFactory
    {
        IShape IShapeFactory.Create()
        {
            return new Triangle(); ;
        }
    }

    internal class CircleFactory : IShapeFactory
    {
        IShape IShapeFactory.Create()
        {
            return new Circle();
        }
    }
}
