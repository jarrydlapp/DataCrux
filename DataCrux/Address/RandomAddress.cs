using DataCrux.Randomizer;
using System;
using System.Collections.Generic;
using System.Linq;
using DataCrux.Extensions;
using DataCrux.BaseGenerator;

namespace DataCrux.Address
{
    /// <summary>
    /// Generates a random US address
    /// </summary>
    public class RandomAddress : BaseDataGenerator
    {
        private const string _deliminator = "|";
        private const string CityFile = "dist.citystate.stripped";
        private ICollection<string>  _citystatezip;
        private string cityStateZipLine;
        public string Number { get; set; }
        public Street Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
      
        public RandomAddress()
        {
            Number = DataRandomizer.GenearteRandomNumber(GenerateNumberLength());
            Street = new Street();
            GetRandomCityStateZip();
            City = GetCityFromLine();
            State = GetStateFromLine();
            Zipcode = GetZipFromLine();
        }
        /// <summary>
        /// Generate the random length of the address box number
        /// </summary>
        /// <returns></returns>
        private int GenerateNumberLength()
        {
            int length;
            do
            {
                 length = Convert.ToInt32(DataRandomizer.GenearteRandomNumber(1));                          
            }
            while (length == 0 || length > 5);
            {
                return length;
            }            
        }
        /// <summary>
        /// Gets the 2 letter State Abbrivation from resource line
        /// </summary>
        /// <returns></returns>
        private string GetStateFromLine()
        {
            return cityStateZipLine.Split(_deliminator)[1]; 
        }
        /// <summary>
        /// Gets a random city from the resource line
        /// resouce file
        /// </summary>
        /// <returns></returns>
        private string GetCityFromLine()
        {
            return cityStateZipLine.Split(_deliminator)[0].UppercaseWords();
        }
        /// <summary>
        /// Gets the zipcode from the resource file line selected
        /// </summary>
        /// <returns></returns>
        private string GetZipFromLine()
        {
            return cityStateZipLine.Split(_deliminator)[2];
        }

        /// <summary>
        /// Gets the random city, state, zip line from the resource file
        /// </summary>
        private void GetRandomCityStateZip()
        {
            if (_citystatezip == null)
                _citystatezip = ReadResourceByLine(CityFile);
            var index = RandGen.Next(0, _citystatezip.Count);
            cityStateZipLine = _citystatezip.AsEnumerable().ElementAt(index);

          
        }       
        /// <summary>
        /// Returns the Address City
        /// </summary>
        /// <returns></returns>
        internal string GetCity()
        {
            return City;
        }
        /// <summary>
        /// Returns the Address State
        /// </summary>
        /// <returns></returns>
        internal string GetState()
        {
            return State;
        }
        /// <summary>
        /// Returns the Address Zipcode
        /// </summary>
        /// <returns></returns>
        internal string GetZipcode()
        {
            return Zipcode;
        }
        /// <summary>
        /// Returns formatted line
        /// City, State Zipcode
        /// </summary>
        /// <returns></returns>
        internal string GetCityStateZip()
        {
            return $"{City}, {State} {Zipcode}";
        }
        /// <summary>
        /// Returns formatted Street Line
        /// Number  Prefix Street Name  Suffix 
        /// {Prefix will be added if one was generated}
        /// </summary>
        /// <returns></returns>
        internal string GetStreet()
        {
             return Street.Prefix == null 
                ? $"{Number} {Street.Name} {Street.Suffix}" 
                : $"{Number} {Street.Prefix} {Street.Name} {Street.Suffix}";
        }
        /// <summary>
        /// Returns full address
        /// </summary>
        /// <returns></returns>
        public string GetFullAddress()
        {
            return Street.Prefix == null
               ? $"{Number} {Street.Name} {Street.Suffix} \n{City}, {State} {Zipcode}"
               : $"{Number} {Street.Prefix} {Street.Name} {Street.Suffix} \n{City}, {State} {Zipcode}";
        }
   
    }
}

