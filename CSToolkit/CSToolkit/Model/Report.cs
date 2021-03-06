﻿namespace CSToolkit.Model
{
    public class Report
    {
        private string _fullCommand;
        private string _report;

        public Report(string fullCommand, string report)
        {
            _fullCommand = fullCommand;
            _report = report;
        }

        public string FullCommand 
        { 
            get
            {
                return _fullCommand;
            }
        }

        public string TextReport
        {
            get
            {
                return _report;
            }
        }
    }
}
