using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JWHDM
{
   public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public static string FirstLetterToUpper(this string str)
        {
            if (str == null)
                return null;
            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);
            return str.ToUpper();
        }

        //CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
    }
}
