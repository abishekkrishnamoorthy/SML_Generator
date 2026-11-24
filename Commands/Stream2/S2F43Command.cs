using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S2F43Command : ISecsCommand
    {
        public int StreamID { get; set; }
        public List<int> FunctionIDList { get; set; }

        public string Name => "S2F43";

        public string Description =>
            "Define Spool Streams and Functions - Selects the stream and function pairs to spool.";

        public S2F43Command()
        {
            StreamID = 0;
            FunctionIDList = new List<int>();
        }

        public S2F43Command(int streamID, List<int> functionIDList)
        {
            StreamID = streamID;
            FunctionIDList = functionIDList;
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F43 W");
            sml.AppendLine("<L [1]");
            sml.AppendLine("    <L [2]");

            sml.AppendLine($"        <U1 [1] {StreamID}>");

            sml.AppendLine($"        <L [{FunctionIDList.Count}]");

            foreach (int functionID in FunctionIDList)
            {
                sml.AppendLine(
                    $"            <U1 [1] {functionID}>");
            }

            sml.AppendLine("        >");
            sml.AppendLine("    >");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
