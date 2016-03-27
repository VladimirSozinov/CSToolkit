using System.Text.RegularExpressions;

namespace CSToolkit.Validators
{
    public class SecondWindowRules
    {                                                
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
