using System.Text.RegularExpressions;

namespace Infrastructure.Utils
{
    public static class StringUtils
    {
        private static readonly Regex isNumericRegex = new Regex(@"^\d+$");

        public static bool IsNumeric(string value) 
        {
            return isNumericRegex.IsMatch(value);
        }

        public static bool IsValidCitizenNumber(string citizenNumber)
        {
            return CitizenNumberValidator.ValidateCitizenNumber(citizenNumber);
        }
    }
}
