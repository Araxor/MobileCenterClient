using System;
using System.Collections.Generic;
using System.Text;

namespace MobileCenterClient.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string FirstCharToLower(this string str)
        {
            if (String.IsNullOrEmpty(str) || Char.IsLower(str, 0))
            {
                return str;
            }

            return Char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        public static string FirstCharToUpper(this string str)
        {
            if (String.IsNullOrEmpty(str) || Char.IsUpper(str, 0))
            {
                return str;
            }

            return Char.ToUpperInvariant(str[0]) + str.Substring(1);
        }
    }
}
