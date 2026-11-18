
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace SML_Generator
{
    public class S2F33Command : ISecsCommand
    {
        public int DataID { get; set; }
        public int ReportID { get; set; }
        public List<int> DvidList { get; set; }
        public string Name => "S2F33";
        public S2F33Command()
        {
            DataID = 0;
            ReportID = 0;
            DvidList = new List<int>();
        }
        public S2F33Command(int dataID,int reportID, List<int> dvidList)
        {
            DataID = dataID;
            ReportID = reportID;
            DvidList = dvidList;
        }
        public virtual List<string> Validate()
        {
            List<string> errors = new List<string>();

            return errors;
        }
        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();


            sml.AppendLine("S2F33 W");
            sml.AppendLine("<L [2]");

            // DATAID
            sml.AppendLine($"    <U4 [1] {DataID}>");

            // Report definition list
            sml.AppendLine("    <L [1]");
            sml.AppendLine("        <L [2]");

            // Report ID
            sml.AppendLine($"            <U4 [1] {ReportID}>");

            // Variable ID list
            sml.AppendLine($"            <L [{DvidList.Count}]");

            foreach (int dvid in DvidList)
            {
                sml.AppendLine(
                    $"                <U4 [1] {dvid}>");
            }

            sml.AppendLine("            >");
            sml.AppendLine("        >");
            sml.AppendLine("    >");
            sml.AppendLine(">.");


            return sml.ToString();
        }
    }
}
