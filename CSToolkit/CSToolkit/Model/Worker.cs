using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSToolkit.Model
{
    class Worker
    {
        private Operation _command;
        private BackgroundWorker worker; 
        public event Action Refresh;

        public Worker(Operation command)
        {
            _command = command;
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(workerDoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(workerProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerRunWorkerCompleted);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            while (worker.IsBusy)
                Thread.Sleep(100);

            worker.RunWorkerAsync(_command);
        }

        private void workerDoWork(object sender, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
                return;

            var command = (Operation)e.Argument;
            command.CurrentState = Operation.States.InProgress;
            worker.ReportProgress(1, command);

            try
            {
                //Process p = new Process();
                //p.StartInfo.UseShellExecute = false;
                //p.StartInfo.RedirectStandardOutput = true;
                //p.StartInfo.FileName = command;
                //p.Start();
                //string output = p.StandardOutput.ReadToEnd();
                //p.WaitForExit();
                //
                //System.IO.StreamWriter file = new System.IO.StreamWriter(string.Format("c://tmp/{0}.txt", command));
                //file.WriteLine(output);
                //
                //file.Close();
                Thread.Sleep(1000);
                command.CurrentState = Operation.States.Finished;
            }
            catch
            {
                command.CurrentState = Operation.States.Failed;
            }

            worker.CancelAsync();
            worker.Dispose();
        }

        private void workerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var command = (Operation)e.UserState;
            //command.CurrentState;
        }

        private void workerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        } 
    }
}
