
using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S1F11Command : ISecsCommand
    {
        public List<int> SVIDList { get; set; }
        public string Name => "S1F11";
        public string Description =>
            "Status Variable Namelist Request - Requests names and metadata for status variables.";
        public S1F11Command()
        {
            SVIDList = new List<int>();
        }
        public S1F11Command(List<int> svidList)
        {
            SVIDList = svidList;
        }
        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S1F11 W");
            sml.AppendLine($"<L [{SVIDList.Count}]");
            foreach (int svid in SVIDList)
            {
                sml.AppendLine($"{tab}{tab}<U2  {svid}>");
            }
            sml.AppendLine(">");
            return sml.ToString();
        }
    }
}
