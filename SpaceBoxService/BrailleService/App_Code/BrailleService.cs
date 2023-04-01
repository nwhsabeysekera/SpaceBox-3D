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
        private const string CAPITAL = "⠠";
        private const string NUMBER = "⠼";
        private const string UNRECOGNIZED = "⠿";

        private static Dictionary<char, string> mapLettersToBraille = new Dictionary<char, string>()
        {
            {'a', "⠁"}, {'b', "⠃"}, {'c', "⠉"}, {'d', "⠙"}, {'e', "⠑"}, {'f', "⠋"},
            {'g', "⠛"}, {'h', "⠓"}, {'i', "⠊"}, {'j', "⠚"}, {'k', "⠅"}, {'l', "⠇"},
            {'m', "⠍"}, {'n', "⠝"}, {'o', "⠕"}, {'p', "⠏"}, {'q', "⠟"}, {'r', "⠗"},
            {'s', "⠎"}, {'t', "⠞"}, {'u', "⠥"}, {'v', "⠧"}, {'w', "⠺"}, {'x', "⠭"},
            {'y', "⠽"}, {'z', "⠵"}, {' ', "⠀"}
        };

        private static Dictionary<char, string> mapNumberToBraille = new Dictionary<char, string>()
        {
            {'1', "⠁"}, {'2', "⠃"}, {'3', "⠉"}, {'4', "⠙"},
            {'5', "⠑"}, {'6', "⠋"}, {'7', "⠛"}, {'8',"⠓"},
            {'9', "⠊"}, {'0', "⠚"}
        };

        private static Dictionary<char, string> mapSymbolsToBraille = new Dictionary<char, string>()
        {
            {'*', "⠐⠔"}, {'%', "⠨⠴"}, {'\'', "⠠"}, {'[', "⠨⠣"},
            {']', "⠨⠜" }, {'-', "⠤" }, {'$', "⠈⠎"}, {':', "⠒"},
            {';', "⠆" }, {',',"⠂"}, {'—', "⠠⠤"}, {'…', "⠲⠲⠲"},
            {'!', "⠖"}, {'(', "⠐⠣"}, {')', "⠐⠜"}, {'?', "⠦"},
            {'“', "⠦" }, {'”', "⠴"}, {'+', "⠐⠖"}, {'>', "⠈⠜"},
            {'<', "⠈⠣"}, {'‘', "⠠⠦"}, {'’', "⠠⠴"}, {'.', "⠲"},
            {'@', "⠈⠁"}, {'&', "⠈⠯"}
        };

        private static Dictionary<string, string> mapContractionsToBraille = new Dictionary<string, string>()
        {
            {"but", "⠯"}, {"can", "⠙"}, {"do", "⠥"}, {"every", "⠑⠗⠑⠛⠑"},
            {"from", "⠋⠗⠁⠍"}, {"go", "⠛⠕"}, {"have", "⠓⠁⠧⠑"}, {"just", "⠚⠥⠎"},
            {"knowledge", "⠅⠇⠕⠛⠊⠇⠇⠑⠗⠑"}, {"like", "⠇⠊⠅⠑"}, {"more", "⠍⠕⠗⠑"},
            {"not", "⠝⠕⠞"}, {"people", "⠏⠑⠛⠇⠑"}, {"quite", "⠟⠗⠑⠞⠑"}, {"rather", "⠗⠁⠞⠑⠗"},
            {"so", "⠎⠕"}, {"that", "⠞⠁⠞"}, {"us", "⠥⠎"}, {"very", "⠧⠑⠗⠽"},
            {"it", "⠊⠞"}, {"you", "⠽⠕⠥"}, {"as", "⠁⠎"}, {"and", "⠁⠝⠙"},
            {"for", "⠋⠕⠗"}, {"of", "⠕⠋"}, {"the", "⠞⠓⠑"}, {"with", "⠺⠊⠞"},
            {"will", "⠺⠊⠇⠇"}, {"his", "⠓⠊⠎"}, {"in", "⠊⠝"}, {"was", "⠺⠁⠎"},
            {"to", "⠞⠕"}
        };

        public static List<string> ExtractWords(string input)
        {
            // Split up a sentence based on whitespace (" ") and new line ("\n") chars.
            string[] words = input.Split(new[] { ' ', '\n' });
            return words.ToList();
        }

        public static string NumbersHandler(string input)
        {
            var result = new StringBuilder(input.Length * 2);
            bool isNumberGroupStarted = false;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (char.IsDigit(currentChar))
                {
                    // If the current character is the first digit of a group of digits
                    if (!isNumberGroupStarted)
                    {
                        // Add the escape code for groups of digits
                        result.Append(NUMBER);
                        isNumberGroupStarted = true;
                    }
                    // Add the braille representation of the digit
                    result.Append(mapNumberToBraille[currentChar]);
                }
                else
                {
                    // If a group of digits has just ended
                    if (isNumberGroupStarted)
                    {
                        // End the group by appending the escape code
                        result.Append(NUMBER);
                        isNumberGroupStarted = false;
                    }
                    // Append the current non-digit character
                    result.Append(currentChar);
                }
            }

            // If a group of digits is still open at the end, end it with the escape code
            if (isNumberGroupStarted)
            {
                result.Append(NUMBER);
            }
            return result.ToString();
        }
        public static (string, List<(char, int)>) TrimWord(string input)
        {
            // Define the list of symbols to be removed
            string symbols = "!@#\"$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

            // Create a list of tuples to store the symbols and their positions
            List<(char symbol, int position)> symbolPositions = new List<(char, int)>();

            // Remove symbols from the word and store their positions
            StringBuilder trimmedWord = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (!symbols.Contains(input[i]))
                {
                    trimmedWord.Append(input[i]);
                }
                else
                {
                    symbolPositions.Add((input[i], i));
                }
            }
            // Pad the trimmed word with spaces to match the length of the input string
            trimmedWord.Append(' ', input.Length - trimmedWord.Length);

            return (trimmedWord.ToString(), symbolPositions);
        }
        public static string ContractionsHandler(string input, List<(char, int)> symbolPositions)
        {
            StringBuilder result = new StringBuilder();
            if (input == "\n")
                result.Append("\n");
            else if (string.IsNullOrEmpty(input))
            {
                result.Append(" ");
            }
            else
            {
                string simpleWord = input.ToLower();
                if (mapContractionsToBraille.ContainsKey(simpleWord))
                {
                    string brailleWord = mapContractionsToBraille[simpleWord];
                    result.Append(brailleWord);

                    // Update the positions of the symbols in the symbolPositions list
                    for (int i = 0; i < brailleWord.Length; i++)
                    {
                        if (symbolPositions.Count > 0 && symbolPositions[0].Item2 == i)
                        {
                            symbolPositions.RemoveAt(0);
                        }
                    }
                }
                else
                {
                    result.Append(input);
                }
            }
            return result.ToString();
        }

        public static bool IsBraille(string character)
        {
            // Return true if a char is braille.
            if (character.Length > 1)
            {
                return false;
            }

            return mapLettersToBraille.ContainsValue(character)
                || mapNumberToBraille.ContainsValue(character)
                || mapSymbolsToBraille.ContainsValue(character)
                || mapContractionsToBraille.ContainsValue(character)
                || character == CAPITAL
                || character == NUMBER;
        }

        public static string LettersHandler(string input, List<(char, int)> symbolPositions)
        {
            StringBuilder result = new StringBuilder(input.Length * 2); // Initialize the StringBuilder with a capacity of twice the input string length
            if (input == "\n")
                result.Append("\n");
            else if (string.IsNullOrEmpty(input))
            {
                result.Append(" ");
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char c = input[i];
                    // Check if the character is a braille code
                    if (IsBraille(c.ToString()))
                    {
                        result.Append(c.ToString());
                    }
                    //check if the character is empty
                    else if (char.IsWhiteSpace(c))
                    {
                        result.Append(c);
                    }
                    //handel Capital letters
                    else if (char.IsUpper(c))
                    {
                        c = char.ToLower(c);
                        string brailleChar = CAPITAL + mapLettersToBraille[c];
                        result.Append(brailleChar);

                        // Update the positions of the symbols in the symbolPositions list
                        for (int j = 0; j < brailleChar.Length; j++)
                        {
                            int position = i + j;
                            if (symbolPositions.Count > 0 && symbolPositions[0].Item2 == position)
                            {
                                symbolPositions[0] = (symbolPositions[0].Item1, i + j);
                            }
                        }
                    }
                    //handel simple letters
                    else if (char.IsLower(c))
                    {
                        result.Append(mapLettersToBraille[c]);
                    }
                    //handel  UNRECOGNIZED code
                    else
                    {
                        result.Append(UNRECOGNIZED);
                    }
                }
            }
            return result.ToString();
        }

        public static string Addshavings(string input, List<(char, int)> symbolPositions)
        {
            // Insert the symbols back into their original positions
            StringBuilder result = new StringBuilder(input);
            foreach ((char symbol, int position) in symbolPositions)
            {
                if (position < input.Length)
                {
                    result.Insert(position, symbol);
                }
            }

            return result.ToString();
        }

        public static string SymbolHandler(string input)
        {
            StringBuilder result = new StringBuilder();
            bool openQuote = false;
            if (input == "\n")
                result.Append("\n");
            else if (string.IsNullOrEmpty(input))
            {
                result.Append(" ");
            }
            else
            {
                foreach (char c in input)
                {
                    if (c == '\"')
                    {
                        if (openQuote)
                        {
                            openQuote = !openQuote;
                            result.Append(mapSymbolsToBraille['”']);
                        }
                        else
                        {
                            openQuote = !openQuote;
                            result.Append(mapSymbolsToBraille['“']);
                        }
                    }
                    else if (mapSymbolsToBraille.ContainsKey(c))
                    {
                        result.Append(mapSymbolsToBraille[c]);
                    }
                    else
                    {
                        result.Append(c);
                    }
                }
            }
            return result.ToString();
        }

        public string ConvertTextToBraille(string input)
        {
            List<string> words = ExtractWords(input);
            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {
                string numconverted = NumbersHandler(word);
                var (trimmedWord, symbolPositions) = TrimWord(numconverted);
                string contractionsconverted = ContractionsHandler(trimmedWord, symbolPositions);
                string lettersconverted = LettersHandler(contractionsconverted, symbolPositions);
                string addedshavings = Addshavings(lettersconverted, symbolPositions);
                string symboleshandeled = SymbolHandler(addedshavings);

                result.Append(symboleshandeled);
                result.Append(" "); // add space between words
            }

            return result.ToString().Trim(); // remove trailing space
        }
    }
}