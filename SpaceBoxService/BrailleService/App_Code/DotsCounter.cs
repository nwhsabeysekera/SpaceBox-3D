using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBoxService.BrailleService.App_Code
{
    public class DotsCounter
    {
        public static int GetDotsAmount(string input)
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

            return DotAmount;
            
        }
    }
}