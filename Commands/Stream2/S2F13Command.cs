
using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S2F13Command : ISecsCommand
    {
        public List<int> EcidList { get; set; }

        public string Name => "S2F13";
        public string Description =>
            "Equipment Constant Request - Requests values for selected equipment constants.";
        public S2F13Command()
        {
            EcidList = new List<int>();
        }

        public S2F13Command(List<int> ecidList)
        {
            EcidList = ecidList ?? new List<int>();
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F13 W");

            sml.AppendLine($"<L [{EcidList.Count}]");

            foreach (int ecid in EcidList)
            {
                sml.AppendLine(
                    $"{tab}<U4 {ecid}>");
            }

            sml.AppendLine($"{tab}>.");

            return sml.ToString();
        }
    }
}
