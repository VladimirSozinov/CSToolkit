using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CSToolkit.Validators
{
    public class SecondWindowRules : ValidationRule
    {
        public string InputText { get; set; }
        
        public bool IsProxyValid(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public bool IsPingHostValid(string input)
        {
            return IsMatch(input);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            InputText = str;

            if (str == null)
            {
                return new ValidationResult(false, "Please enter some text");
            }
            if (!IsMatch(InputText))
            {
                return new ValidationResult(false, "Please enter correct adress");
            }

            return new ValidationResult(true, null);
        }

        private bool IsMatch(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            Match isMatch = Regex.Match(s, @"^[a-zA-Z0-9\-\.]+\.[a-zA-Z]*", RegexOptions.IgnoreCase);

            return isMatch.Success;
        }
    }
}
