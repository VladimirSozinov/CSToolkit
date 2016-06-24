using System;
using System.Collections.Generic;
using System.Linq;

namespace CSToolkit.Model
{
    public class OperationReportsCollection
    {
        private static OperationReportsCollection _instance;
        private List<OperationReport> _reports;
        private Object _syncObject;

        private OperationReportsCollection()
        {   
            _syncObject = new Object();
            _reports = new List<OperationReport>();
        }

        public static OperationReportsCollection Instance()
        {
            if (_instance == null)
                _instance = new OperationReportsCollection();

            return _instance;
        }

        public List<OperationReport> Reports
        {
            get
            {
                return _reports;
            }
        }

        public void AddReport(OperationReport report)
        {     
            lock (_syncObject)
            {
                _reports.Add(report);
            }

            if (_reports.Count == OperationNames.OperationFileNames.Count)
                Check();
        }

        private void Check()
        {
            var fileNames = OperationNames.OperationFileNames;
            List<OperationReport> reports = new List<OperationReport>();

            foreach (var name in fileNames)
            {
                var newReport = _reports.First(i => i.Operation == name);
                reports.Add(newReport);
            }

            _reports = reports;
        }
    }
}
