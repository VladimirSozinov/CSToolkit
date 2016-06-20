using CSToolkit.Tools;
using CSToolkit.ViewModel;
using System.Linq;
using System.Threading;

namespace CSToolkit.Model
{    
    public class Executer
    {
        private int _countOfFinishedCommands;
        private int _amountOfCommands;
        private int _highOrdinalNumber;
        private Report[] _reports;
        private Operation _operation;

        public event CSToolkit.ViewModel.CustomEvent.MyWorkerHandler ProcessingFinished;

        public Executer(Operation operation, int highOrdinalNumber)
        {
            _highOrdinalNumber = highOrdinalNumber;
            _operation = operation;
            _amountOfCommands = _operation.SetCommands.Count;
            _reports = new Report[_amountOfCommands];
            Execute();
        }

        private void Execute()
        {   
            for (int i = 0; i < _amountOfCommands; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), new SentData(_operation.SetCommands[i], i));
            }
        }

        private void DoWork(object sender)
        {
            var data = sender as SentData;
            var subCommand = data.ExecutedCommand;
            var ordinalNumber = data.ReportOrdinalNumber;
            var output = string.Empty;
            var fullCommand = string.Empty;

            if (_operation.SetCommands[0].Key != UserInfo.GetNameOfOperation())
            {
                fullCommand = string.Format("{0} {1}", subCommand.Key, subCommand.Value);
                output = ConsoleCommandHandler.ExecuteWithOutput(subCommand.Key, subCommand.Value);
            }
            else  //Creating report for Basic info
            {
                fullCommand = UserInfo.GetNameOfOperation();
                output = UserInfo.GetInfoForReport(); 
            }

            _reports[ordinalNumber] = new Report(fullCommand, output); 
            _countOfFinishedCommands ++;

            if (_countOfFinishedCommands == _amountOfCommands)
            {      
                var operationReport = new OperationReport(_operation.TxtName, _reports.ToList<Report>());
                OperationReportsCollection.Instance().AddReport(operationReport);                 
                ProcessingFinished(this, new MyWorkerEventArgs(_highOrdinalNumber));
            }
        }
    }

    class SentData
    {
        public SubCommand ExecutedCommand { get; set; }
        public int ReportOrdinalNumber { get; set; }

        public SentData(SubCommand command, int count)
        {
            ExecutedCommand = command;
            ReportOrdinalNumber = count;
        }
    }
}
