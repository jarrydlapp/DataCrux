using DataCrux.PhoneNumberGenerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrux.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Returns the Phone Number unformatted ##########
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Formatted(this PhoneNumber str)
        {
            return str.NumberFormatted;                
        }
        /// <summary>
        /// Returns the Phone Number formatted ###-###-####
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UnFormatted(this PhoneNumber str)
        {
            return str.Number;
        }
        /// <summary>
        /// Returns a string parsed as a num.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ParseToInt(this string str)
        {
            var n = 0;
            int.TryParse(str, out n);
            return n;
        }

        public static string UppercaseWords(this string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

    }
}
