using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.ShapesService.App_Code
{
    public class Triangle : IShape
    {
            private double Base;
            private double Length;
            private double cellDiameter;

            public Triangle()
            {
                Base = 0;
                Length = 0;
                cellDiameter = 1.5;
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
                return (int)Math.Ceiling(Base * Length / 2 / Math.PI * Math.Pow(cellDiameter / 2, 2)) * 6;
                // return (int)Math.Round(Base * Length / 2);
            }
        }
    }
