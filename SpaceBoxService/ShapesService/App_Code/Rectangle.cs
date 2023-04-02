using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.ShapesService.App_Code
{
    public class Rectangle : IShape
    {
        private double length;
        private double width;

        public Rectangle()
        {
            length = 0;
            width = 0;
        }

        public ShapeParameters GetParameters()
        {
            return new ShapeParameters { Length = length, Width = width };
        }

        public void SetParameters(ShapeParameters parameters)
        {
            length = parameters.Length;
            width = parameters.Width;
        }

        public int CalculateRequiredDots()
        {
            //standard diameter of a braille dot (1.6mm) + standard space between two braille dots (2.5mm)
            double standard = 4.1;
            return (int)Math.Round(((width*2)+(length*2))/standard);
        }
    }

    /*public class Rectangle : IShape
    {
        private double Width;
        private double Length;
        private double Standard;

        public Rectangle()
        {
            Width = 0;
            Length = 0;
            Standard = 2.5;
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
            return (int)Math.Round((Width + Width + Length + Length) / Standard);
            //return (int)Math.Ceiling(Length * Width / Math.PI * Math.Pow(cellDiameter / 2, 2)) * 6;
        }
    }*/
}