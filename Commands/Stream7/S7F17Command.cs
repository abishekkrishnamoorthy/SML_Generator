
using System.Collections.Generic;
using System.Text;
namespace SML_Generator
{
    public class S7F17Command : ISecsCommand
    {
        public List<string> PPIDList { get; set; }

        public string Name => "S7F17";

        public string Description =>
            "Delete Process Program Send - Requests deletion of the selected process programs.";

        public S7F17Command()
        {
            PPIDList = new List<string>();
        }

        public S7F17Command(List<string> ppidList)
        {
            PPIDList = ppidList;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S7F17 W");

            sml.AppendLine($"<L [{PPIDList.Count}]");

            foreach (string ppid in PPIDList)
            {
                sml.AppendLine(
                    $"{tab}{tab}<A [{Encoding.ASCII.GetByteCount(ppid)}] \"{ppid}\">");
            }

            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
