﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolkit.Model
{
    public class Operation : INotifyPropertyChanged
    {
        public string CommandName { get; set; }
        public List<SubCommand> SetCommands { get; set; }
        public string TxtName { get; set; }

        private States _currentState;

        public enum States
        {
            Waiting,
            InProgress,
            Finished,
            Failed
        }
        
        public States CurrentState 
        { 
            get
            {
                return _currentState;
            }
            set
            {
                _currentState = value;
                OnPropertyChanged("CurrentState");
            }
        }

        public ObservableCollection<Operation> GetOperations(string proxy1, string proxy2, string pingHost)
        {
            var collection = new CommandsCollcetion(proxy1, proxy2, pingHost).GetCommands;
            var commands = new ObservableCollection<Operation>();
            var operations = new OperationNames();

            List<string> list = operations.Operations;
            List<string> listTxtNames = operations.OperationFileNames;

            for (int i = 0; i < collection.Count; i++)
            {
                var command = new Operation { CommandName = list[i], SetCommands = collection[i], CurrentState = Operation.States.Waiting, TxtName = listTxtNames[i] };
                commands.Add(command);
            }

            return commands;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
