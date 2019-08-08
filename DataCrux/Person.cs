using DataCrux.Name;
using DataCrux.Address;
using DataCrux.Email;
using System;
using DataCrux.Randomizer;
using System.Linq;
using DataCrux.PhoneNumberGenerator;
using DataCrux.Employer;

namespace DataCrux
{
    public class Person
    {  
        public enum MaritalStat
        {
            Single =1,
            Married = 2,
            Widowed = 3,
            Divorice = 4
        }

        public PersonName Name {get;set;}
        /// <summary>
        /// Random Date of Birth as a DateTime. If you want to output
        /// format of MM/DD/YYYY you need to add .ToString("d")
        /// at the end of your member.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        public string Age { get; set; }
        public string SSN { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Email { get; set; }
        public PhoneNumber HomePhoneNumber { get; set; }
        public PhoneNumber MobilePhoneNumber { get; set; }
        public string Gender { get; set; }
        public RandomAddress Address { get; set;}
        public string MaritalStatus { get; set; }
        public int? Dependents { get; set; }
        public RandomAddress HomeAddress { get; set; }
        public bool EmploymentStatus { get; set; }
        public EmployerInfo Employer { get; set; }    
        public string SocialSecurityNumber {get;set;}
               
        public Person()
        {
            Name = new PersonName();
            DateOfBirth = GenerateRandomDateOfBirth();
            Age = CalculateAge();
            Gender = ConvertGenderToString(Name.Sex);
            Address = new RandomAddress();
            PlaceOfBirth = GenerateRandomPlaceOfBirth();
            Email = new EmailAddress().Email;
            SocialSecurityNumber = GenerateRandomSSN();
            HomePhoneNumber = new PhoneNumber();
            MobilePhoneNumber = new PhoneNumber();
            MaritalStatus = GetRandomMaritalStatus(RandomlyPickMaritalStatus(), Name.Sex);
            EmploymentStatus =  IsPersonEmployed();
            Dependents = GenerateDependents();
            Employer = new EmployerInfo(EmploymentStatus);
          
        }
 

        /// <summary>
        /// Generates a random date of birth
        /// </summary>
        /// <returns></returns>
        private DateTime GenerateRandomDateOfBirth()
        {            
            //create starting year for date to be within 105 years of current date
            var currentYear = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();
            int startingYear = 0;
            Int32.TryParse(currentYear, out startingYear);
            startingYear = startingYear - 105;

            Random _random = new Random();          

            DateTime start = new DateTime(startingYear, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(_random.Next(range)).Date;
        }
        /// <summary>
        /// Generates a random address to set City & State as Person's 
        /// Place of Birth.
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomPlaceOfBirth()
        {
            var a = new RandomAddress();
            return $"{a.City}, {a.State}";          
        }
        /// <summary>
        /// Generates a random Social Security Number 
        /// in the format of ###-##-####
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomSSN()
        {           
            var date = new DateTime(2011, 06, 25);
            int loc;
            var group = DataRandomizer.GenearteRandomNumber(2);
            var sequence = DataRandomizer.GenearteRandomNumber(4);

            // Location part cannot be 000,666 or 900-999
            // If person is born after 6/25/2011
            if (DateOfBirth >= date)
            {             
                do
                {
                    loc = Convert.ToInt32(DataRandomizer.GenearteRandomNumber(3));
                }
                while (loc == 000 || loc == 666 || !Enumerable.Range(900, 999).Contains(loc));                          

                return $"{loc.ToString()}-{group}-{sequence}";
            }            
            //If Born before 06/25/2011 location part cannot be 667–679, 681–699 ,729–730, 750–772
            else
            {
                do
                {
                    loc = Convert.ToInt32(DataRandomizer.GenearteRandomNumber(3));
                }
                while (!Enumerable.Range(667, 679).Contains(loc) || !Enumerable.Range(681, 699).Contains(loc) || !Enumerable.Range(729, 730).Contains(loc) || !Enumerable.Range(750, 772).Contains(loc));

                return $"{loc.ToString()}-{group}-{sequence}";
            }        
   
        }
        /// <summary>
        /// Converts Gender Enum to a String 
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        private static string ConvertGenderToString(PersonName.Gender sex)
        {
            return sex.ToString().Equals("Female") 
                ? "Female" 
                : "Male";
        }
        /// <summary>
        /// Random picks number 1 - 4 for Marital Status 
        /// Enum assignment.
        /// </summary>
        /// <returns></returns>
        private static int RandomlyPickMaritalStatus()
        {
            Random RandGen = new Random();
            var status = RandGen.Next(1, 4);
            return status;
        }
        /// <summary>
        /// Generates a Random Marital Status
        /// </summary>
        /// <param name="status"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        private static string GetRandomMaritalStatus(int status, PersonName.Gender gender)
        { var maritalStatus = status == 1
                               ? "Single"
                               : status == 2
                               ? "Married"
                               : status == 3
                               ? "Widowed"
                               : status == 4
                               ? "Divoriced"
                               : null;               

            return gender.ToString().Equals("Male") && status == 3 
                ? "Single" 
                : maritalStatus;
        }
        /// <summary>
        /// Generates Random Bool for EmploymedwdntStatus
        /// </summary>
        /// <returns></returns>
        private bool IsPersonEmployed()
        {
            Random ranGen = new Random();
            return ranGen.Next(0, 2) == 0;                  
        }

        private int? GenerateDependents()
        {
            int num = 0;
            int.TryParse(DataRandomizer.GenearteRandomNumber(1), out num);

            if (num <= 5)
            {
                return num;
            }
            return null;
        }
        /// <summary>
        /// Calculates the Age of a person. Does not include leap years.
        /// </summary>
        /// <returns></returns>
        public string GetAge()
        {
            return CalculateAge();
        }

        private string  CalculateAge()
        {
            DateTime currentDate = DateTime.Now;

            int currentYear = currentDate.Year;
            int dobYear = this.DateOfBirth.Year;
            int age = 0;

            //Check to see if in current month
            if (currentDate.Month == this.DateOfBirth.Month)
            {
                //check if date in current month is after or equal to the
                //day of the dob.
                if (currentDate.Day >= this.DateOfBirth.Day)
                    age = currentYear - dobYear;
            }
            else
            {
                age = currentYear - dobYear - 1;
            }

            return age.ToString();
        }
        
    }
   

    
   
  
       
}
