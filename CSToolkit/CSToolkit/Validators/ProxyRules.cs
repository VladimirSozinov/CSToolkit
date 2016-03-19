using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolkit.Validators
{
    public class ProxyRules
    {
        public bool IsProxyValid(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}
