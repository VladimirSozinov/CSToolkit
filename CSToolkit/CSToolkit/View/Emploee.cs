using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolkit.View
{
    class Emploee : IDataErrorInfo
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public int Salary { get; set; }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "Name")
                {
                    //if (string.IsNullOrEmpty(Name) || Name.Length < 3)
                    //    result = "Please enter a Name";
                }
                if (columnName == "Position")
                {
                    //if (string.IsNullOrEmpty(Position) ||Position.Length < 3)
                    //    result = "Please enter a Position";
                }
                if (columnName == "Salary")
                {
                    if (Salary <= 1000 || Salary >= 50000)
                        result = "Please enter a valid salary amount";
                }
                return result;
            }
        }
    }
}
