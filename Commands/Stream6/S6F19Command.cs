using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SML_Generator
{
    public class S6F19Command : ISecsCommand
    {
        public int ReportID { get; set; }

        public string Name => "S6F19";

        public S6F19Command()
        {
            ReportID = 0;
        }

        public S6F19Command(int reportID)
        {
            ReportID = reportID;
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S6F19 W");
            sml.AppendLine("<U4 " + ReportID + ">.");

            return sml.ToString();
        }
    }
}