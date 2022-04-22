using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.UWP.Utilities
{
    public class ResultTable
    {
        public string TestName { get; set; }
        public string TestOutcome { get; set; }
        public string Duration { get; set; }
        public string ErrorMessage { get; set; }
        public string Screenshot { get; set; }

        public ResultTable(string testName, string testOutcome, string duration, string errorMessage, string screenshot)
        {
            TestName = testName;
            TestOutcome = testOutcome;
            Duration = duration;
            ErrorMessage = errorMessage;
            Screenshot = screenshot;
        }
    }
}
