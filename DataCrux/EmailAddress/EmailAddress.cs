using System;
using DataCrux.Randomizer;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DataCrux.Email
{
    public class EmailAddress
    {
        private Domain _domain { get;}
        public string Email { get; set; }
        private string LocalPart { get;  }
        private string Domain { get;}

        public EmailAddress()
        {
            _domain = new Domain();
            LocalPart = GetLocalPart();
            Domain = GetRandomDomain();
            Email = ConcatEmailAddress();           
        }

        public EmailAddress(string domain)
        {
            _domain = new Domain(domain);
            LocalPart = GetLocalPart();
            Domain = (_domain.SecondLevelDomain + _domain.TopLevelDomain).Replace("..",".");
            Email = ConcatEmailAddress();
        }
        /// <summary>
        /// Combines the email parts into a valid email 
        /// </summary>
        /// <returns></returns>
        private string ConcatEmailAddress()
        {
            return IsValidEmail($"{LocalPart}@{Domain}") ? $"{LocalPart}@{Domain}" : null;
        }
        /// <summary>
        /// Gets the Domain
        /// </summary>
        /// <returns></returns>
        private string GetRandomDomain()
        {           
            return $"{_domain.SecondLevelDomain}{_domain.TopLevelDomain}";
        }
        /// <summary>
        /// Generates and returns the Email Local Part
        /// </summary>
        /// <returns></returns>
        private string GetLocalPart()
        {
            return DataRandomizer.GenearteRandomString(8).ToLower();
        }
        /// <summary>
        /// Verifes if the Email is of valid format
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private static bool IsValidEmail(string email)
        {           
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

    }
}
