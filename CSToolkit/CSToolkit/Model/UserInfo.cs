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
        public static string CurrentDate { get; set; }

        public static void SetUserInfo(string customerName, string srNumber, string cecId)
        {
            CustomerName = customerName;
            SrNumber = srNumber;
            CecId = cecId;
        }

        public static string GetInfoForReport()
        {
            CurrentDate = GetCurrentDate();
            return string.Format("\nCustomer name: {0}\nSerial number: {1}\nCecId: {2}\nCurrent date: {3}", CustomerName, SrNumber, CecId, CurrentDate);
        }

        private static string GetCurrentDate()
        {
            var date = DateTime.Now;
            return String.Format(@"{0}-{1}{2}", date.ToString("ddMMMMyyyy"), date.ToString("HHmm"), "PST");
        }
    }
}
