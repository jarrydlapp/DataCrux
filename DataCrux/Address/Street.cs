using System.Collections.Generic;
using DataCrux.Extensions;
using DataCrux.BaseGenerator;
using System.Linq;

namespace DataCrux.Address
{
    public class Street : BaseDataGenerator
    {
        private const string PrefixFile = "dist.street.prefix.stripped";
        private const string StreetNameFile = "dist.street.name.stripped";
        private const string SuffixFile = "dist.street.suffix.stripped";
        private ICollection<string> _prefixs;
        private ICollection<string> _streetNames;
        private ICollection<string> _suffixs;

        public string Prefix { get; set; }
        public string Name { get; set; }
        public string Suffix { get; set; }
              
        public Street()
        {
            InitStreet();
            Prefix = GeneratePrefix();
            Name = GenerateStreetName();
            Suffix = GenerateStreetSuffix();
        }

        //Generate Random Prefix Can Be Bool
        private bool RandomlyPickIfPrefixWillBeIncluded() => RandGen.Next(0, 2) == 0;
        
        // if prefix is true generate prefix
        // then generate random street name
        // then generate random suffix
        private string GeneratePrefix()
        {
            return !RandomlyPickIfPrefixWillBeIncluded()
                ? GenerateStreetPrefix()
                : null;
        }
        private string GenerateStreetName()
        {  
            var index = RandGen.Next(0, _streetNames.Count);

            return _streetNames.AsEnumerable().ElementAt(index).ToLower().UppercaseWords();
        }
        private string GenerateStreetSuffix()
        {
            var index = RandGen.Next(0, _suffixs.Count);

            return _suffixs.AsEnumerable().ElementAt(index).ToLower().UppercaseWords();
        }
        private string GenerateStreetPrefix()
        {
            var index = RandGen.Next(0, _prefixs.Count);

            return _prefixs.AsEnumerable().ElementAt(index).ToLower().UppercaseWords();
        }
        /// <summary>
        /// Get the values from the resource files
        /// </summary>
        private void InitStreet()
        {     
            if (_prefixs == null)
                _prefixs = ReadResourceByLine(PrefixFile);
            if (_streetNames == null)
                _streetNames = ReadResourceByLine(StreetNameFile);
            if (_suffixs == null)
                _suffixs = ReadResourceByLine(SuffixFile);
        }
    }
}



