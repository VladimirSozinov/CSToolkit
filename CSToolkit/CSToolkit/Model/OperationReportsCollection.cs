using System;
using System.Collections.Generic;

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
        }
    }
}
