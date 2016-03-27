using CSToolkit.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSToolkit.View
{
    class StartViewDataValidator : IDataErrorInfo
    {
        private const string PhoneNumberRegex = @"^[\d]+$";

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;

                if (columnName == "UserName")
                {
                    if (string.IsNullOrEmpty(UserName))
                        result = "Please enter a Name";
                }
                if (columnName == "PhoneNumber")
                {
                    if (string.IsNullOrEmpty(PhoneNumber) || !PhoneIsValid())
                        result = "Please enter a Position";
                }

                return result;
            }
        }

        private bool PhoneIsValid()
        {
            return !string.IsNullOrEmpty(PhoneNumber) && new Regex(PhoneNumberRegex).Match(PhoneNumber).Success;
        }
    }
}
