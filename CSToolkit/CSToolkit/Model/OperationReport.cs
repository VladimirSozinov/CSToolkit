﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolkit.Model
{
    public class OperationReport
    {
        private string _operation;
        private List<Report> _reports;
        
        public OperationReport(string operation, List<Report> reports)
        {
            _operation = operation;
            _reports = reports;
        }

        public string Operation 
        { 
            get
            {
                return _operation;
            }
        }

        public List<Report> Report
        {
            get
            {
                return _reports;
            }
        }
    }
}
