using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SpaceBoxService.BrailleService.App_Code
{
    public class BrailleService
    {
        public string[] SplitStringIntoComponents(string input)
        {
            // Split the input string into components
            // splitting by White-spaces, new-line characters, tab-space, and ect.
            string[] components = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return components;
        }

        //Put the capital escape code before each capital letter
        public string AddCapitalEscapeCode(string input)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (Char.IsUpper(c))
                {
                    output += "⠠";
                }

                output += c;
            }

            return output;
        }

        public string RemoveSymbolsAndPunctuation(string input)
        {
            // Define a list of punctuation and symbol characters to remove
            char[] symbolsAndPunctuation = new char[] { ' ', ',', '.', ';', ':', '!', '?', '(', ')', '[', ']', '{', '}', '<', '>', '/', '\\', '\'', '\"', '@', '#', '$', '%', '^', '&', '*', '_', '+', '=', '`', '~' };

            // Remove the symbols and punctuation characters from the input string
            string output = new string(input.Where(c => !symbolsAndPunctuation.Contains(c)).ToArray());

            return output;
        }

        //Convert char to braille.
        public string ConvertCharTobraille(string input)
        {
            string jsonfile = File.ReadAllText("C:\\Users\\Hasini\\OneDrive\\Desktop\\github\\assignment\\SpaceBox-3D\\SpaceBoxService\\BrailleService\\App_Code\\MapTextToBraille.json");
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonfile);


            // Check if char is present in any of the dictionaries
            if (dictionary["letters_to_braille"].ContainsKey(input))
            {
                return dictionary["letters_to_braille"][input];
            }
            else if (dictionary["numbers_to_braille"].ContainsKey(input))
            {
                return dictionary["numbers_to_braille"][input];
            }
            else if (dictionary["symbols_to_braille"].ContainsKey(input))
            {
                return dictionary["symbols_to_braille"][input];
            }
            else if (dictionary["contractions_to_braille"].ContainsKey(input))
            {
                return dictionary["contractions_to_braille"][input];
            }
            else
            {
                // If component is not present in any dictionary, return null
                return null;
            }
        }

        public string ReattachSymbolsAndPunctuation(string component, string translatedTrimmedComponent)
        {
            // Create a StringBuilder to hold the final output
            StringBuilder output = new StringBuilder();

            // Iterate over each character in the original component
            for (int i = 0; i < component.Length; i++)
            {
                char c = component[i];

                // If the character is a symbol or punctuation mark, add it to the output
                if (!Char.IsLetterOrDigit(c))
                {
                    output.Append(c);
                }
                else
                {
                    // Otherwise, add the corresponding braille character to the output
                    output.Append(translatedTrimmedComponent[0]);
                    // Remove the corresponding braille character from the translatedTrimmedComponent
                    translatedTrimmedComponent = translatedTrimmedComponent.Remove(0, 1);
                }
            }

            return output.ToString();
        }


        //convert text to braille
        public string TrasnlateToBraille(string input)
        {
            // Split input into components based on white space and \n
            string[] components = SplitStringIntoComponents(input);

            // Initialize an empty list to store braille translations of each component
            List<string> brailleList = new List<string>();

            // Iterate over each component
            foreach (string component in components)
            {
                // Remove symbols and punctuation from component
                string trimmedComponent = RemoveSymbolsAndPunctuation(component);

                //Put the capital escape code before each capital letter
                string capitalizedcomponents = AddCapitalEscapeCode(trimmedComponent);

                // Translate trimmed component to braille
                string translatedTrimedComponents = ConvertCharTobraille(capitalizedcomponents);

                // Reattach symbols and punctuation to braille
                string ReattachedFullcomponents = ReattachSymbolsAndPunctuation(component, translatedTrimedComponents);

                // Add final braille to the list of braille translations
                brailleList.Add(ReattachedFullcomponents);
            }

            // Join the braille translations of each component into a single string
            string brailleText = string.Join(" ", brailleList);

            return brailleText;
        }
    }
}