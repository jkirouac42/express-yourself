using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpressYourself               //  3 groups all covered Type\:(.*),Title\: (.*),+(.*)
{                                       // Title\: (.*),+    working code
    public class Parser                 // working code plus length Title\: (.*),+(.*)
    {
        /// <summary>
        /// Looks for a title in a Media file string.
        /// </summary>
        /// <param name="str">The string to search</param>
        /// <returns>the title string if it exists</returns>
        public static string GetTitle(string str)
        {
            var titleExpression = new Regex(@"Title\: (.*),+");
            var match = titleExpression.Match(str);
            if (!match.Success)
            {
                return "Title Not Found";  
            }
            else
            {
                return match.Groups[1].Value;
            }
        }

        public static string GetType(string str)
        {
            var typeExpression = new Regex(@"Type\: (.*),Title\: (.*),");
            var type = typeExpression.Match(str);
            if (!type.Success)
            {
                return "Type not found";
            }

            else return type.Groups[1].Value;
        }

        public static string GetLength(string str)
        {
            var lengthExpression = new Regex(@",Length\: (.*)");
            var length = lengthExpression.Match(str);
            if (!length.Success)
            {
                return "  ";
            }
            else
            {
                return length.Groups[1].Value;
            }
        }

        public static bool IsValidLine(string str)
        {

            var validExpression = new Regex(@"Type\: (.*),Title\: (.*),Length\: (.*)");
            var valid = validExpression.Match(str);
            if (!valid.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
                
        }
    }
}
