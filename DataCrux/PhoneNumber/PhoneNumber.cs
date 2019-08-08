using DataCrux.Randomizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrux.PhoneNumberGenerator
{
    public class PhoneNumber
    {
        private string _areacode { get; set; }
        private string _prefix { get; set; }
        private string _linenumber { get; set; }
        /// <summary>
        /// Returns Unformated Phone Number ##########
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Returns formatted Phone Number ###-###-####
        /// </summary>
        public string NumberFormatted { get; set; }
        public string AreaCode { get; set; }
        public string Prefix { get; set; }
        public string LineNumber { get; set; }

        public PhoneNumber()
        {
            GeneartePhoneNumberItems();
            AreaCode = _areacode;
            Prefix = _prefix;
            LineNumber = _linenumber;
            Number = $"{AreaCode}{Prefix}{LineNumber}";
            NumberFormatted = $"{AreaCode}-{Prefix}-{LineNumber}";
        }
        /// <summary>
        /// Generate the Random segments of the phonenumber
        /// </summary>
        private void GeneartePhoneNumberItems()
        {
            _areacode = DataRandomizer.GenearteRandomNumber(3);
            _prefix = DataRandomizer.GenearteRandomNumber(3);
            _linenumber = DataRandomizer.GenearteRandomNumber(4);
        }

        

    }
}
