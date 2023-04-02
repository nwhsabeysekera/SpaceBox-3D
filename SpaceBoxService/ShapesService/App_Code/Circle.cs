﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.ShapesService.App_Code
{
    public class Circle : IShape
    {
        private double Radius;
        private double CenterX;
        private double CenterY;
        private double cellDiameter;

        public Circle()
        {
            Radius = 0;
            CenterX = 0;
            CenterY = 0;
            cellDiameter = 1.5;
        }

        //Returns a dictionary with the parameter name "Radius" and the current value of the radius
        public Dictionary<string, double> GetParameters()
        {
            return new Dictionary<string, double> { { "Radius", Radius } };//{ "CenterX", CenterX }, { "CenterY", CenterY } };
        }

        //Sets the radius of the circle using the "Radius" key in the parameters dictionary
        public void SetParameters(Dictionary<string, double> parameters)
        {
            if (!parameters.TryGetValue("Radius", out Radius))//|| !parameters.TryGetValue("CenterX", out CenterX) || !parameters.TryGetValue("CenterY", out CenterY))
            {
                throw new ArgumentException("Invalid parameters for Circle");
            }
        }

        //Calculates and returns the number of dots required to draw the circle
        public int CalculateRequiredDots()
        {
            return (int)Math.Ceiling((2 * Radius * Math.PI) / cellDiameter) * 6;
            //return (int)Math.Round(Math.PI * Radius * Radius);
            //return (int)Math.Round((Math.PI * Radius * Radius) + (2 * Math.PI * Radius * Math.Sqrt(Math.Pow(CenterX, 2) + Math.Pow(CenterY, 2))));

        }
    }
}