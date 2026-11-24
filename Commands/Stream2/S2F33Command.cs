
using System.Collections.Generic;
using System.Text;
namespace SML_Generator
{
    public class S2F33Command : ISecsCommand
    {
        public int DataID { get; set; }
        public int ReportID { get; set; }
        public List<int> DvidList { get; set; }
        public string Name => "S2F33";
        public string Description =>
            "Define Report - Defines reports and the variables included in each report.";
        public S2F33Command()
        {
            DataID = 0;
            ReportID = 0;
            DvidList = new List<int>();
        }
        public S2F33Command(int dataID, int reportID, List<int> dvidList)
        {
            DataID = dataID;
            ReportID = reportID;
            DvidList = dvidList;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F33 W");
            sml.AppendLine("<L [2]");

            sml.AppendLine($"{tab}{tab}<U4 [1] {DataID}>");

            sml.AppendLine($"{tab}{tab}<L [1]");
            sml.AppendLine($"{tab}{tab}{tab}{tab}<L [2]");

            sml.AppendLine($"{tab}{tab}{tab}{tab}{tab}{tab}<U4 [1] {ReportID}>");

            sml.AppendLine($"{tab}{tab}{tab}{tab}{tab}{tab}<L [{DvidList.Count}]");

            foreach (int dvid in DvidList)
            {
                sml.AppendLine(
                    $"{tab}{tab}{tab}{tab}{tab}{tab}{tab}{tab}<U4  {dvid}>");
            }

            sml.AppendLine($"{tab}{tab}{tab}{tab}{tab}{tab}>");
            sml.AppendLine($"{tab}{tab}{tab}{tab}>");
            sml.AppendLine($"{tab}{tab}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
