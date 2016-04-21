using System;

namespace CSToolkit.ViewModel
{
    public class CustomEvent
    {
        public delegate void CustomHandler(object sender, DataValidationEventArgs isValid);   
        public delegate void MyWorkerHandler(object sender, MyWorkerEventArgs e);
    }

    public class MyWorkerEventArgs : EventArgs
    {
        public int OperationOrdinalNumber { get; set; }

        public MyWorkerEventArgs(int count)
        {
            OperationOrdinalNumber = count;
        }
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
