using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SpaceBoxService
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
            IShapeFactory factory = ShapeFactoryProvider.GetFactory(shape);
            return factory.Create().GetParameters();
        }

        //Calculates the number of dots required to draw a shape with the given parameters.
        [WebMethod]
        public int CalculateRequiredDots(string shape, Dictionary<string, double> parameters)
        {
            //Get the factory for the given shape.
            IShapeFactory factory = ShapeFactoryProvider.GetFactory(shape);

            //Create a new shape object from the factory.
            IShape shapeObj = factory.Create();

            //Set the parameters of the shape object.
            shapeObj.SetParameters(parameters);

            //Calculate the required dots for the shape.
            return shapeObj.CalculateRequiredDots();
        }
    }

    //Define an interface for a geometric shape
    public interface IShape
    {
        //Returns a dictionary of parameter names and values for this shape
        Dictionary<string, double> GetParameters();

        //Sets the parameters of the shape using a dictionary of parameter names and values
        void SetParameters(Dictionary<string, double> parameters);

        //Calculates and returns the number of dots required to draw this shape
        int CalculateRequiredDots();
    }

    //Define an interface for a factory that creates shapes
    public interface IShapeFactory
    {
        // Creates a new instance of a shape
        IShape Create();
    }

    //Define a class for a circle shape that implements the IShape interface
    public class Circle : IShape
    {
        private double Radius;
        //private double CenterX;
        //private double CenterY;

        public Circle()
        {
            Radius = 0;
            //CenterX = 0;
            //CenterY = 0;
        }

        //Returns a dictionary with the parameter name "Radius" and the current value of the radius
        public Dictionary<string, double> GetParameters()
        {
            return new Dictionary<string, double> { { "Radius", Radius } }; //{ "CenterX", CenterX }, { "CenterY", CenterY } };
        }

        //Sets the radius of the circle using the "Radius" key in the parameters dictionary
        public void SetParameters(Dictionary<string, double> parameters)
        {
            if (!parameters.TryGetValue("Radius", out Radius))//!parameters.TryGetValue("CenterX", out CenterX) || !parameters.TryGetValue("CenterY", out CenterY))
            {
                throw new ArgumentException("Invalid parameters for Circle");
            }
        }

        //Calculates and returns the number of dots required to draw the circle
        public int CalculateRequiredDots()
        {
            return (int)Math.Round(Math.PI * Radius * Radius);
            //return (int)Math.Round((Math.PI * Radius * Radius) + (2 * Math.PI * Radius * Math.Sqrt(Math.Pow(CenterX, 2) + Math.Pow(CenterY, 2))));

        }
    }

    public class Triangle : IShape
    {
        private double Base;
        private double Length;

        public Triangle()
        {
            Base = 0;
            Length = 0;
        }

        public Dictionary<string, double> GetParameters()
        {
            return new Dictionary<string, double> { { "Base", Base }, { "Length", Length } };
        }

        public void SetParameters(Dictionary<string, double> parameters)
        {
            if (!parameters.TryGetValue("Base", out Base) || !parameters.TryGetValue("Length", out Length))
            {
                throw new ArgumentException("Invalid parameters for Triangle");
            }
        }

        public int CalculateRequiredDots()
        {
            return (int)Math.Round(Base * Length / 2);
        }
    }

    public class Rectangle : IShape
    {
        private double Width;
        private double Length;

        public Rectangle()
        {
            Width = 0;
            Length = 0;
        }

        public Dictionary<string, double> GetParameters()
        {
            return new Dictionary<string, double> { { "Width", Width }, { "Length", Length } };
        }

        public void SetParameters(Dictionary<string, double> parameters)
        {
            if (!parameters.TryGetValue("Width", out Width) || !parameters.TryGetValue("Length", out Length))
            {
                throw new ArgumentException("Invalid parameters for Rectangle");
            }
        }

        public int CalculateRequiredDots()
        {
            return (int)Math.Round(Width * Length);
        }
    }

    //This class provides a static method to get a factory for creating shapes.
    public static class ShapeFactoryProvider
    {
        //Returns a factory that can create a shape object of the given type
        public static IShapeFactory GetFactory(string shape)
        {
            switch (shape.ToLower())
            {
                //If the shape is a circle, return a CircleFactory object
                case "circle":
                    return new CircleFactory();
                //If the shape is a triangle, return a TriangleFactory object
                case "triangle":
                    return new TriangleFactory();
                //If the shape is a rectangle, return a RectangleFactory object
                case "rectangle":
                    return new RectangleFactory();
                //If the shape is not recognized, throw an ArgumentException
                default:
                    throw new ArgumentException("Unsupported shape: " + shape);
            }
        }
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
