# DataCrux
Data Randomizer
DataCrux

Person Class
Highest Level Class that contains access to the below randomized data attributes. 
*can be instantiated independently.
  Person person = new Person();

Attributes 
  •	Name <PersonName> *
  •	Date of Birth <DateTime> 
    o	Date will be generated to be within 105 years of current date.
  •	Age <int>
  •	Gender <string>
    o	Returns either Male or Female
  •	Address <RandomAddress> *
  •	Place of Birth <string>
  •	Email <String>
  •	Social Security Number <string>
    o	SSN generated uses the government logic and standards. No SSN will be generated with location parts of 000,666 or 900-999 if their       date of birth is after 6/25/2011. If Born before date, local parts cannot be 667-679, 681-699, 729-730, 750-772
  •	Home Phone Number <PhoneNumber> *
  •	Mobile Phone Number <PhoneNumber> *
  •	Marital Status <string>
    o	Returns either Single, Married, Widowed, Divoriced.
  •	Employment Status <bool>
  •	Dependents <int> 
    o	Generates random int no greater than 5
  •	Employer <EmployerInfo> *

EmailAddress Class
Generates a random valid email address that is checked among an internal REGEX. Email address contains valid top-level domains (.com, .net, .org, .edu).

Example: kjskjfkjf@kjakjskjf.net
  EmailAddress emailAddress = new EmailAddress();

EmployerInfo Class
Class that generates random employee data for an individual Person, should they be employed. Can be instantiated independently to generate Employer Info.
  EmployerInfo employerInfo = new EmployerInfo();

Attributes
  •	CompanyName <CompanyName>
  •	EmployerAddress <RandomAddress>
  •	WorkPhoneNumber <PhoneNumber>
  •	WorkEmail <EmailAddress>
    o	Generates an email address with the company name as the second level domain.
  •	Position <string>
  •	Salary <float>

CompanyName Class
Class that generates a random valid company name from a public list of about 1000 companies. This class can be instantiated independently. 
  CompanyName companyName = new CompanyName();

PersonName Class
Generates a random but valid First, Middle, Last and possible suffix based on the randomly generated gender.  Names are picked from lists of 1000s of names. 
  PersonName name = new PersonName();

Attributes
  •	First <string>
  •	Middle <string>
  •	Last <string>
  •	Suffix <string>
  •	Sex <enum>
    o	Returns 1 for male 0 for female. It is recommended that you use the person class to return appropriate string of gender.

PhoneNumber Class
Generates a random phone number unformatted ‘##########’. Can be instantiated independently. 
  PhoneNumber phoneNumber = new PhoneNumber();
Class contains method ‘Format’ to provide a formatted phone number ###-###-#### and an attribute that returns the formatted phone number 
  phoneNumber.Format();
  phoneNumber.Formatted; 

RandomAddress Class
Class that generates a valid formatted but random US based address.  This class can be instantiated independently. The city, state, zip combinations are valid based on United States Postal Service database. Streets are combined with valid Prefixes, Streets and Suffixes, however in combination, may not be true valid addresses.
  RandomAddress address = new RandomAddress();

Attributes
  •	Number <string>
  •	Street <Street>
  •	City <string>
  •	State <string>
    o	Uses valid state abbreviations 
  •	Zipcode <string>
  
  The Random Address also class comes with many methods for accessing and formatting the address as needed, all return as a string.
  
  GetCityStateZip()  
    Returns single line string formatted like City, State Zip code
  GetFullAddress()
    Returns multi-lined string of an address 
    Street Number Street Name, Street Suffix
    City, State Zip code
  GetStreet();
  GetCity()
  GetState()
    Returns state abbreviations
  GetZipcode()

Street Class
Class used by the RandomAddress class which generates a random street combination for a full address. Can be instantiated independently, however not recommended. 
Street street = new Street();

Attributes
  •	Prefix <string>
  •	Name <string>
  •	Suffix <string>
    
MORE TO COME…

