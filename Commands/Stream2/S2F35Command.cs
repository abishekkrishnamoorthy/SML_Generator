
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
namespace SML_Generator
{
    public class S2F35Command : ISecsCommand

    {
        public int DataID { get; set; }
        public int EventID { get; set; }

        public List<int> ReportIDList { get; set; }

        public string Name => "S2F35";
        public string Description =>
            "Link Event Report - Links reports to collection events.";
        public S2F35Command()
        {
            DataID = 0;
            EventID = 0;
            ReportIDList = new List<int>();
        }
        public S2F35Command(int dataID, int eventID, List<int> reportIDList)
        {
            DataID = dataID;
            EventID = eventID;
            ReportIDList = reportIDList;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F35 W");
            sml.AppendLine("<L [2]");
            sml.AppendLine($"{tab}{tab}<U4  {DataID}>"); // DATAID
            sml.AppendLine($"{tab}{tab}<L [1]");
            sml.AppendLine($"{tab}{tab}{tab}{tab}<L [2]");
            sml.AppendLine($"{tab}{tab}{tab}{tab}{tab}{tab}<U4  {EventID}>");
            sml.AppendLine($"{tab}{tab}{tab}{tab}{tab}{tab}<L [{ReportIDList.Count}]");

            foreach (int reportID in ReportIDList)
            {
                sml.AppendLine($"{tab}{tab}{tab}{tab}{tab}{tab}{tab}{tab}<U4  {reportID}>");
            }

            sml.AppendLine($"{tab}{tab}{tab}{tab}{tab}{tab}>");
            sml.AppendLine($"{tab}{tab}{tab}{tab}>");
            sml.AppendLine($"{tab}{tab}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
