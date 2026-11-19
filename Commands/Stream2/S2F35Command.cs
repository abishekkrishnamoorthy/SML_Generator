
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
namespace SML_Generator
{
    public class S2F35Command : ISecsCommand

    {
        public int DataID { get; set; }
        public int EventID { get; set; }

        public List<int> ReportIDList { get; set; }



    public string Name => "S2F35";


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
            StringBuilder sml = new StringBuilder();



            sml.AppendLine("S2F35 W");
            sml.AppendLine("<L [2]");
            sml.AppendLine($"    <U4  {DataID}>"); // DATAID
            sml.AppendLine("    <L [1]");
            sml.AppendLine("        <L [2]");
            sml.AppendLine($"            <U4  {EventID}>");
            sml.AppendLine($"            <L [{ReportIDList.Count}]");

            foreach (int reportID in ReportIDList)
            {
                sml.AppendLine($"                <U4  {reportID}>");
            }

            sml.AppendLine("            >");
            sml.AppendLine("        >");
            sml.AppendLine("    >");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}


