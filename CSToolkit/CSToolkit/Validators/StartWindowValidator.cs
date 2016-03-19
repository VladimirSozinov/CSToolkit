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
    public class StartWindowValidator : ValidationRule
    {
        private string _pattern;
        private Regex _regex;

        public StartWindowValidator()
        {
                
        }

        public string Pattern
        {
            get { return _pattern; }
            set
            {
                _pattern = value;
                _regex = new Regex(_pattern, RegexOptions.IgnoreCase);
            }
        }

        public override ValidationResult Validate(object value, CultureInfo ultureInfo)
        {
            if (value == null || !_regex.Match(value.ToString()).Success)
            {
                return new ValidationResult(false, "The entered string is invalid");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
