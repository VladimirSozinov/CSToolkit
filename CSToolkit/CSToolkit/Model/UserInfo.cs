using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSToolkit.Model
{
    class UserInfo
    {
        public static string CustomerName { get; set; }
        public static string SrNumber { get; set; }
        public static string CecId { get; set; }

        public static void SetUserInfo(string customerName, string srNumber, string cecId)
        {
            CustomerName = customerName;
            SrNumber = srNumber;
            CecId = cecId;
        }
    }
}
