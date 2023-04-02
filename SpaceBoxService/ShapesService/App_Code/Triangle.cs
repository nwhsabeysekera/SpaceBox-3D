using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.ShapesService.App_Code
{
    public class Triangle : IShape
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
        }
    }
