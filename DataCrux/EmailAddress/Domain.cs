using DataCrux.Randomizer;
using System;

namespace DataCrux.Email

    /// <summary>
    /// Generates a random Top-Level Domain and Node to be added to an email address.
    /// </summary>
{   internal class Domain
    {
        //Preset list of common Top-Level Domains  (excluded .gov & .mil for security reasons).
        private readonly string[] _topleveldomains = { ".com", ".net", ".org", ".edu"};
        private Random RandGen = new Random();
        public string SecondLevelDomain  { get;}
        public string TopLevelDomain { get; }
            
        public Domain()
        {
            SecondLevelDomain = GenerateRandomSecondLevelDomain();
            TopLevelDomain = GetRandomTopLevelDomain();
        }
        public Domain(string secondLevelDomain)
        {

            SecondLevelDomain = FormatSecondLevelDomain(secondLevelDomain);
            TopLevelDomain = ".com";
        }

        private string FormatSecondLevelDomain(string secondLevelDomain)
        {

           if(secondLevelDomain.Contains("&"))
            {
                secondLevelDomain = secondLevelDomain.Replace("&", "and");
            }
           if(secondLevelDomain.Contains("."))
            {
                secondLevelDomain = secondLevelDomain.Replace(".", "");
            }
           if(secondLevelDomain.Contains(","))
            {
                secondLevelDomain = secondLevelDomain.Replace(",", "");

            }
           if(secondLevelDomain.Contains(" "))
            {
                secondLevelDomain = secondLevelDomain.Replace(" ", "");
            }           
            

            return secondLevelDomain;
        }

        /// <summary>
        /// Gets a random TopLevelDomain from a list of preset strings
        /// </summary>
        /// <returns></returns>
        private string GetRandomTopLevelDomain()
        {        
            return _topleveldomains[RandGen.Next(0, _topleveldomains.Length)];
        }
        /// <summary>
        /// Generates a random alpha lower string with a length of 10
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomSecondLevelDomain()
        {  
            return DataRandomizer.GenearteRandomString(10).ToLower();
        }


    }
}
