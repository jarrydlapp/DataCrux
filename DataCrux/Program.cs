using DataCrux.Name;
using DataCrux.Extensions;
using System;
using System.Diagnostics;

namespace DataCrux
{
    class Program
    {     
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            Person[] p = new Person[1];    


            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new Person();

                Console.WriteLine($"First Name: {p[i].Name.First}");
                Console.WriteLine($"Middle Name: {p[i].Name.Middle}");
                Console.WriteLine($"Last Name: {p[i].Name.Last}");
                Console.WriteLine($"Suffix: {p[i].Name.Suffix}");
                Console.WriteLine($"Marital Status: {p[i].MaritalStatus}");
                Console.WriteLine($"Date of Birth: {p[i].DateOfBirth.ToString("d")}");
                Console.WriteLine($"Gender: {p[i].Gender}");
                Console.WriteLine($"Address: {p[i].Address.GetFullAddress()}");
                Console.WriteLine($"EmailAddress: {p[i].Email}");
                Console.WriteLine($"Social Security Number: {p[i].SocialSecurityNumber}");
                Console.WriteLine($"HomePhone(Formatted): {p[i].HomePhoneNumber.Formatted()}");
                Console.WriteLine($"MobilePhone(Unformatted): {p[i].MobilePhoneNumber.UnFormatted()}");              
                Console.WriteLine($"Dependents {p[i].Dependents}");
                Console.WriteLine($"Age: {p[i].GetAge()}");                
                Console.WriteLine($"-----------------------------------------");
                Console.WriteLine($"-----------------------------------------");
                Console.WriteLine($"Employment Status: {p[i].EmploymentStatus}");
                if(p[i].EmploymentStatus)
                {
                    Console.WriteLine($"Employer Company Name: {p[i].Employer.CompanyName}");
                    Console.WriteLine($"Employer Address: {p[i].Employer.EmployerAddress.GetFullAddress()}");
                    Console.WriteLine($"Employer EmailAddress: {p[i].Employer.WorkEmail}");
                    Console.WriteLine($"Employer Phone Number: {p[i].Employer.PhoneNumber}");
                }

                timer.Stop();



                Console.WriteLine($"Elapased Time: {timer.ElapsedMilliseconds} ");
            




            }

        }
        
       
    }
}
