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

    /*public class Triangle : IShape
    {
            private double SideALength;
            private double SideBLength;
            private double SideCLength;
            private double Standard;

            public Triangle()
            {
            SideALength = 0;
            SideBLength = 0;
            SideCLength = 0;
            Standard = 2.5;
            }

            public Dictionary<string, double> GetParameters()
            {
                return new Dictionary<string, double> { { "SideALength", SideALength }, { "SideBLength", SideBLength } , { "SideCLength", SideCLength } };
            }

            public void SetParameters(Dictionary<string, double> parameters)
            {
                if (!parameters.TryGetValue("SideALength", out SideALength) || !parameters.TryGetValue("SideBLength", out SideBLength) || !parameters.TryGetValue("SideCLength", out SideCLength))
                {
                    throw new ArgumentException("Invalid parameters for Triangle");
                }
            }

            public int CalculateRequiredDots()
            {
               return (int)Math.Round((SideALength + SideBLength + SideCLength )/ Standard);
               //return (int)Math.Ceiling(Base * Length / 2 / Math.PI * Math.Pow(cellDiameter / 2, 2)) * 6;
               // return (int)Math.Round(Base * Length / 2);
            }
        }*/
}
