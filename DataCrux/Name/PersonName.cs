using DataCrux.BaseGenerator;
using System.Collections.Generic;
using System.Linq;

namespace DataCrux.Name
{ 
    public class PersonName : BaseDataGenerator
    {       
        public enum Gender
        {
            Male = 1,
            Female = 0
        }

        private bool IsMaleName = false;
        /// <summary>
        /// Randomized First Name
        /// </summary>
        public string First { get; set; }
        /// <summary>
        /// Randomized Middle Name
        /// </summary>
        public string Middle { get; set; }
        /// <summary>
        /// Randomized Last Name
        /// </summary>
        public string Last { get; set; }
        /// <summary>
        /// Randomized Suffix
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// Randomized Gender
        /// </summary>
        public Gender Sex { get; set; }

        private const string MaleFile = "dist.male.first.stripped";
        private const string FemaleFile = "dist.female.first.stripped";
        private const string LastNameFile = "dist.all.last.stripped";
        private const string MaleSuffixFile = "dist.male.suffix.stripped";
        private ICollection<string> _maleFirstNames;
        private ICollection<string> _femaleFirstNames;
        private ICollection<string> _maleMiddleNames;
        private ICollection<string> _femaleMiddleNames;
        private ICollection<string> _maleSuffix;
        private ICollection<string> _lastNames; 
        
        public PersonName()
        {
            InitNames();
            IsMaleName = RandomlyPickIfNameIsMale();
            First = GenerateFirstName();
            Middle = GenerateMiddleName();
            Last = GenerateLastName();
            Suffix = GenerateSuffix(); 
        }             

        private bool RandomlyPickIfNameIsMale()
        {
            IsMaleName = RandGen.Next(0, 2) == 0;
            return IsMaleName;
        }

        /// <summary>
        /// Returns full name of a person
        /// </summary>
        /// <returns></returns>
        public string GetFullName()
        {
            if (string.IsNullOrEmpty(Suffix))
            {
                return $"{First} {Middle} {Last}";
            }
            return $"{First} {Middle} {Last}, {Suffix}";
        }

        /// <summary>
        /// Allows you to generate new first name
        /// </summary>
        /// <returns></returns>
        public string GenerateFirstName()
        {
            return !IsMaleName
                ? GenerateFemaleFirstName()
                : GenerateMaleFirstName();
        }

        /// <summary>
        /// Allows you to generate new last name
        /// </summary>
        /// <returns></returns>
        public string GenerateLastName()
        {
            return _lastNames.AsEnumerable().ElementAt(RandGen.Next(0, _lastNames.Count));
        }

        /// <summary>
        /// Allows you to generate new middle dame
        /// </summary>
        /// <returns></returns>
        public string GenerateMiddleName()
        {
            return !IsMaleName
                ? GenerateFemaleFirstName()
                : GenerateMaleFirstName();
        }

        /// <summary>
        /// Allows you to generate new suffix
        /// </summary>
        /// <returns></returns>
        public string GenerateSuffix()
        {
            if(Sex.Equals(Gender.Male))
            {
                return GenerateMaleSuffix();
            }
            return null;
        }

        private string GenerateFemaleFirstName()
        {
            var index = RandGen.Next(0, _femaleFirstNames.Count);                       
            Sex = Gender.Female;
            
            return _femaleFirstNames.AsEnumerable().ElementAt(index);
        }

        private string GenerateMaleFirstName()
        {
            var index = RandGen.Next(0, _maleFirstNames.Count);
            Sex = Gender.Male;
            
            return _maleFirstNames.AsEnumerable().ElementAt(index);
        }

        private string GenerateFemaleMiddleName()
        {
            var index = RandGen.Next(0, _femaleMiddleNames.Count);

            return _femaleMiddleNames.AsEnumerable().ElementAt(index);
        }

        private string GenerateMaleMiddleName()
        {
            var index = RandGen.Next(0, _maleMiddleNames.Count);

            return _maleFirstNames.AsEnumerable().ElementAt(index);
        }

        private string GenerateMaleSuffix()
        {
            var index = RandGen.Next(0, _maleSuffix.Count);

            return _maleSuffix.AsEnumerable().ElementAt(index);
        }

        private void InitNames()
        {
            if (_maleFirstNames == null)
                _maleFirstNames = ReadResourceByLine(MaleFile);
            if (_maleMiddleNames == null)
                _maleMiddleNames = ReadResourceByLine(MaleFile);
            if (_maleSuffix == null)
                _maleSuffix = ReadResourceByLine(MaleSuffixFile);

            if (_femaleFirstNames == null)
                _femaleFirstNames = ReadResourceByLine(FemaleFile);
            if (_femaleMiddleNames == null)
                _femaleMiddleNames = ReadResourceByLine(FemaleFile);
            if (_lastNames != null)
                return;

            _lastNames = ReadResourceByLine(LastNameFile);
        }
    }
}
