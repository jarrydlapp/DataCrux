using DataCrux.Address;
using DataCrux.Email;
using DataCrux.PhoneNumberGenerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataCrux.Employer
{
    public class EmployerInfo
    {
        private PhoneNumber WorkPhoneNumber { get; set; }

        public string CompanyName { get; set; }
        public RandomAddress EmployerAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkEmail { get; set; }
        public string Position { get; set; }
        public float Salary { get; set; }
        
        public EmployerInfo()
        {
            CompanyName = new CompanyName().Employer;
            EmployerAddress = new RandomAddress();
            WorkPhoneNumber = new PhoneNumber();
            PhoneNumber = WorkPhoneNumber.NumberFormatted;
            WorkEmail = new EmailAddress(CompanyName).Email;
        }
        public EmployerInfo(bool status)
        {
            if(status == false)
            {
                CompanyName = string.Empty;
                EmployerAddress = null;
                WorkPhoneNumber = null;
                WorkEmail = string.Empty;
                Position = string.Empty;
            }
            else
            {
                CompanyName = new CompanyName().Employer;
                EmployerAddress = new RandomAddress();
                WorkPhoneNumber = new PhoneNumber();
                PhoneNumber = WorkPhoneNumber.NumberFormatted;
                WorkEmail = new EmailAddress(CompanyName).Email;
               
            }
        }

       
    }
}
