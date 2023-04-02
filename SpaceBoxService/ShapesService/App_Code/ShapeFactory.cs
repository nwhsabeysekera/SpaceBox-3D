using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.ShapesService.App_Code
{
    public class ShapeFactory
    {
        //Returns a factory that can create a shape object of the given type
        public IShape GetShape(string shape)
        {
            switch (shape.ToLower())
            {
                //If the shape is a circle, return a CircleFactory object
                case "circle":
                    return new Circle();

                //If the shape is a triangle, return a TriangleFactory object
                case "triangle":
                    return new Triangle();

                //If the shape is a rectangle, return a RectangleFactory object
                case "rectangle":
                    return new Rectangle();

                //If the shape is not recognized, throw an ArgumentException
                default:
                    throw new ArgumentException("Unsupported shape: " + shape);
            }
        }
    }
}