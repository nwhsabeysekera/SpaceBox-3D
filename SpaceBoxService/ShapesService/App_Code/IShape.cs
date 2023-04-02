using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.ShapesService.App_Code
{
    public interface IShape
    {
        //Returns a dictionary of parameter names and values for this shape
        Dictionary<string, double> GetParameters();

        //Sets the parameters of the shape using a dictionary of parameter names and values
        void SetParameters(Dictionary<string, double> parameters);

        //Calculates and returns the number of dots required to draw this shape
        int CalculateRequiredDots();
    }
}