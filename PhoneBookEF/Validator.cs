using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBookEF
{
    public static class Validator
    {
        public static bool IsValidEmail(string email) 
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }

        public static bool IsValidPhone(string phone) 
        {
            // Accepts 10-digit numbers like 9876543210
            return Regex.IsMatch(phone,
                 @"^\d{10}$");
        }
    }
}
