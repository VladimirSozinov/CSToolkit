using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace CSToolkit.Model
{
    public class Operation : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;

        private System.Timers.Timer _atimer;
        private string _currentState;
        private Visibility _circleImageVisibility;

        public static Dictionary<States, string> AdaptedStates = new Dictionary<States, string> 
        { 
            {States.Waiting,    "Waiting"},
            {States.InProgress, "In Progress"},
            {States.Finished,   "Finished"},
            {States.Failed,     "Failed"}
            
        };

        public enum States
        {
            Waiting,
            InProgress,
            Finished,
            Failed
        }

        public List<SubCommand> SetCommands { get; set; }

        public string CommandName { get; set; }

        public string TxtName { get; set; }

        public string CurrentState 
        { 
            get { return _currentState; }
            set
            {
                _currentState = value;
                CheckState();
                OnPropertyChanged("CurrentState");
            }
        }
                  
        public Visibility CircleImageVisibility
        {
            get { return _circleImageVisibility; }
            set
            {
                _circleImageVisibility = value;
                OnPropertyChanged("CircleImageVisibility");
            }
        }                                          

        public ObservableCollection<Operation> GetOperations(string proxy1, string proxy2, string pingHost)
        {
            var collection = new CommandsCollcetion(proxy1, proxy2, pingHost).GetCommands;
            var commands = new ObservableCollection<Operation>();

            List<string> list = OperationNames.Operations;
            List<string> listTxtNames = OperationNames.OperationFileNames;

            for (int i = 0; i < collection.Count; i++)
            {
                var command = new Operation { CommandName = list[i],
                                              SetCommands = collection[i],
                                              CurrentState = AdaptedStates[States.Waiting],
                                              TxtName = listTxtNames[i],
                                              CircleImageVisibility = Visibility.Hidden};
                commands.Add(command);
            }        
            return commands;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CheckState()
        {
            if (_currentState == AdaptedStates[States.InProgress])
            {
                CircleImageVisibility = Visibility.Visible;
            }
            if (_currentState == AdaptedStates[States.Finished] || _currentState == AdaptedStates[States.Failed])
            {
                CircleImageVisibility = Visibility.Hidden;
            }
        }
    }
}
