using DataCrux.BaseGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCrux.Employer
{
    public class CompanyName : BaseDataGenerator
    {
        public string Employer { get; set; }

        private const string CompanyNameFile = "dist.companynames.stripped";
        private ICollection<string> _companyNames;


        public CompanyName()
        {
            InitCompanyName();
            Employer = GenerateCompanyName();
        }

        private string GenerateCompanyName()
        {
            var index = RandGen.Next(0, _companyNames.Count);

            return _companyNames.AsEnumerable().ElementAt(index);
        }

        private void InitCompanyName()
        {
            if (_companyNames == null)
                _companyNames = ReadResourceByLine(CompanyNameFile);
        }
    }
}
