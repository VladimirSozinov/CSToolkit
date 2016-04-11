using System.Text.RegularExpressions;

namespace CSToolkit.Validators
{
    public class GeneralValidationRules
    {
        private const string NameRegex = @"^[\D]+$";
        private const string SerialNumberRegex = @"^[\d]+$";

        public bool IsUserNameValid(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public bool IsSerialNumberValid(string input)
        {
            return !string.IsNullOrEmpty(input) && new Regex(SerialNumberRegex).Match(input).Success;
        }

        public bool IsProxyValid(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public bool IsPingHostValid(string input)
        {
            Match isMatch = Regex.Match(input, @"^[a-zA-Z0-9\-\.]+\.[a-zA-Z]*", RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}
