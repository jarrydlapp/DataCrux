using DataCrux.Randomizer;

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
        private string AreaCode { get; set; }
        private string Prefix { get; set; }
        private string LineNumber { get; set; }

        public PhoneNumber()
        {
            GeneartePhoneNumberItems();
            AreaCode = _areacode;
            Prefix = _prefix;
            LineNumber = _linenumber;
            Number = $"{AreaCode}{Prefix}{LineNumber}";
           
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

        /// <summary>
        /// Returns the phone number formatted ###-###-####
        /// </summary>
  
        /// <returns></returns>
        public string Formatted()
        {
            return $"{AreaCode}-{Prefix}-{LineNumber}";
        }  
    }
}
