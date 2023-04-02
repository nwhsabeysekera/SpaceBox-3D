using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.ShapesService.App_Code
{
    public class Circle : IShape
    {
        private double radius;

        public ShapeParameters GetParameters()
        {
            return new ShapeParameters { Radius = radius };
        }

        public void SetParameters(ShapeParameters parameters)
        {
            if (parameters.Radius <= 0)
            {
                throw new ArgumentException("Invalid radius for Circle");
            }

            radius = parameters.Radius;
        }

        public int CalculateRequiredDots()
        {
            //standard diameter of a braille dot (1.6mm) + standard space between two braille dots (2.5mm)
            double standard = 4.1;
            return (int)Math.Round(2 * radius * Math.PI / standard);
        }
    }



    /*public class Circle : IShape
    {
        private double Radius;
        private double CenterX;
        private double CenterY;
        private double Standard;

        public Circle()
        {
            Radius = 0;
            CenterX = 0;
            CenterY = 0;
            Standard = 2.5;
        }

        //Returns a dictionary with the parameter name "Radius" and the current value of the radius
        public Dictionary<string, double> GetParameters()
        {
            return new Dictionary<string, double> { { "Radius", Radius } };
        }

        //Sets the radius of the circle using the "Radius" key in the parameters dictionary
        public void SetParameters(Dictionary<string, double> parameters)
        {
            if (!parameters.TryGetValue("Radius", out Radius))
            {
                throw new ArgumentException("Invalid parameters for Circle");
            }
        }

        //Calculates and returns the number of dots required to draw the circle
        public int CalculateRequiredDots()
        {
            return (int)Math.Round(2 * Radius * Math.PI / Standard);
            //return (int)Math.Round(Math.PI * Radius * Radius);
            //return (int)Math.Ceiling((2 * Radius * Math.PI) / cellDiameter) * 6;
            //return (int)Math.Round((Math.PI * Radius * Radius) + (2 * Math.PI * Radius * Math.Sqrt(Math.Pow(CenterX, 2) + Math.Pow(CenterY, 2))));

        }
    }*/
}