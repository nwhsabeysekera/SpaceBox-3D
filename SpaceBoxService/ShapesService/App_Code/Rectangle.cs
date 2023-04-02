﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.ShapesService.App_Code
{
    public class Rectangle : IShape
    {
        private double Width;
        private double Length;
        private double cellDiameter;

        public Rectangle()
        {
            Width = 0;
            Length = 0;
            cellDiameter = 1.5;
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
            return (int)Math.Ceiling(Length * Width / Math.PI * Math.Pow(cellDiameter / 2, 2)) * 6;
            //return (int)Math.Round(Width * Length);
        }
    }
}