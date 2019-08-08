using DataCrux.BaseGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCrux.Name
{ 
    public class PersonName : BaseDataGenerator
    {       
          public enum Gender
        {
            Male = 1,
            Female = 0
        }
        internal bool IsMaleName = false;
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        public string Suffix { get; set; }
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
                      
        public string GenerateFirstName()
        {
            return !IsMaleName
                ? GenerateFemaleFirstName()
                : GenerateMaleFirstName();

        }
        public string GenerateLastName()
        {
            return _lastNames.AsEnumerable().ElementAt(RandGen.Next(0, _lastNames.Count));
        }
        public string GenerateMiddleName()
        {
            return !IsMaleName
                ? GenerateFemaleFirstName()
                : GenerateMaleFirstName();
        }
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
