using System;

namespace CSToolkit.ViewModel
{
    public class CustomEvent
    {
        public delegate void CustomHandler(object sender, DataValidationEventArgs isValid);
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
