using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBox_3D.BrailleConvertor
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            string input = "Hello world!";
            //create a instance of the ConvertTextToBraille class in the MainClass class file
            ConvertTextToBraille obj = new ConvertTextToBraille();
            //call SplitIntoComponents method
            string output = obj.TrasnlateToBraille(input);
            //output the method
            Console.WriteLine(output);
        }

    }
}