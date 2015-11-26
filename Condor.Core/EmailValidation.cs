using System.Text.RegularExpressions;

namespace Condor.Core
{
    public class Validation
    {
        public static string emailAddressRegex = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        public static string phoneNumberRegex = @"^(\d{1})?-?\d{3}-?\d{3}-?\d{4}$";

        /// <summary>
        /// Validates the email address format.
        /// </summary>
        /// <param name="emailAddress">Email address to validate.</param>
        /// <returns>true if email address is valid</returns>
        public static bool ValidateEmailAddress(string emailAddress)
        {
            var reg = new Regex(emailAddressRegex, 
                        RegexOptions.ECMAScript); // using javascript regex syntax here to guarantee similar behavior with the browser
            return reg.IsMatch(emailAddress); 
        }

        public static bool ValidatePhone(string phoneNumber)
        {
            var reg = new Regex(phoneNumberRegex,
                       RegexOptions.ECMAScript); // using javascript regex syntax here to guarantee similar behavior with the browser
            return reg.IsMatch(phoneNumber); 
        }


    }
}