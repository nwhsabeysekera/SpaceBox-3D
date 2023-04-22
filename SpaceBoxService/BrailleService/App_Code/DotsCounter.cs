using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.BrailleService.App_Code
{
    public class DotsCounter
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        private DotsCounter() { }

        private static readonly DotsCounter instance = new DotsCounter();

        public static DotsCounter Instance 
        { 
            get 
            {  
                return instance; 
            } 
        }

        public int GetDotsAmount(string input)
        {
            int DotAmount = 0;

            foreach(char c in input)
            {
                switch (c)
                {
                    case '⠀':
                        DotAmount += 0;
                        break;

                    case '⠁':
                    case '⠂':
                    case '⠄':
                    case '⠈':
                    case '⠐':
                    case '⠠':
                        DotAmount += 1;
                        break;

                    case '⠃':
                    case '⠅':
                    case '⠉':
                    case '⠑':
                    case '⠡':
                    case '⠆':
                    case '⠊':
                    case '⠒':
                    case '⠢':
                    case '⠌':
                    case '⠔':
                    case '⠤':
                    case '⠘':
                    case '⠨':
                    case '⠰':
                        DotAmount += 2;
                        break;

                    case '⠇':
                    case '⠋':
                    case '⠍':
                    case '⠎':
                    case '⠓':
                    case '⠕':
                    case '⠖':
                    case '⠙':
                    case '⠚':
                    case '⠜':
                    case '⠣':
                    case '⠥':
                    case '⠦':
                    case '⠩':
                    case '⠪':
                    case '⠬':
                    case '⠱':
                    case '⠲':
                    case '⠴':
                    case '⠸':
                        DotAmount += 3;
                        break;
                   
                    case '⠏':
                    case '⠗':
                    case '⠛':
                    case '⠝':
                    case '⠞':
                    case '⠧':
                    case '⠫':
                    case '⠭':
                    case '⠮':
                    case '⠳':
                    case '⠵':
                    case '⠶':
                    case '⠹':
                    case '⠺':
                    case '⠼':
                        DotAmount += 4;
                        break;

                    case '⠟':
                    case '⠯':
                    case '⠷':
                    case '⠻':
                    case '⠽':
                    case '⠾':
                        DotAmount += 5;
                        break;

                    case '⠿':
                        DotAmount += 6;
                        break;

                    default:
                        DotAmount += 0;
                        break;
                }
            }
            Logger.Info("Calculate required Dot-amount for The Braille Translator.");
            return DotAmount;
            
        }
    }
}