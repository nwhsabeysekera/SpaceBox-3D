using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.ShapesService.App_Code
{
    public class Triangle : IShape
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle()
        {
            sideA = 0;
            sideB = 0;
            sideC = 0;
        }

        //Gets the parameters of the shape
        public ShapeParameters GetParameters()
        {
            return new ShapeParameters { SideA = sideA, SideB = sideB, SideC = sideC };
        }

        //Sets the parameters of the shape
        public void SetParameters(ShapeParameters parameters)
        {
            sideA = parameters.SideA;
            sideB = parameters.SideB;
            sideC = parameters.SideC;
        }

        //Calculates and returns the number of dots required to draw this shape
        public int CalculateRequiredDots()
        {
            //standard diameter of a braille dot (1.6mm) + standard space between two braille dots (2.5mm)
            double standard = 4.1;
            return (int)Math.Round((sideA+sideB+sideC)/standard);
        }
    }
}
