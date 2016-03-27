using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolkit.ViewModel
{
    class CustomEventArgs
    {
    }

    public class DataValidationEventArgs : EventArgs
    {
        public bool IsValid { get; internal set; }

        public DataValidationEventArgs(bool isValid)
        {
            IsValid = isValid;
        }
    }

    public class PropertyChangeEventArgs : EventArgs
    {
        public string PropertyName { get; internal set; }

        public PropertyChangeEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
