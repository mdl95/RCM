using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace RCM.UI.Support
{
    public class TestData
    {
        private static string _executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string Workspace = _executableLocation;
        public static string UniqueCode;
        public static string BrowserName = "Chrome";
        public static string BrowserVersion = "98.0.4758.102";


        // CLAIMS PAGE - STATUS NEEDED TAB

        public static List<string> StatusNeededColumns = new List<string>()
        {
            "Account ID",
            "Patient DOB",
            "Claim Submitted",
            "Claim ID",
            "Claim Amount",
            "Balance Due",
            "Last Modified",
            "Insurer Name",
            "Insurance Plan",
            "Insurer ID",
            "Insurer Phone Number",
            "Billing Entity Name",
            "Patient ID",
            "Patient First Name",
            "Patient Last Name",
            "Patient State",
            "Patient Zip Code",
            "Subs. First Name",
            "Subs. Last Name",
            "Subs. DOB",
            "Subscriber ID",
            "Group ID",
            "Auth ID",
            "Auth Date",
            "Admit Date",
            "Discharge Date"
        };
    }
}
