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
            Console.WriteLine("Enter the text you want to convert to Braille:");
            string input = Console.ReadLine();

            //create an instance of the ConvertTextToBraille class in the MainClass class file
            ConvertTextToBraille obj = new ConvertTextToBraille();

            //call TranslateToBraille method
            string output = obj.TranslateToBraille(input);

            //display the output to the user
            Console.WriteLine("The Braille translation is:");
            Console.WriteLine(output);

            //wait for user input before closing the console window
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
