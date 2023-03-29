using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SpaceBoxService.ShapeService
{
    /// <summary>
    /// Summary description for ShapeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ShapeService : System.Web.Services.WebService
    {

        public interface IShape
        {
            void LoadParameters();
            int CalculateDots();
        }

         public class Rectangle : IShape
         {
             public void LoadParameters()
             {
                 // Load rectangle parameters
                 Width = LoadRectangleWidthFromService();
                 Length = LoadRectangleLengthFromService();
             }

             public int CalculateDots()
             {
                 // Calculate dots for rectangle
                 return Width * Length;

             }

             private int LoadRectangleWidthFromService()
             {
                // Load rectangle width from service
                Width = LoadRectangleWidthFromService();

             }

             private int LoadRectangleLengthFromService()
             {
                // Load rectangle length from service
                Length = LoadRectangleLengthFromService();
                 return 0;
             }
         }

         public class Circle : IShape
         {
             public void LoadParameters()
             {
                 // Load circle parameters
                 Radius = LoadCircleRadiusFromService();

             }

             public int CalculateDots()
             {
                 // Calculate dots for circle
                 return (int)(Math.PI * Math.Pow(Radius, 2));

             }
         }

         public class Triangle : IShape
         {
             public void LoadParameters()
             {
                 // Load triangle parameters
                 Base = LoadTriangleBaseLengthFromService();
                 Length = LoadTriangleLengthFromService();
             }

             public int CalculateDots()
             {
                 // Calculate dots for triangle
                 return (int)(0.5 * Base * Length);

             }
         }

         public class ShapeFactory
         {
             public IShape GetShape(string SelectShape)
             {
                 switch (SelectShape.ToLower())
                 {
                     case "rectangle":
                         return new Rectangle();
                     case "circle":
                         return new Circle();
                     case "triangle":
                         return new Triangle();
                     default:
                         throw new ArgumentException("Invalid shape type.");
                 }
             }

         }
        
    }

}
       
    

