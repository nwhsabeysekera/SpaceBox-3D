using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.ShapesService.App_Code
{
    /*public interface IShape
    {
        //Returns a dictionary of parameter names and values for this shape
        Dictionary<string, double> GetParameters();

        //Sets the parameters of the shape using a dictionary of parameter names and values
        void SetParameters(Dictionary<string, double> parameters);

        //Calculates and returns the number of dots required to draw this shape
        int CalculateRequiredDots();
    }*/

    public interface IShape
    {
        //Gets the parameters of the shape
        ShapeParameters GetParameters();

        //Sets the parameters of the shape
        void SetParameters(ShapeParameters parameters);

        //Calculates and returns the number of dots required to draw this shape
        int CalculateRequiredDots();
    }

    public struct ShapeParameters
    {
        public double Radius { get; set; }

        public double Length { get; set; } 
        public double Width { get; set; } 

        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
    }
}