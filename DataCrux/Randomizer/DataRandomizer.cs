using System;
using System.Linq;


namespace DataCrux.Randomizer
{
    public static class DataRandomizer
    {
        private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string numbers = "0123456789";
        private const string characters = "!#$%&'*+-/=?^_`{|}~";

        private static Random random = new Random();

        public static string GenearteRandomString(int length)
        {            
            return new string(Enumerable.Repeat(letters, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenearteRandomNumber(int length)
        {            
            return new string(Enumerable.Repeat(numbers, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}

