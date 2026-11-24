using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S2F29Command : ISecsCommand
    {
        public List<int> EcidList { get; set; }

        public S2F29Command()
        {
            EcidList = new List<int>();
        }

        public S2F29Command(List<int> ecidList)
        {
            EcidList = ecidList;
        }

        public string Name => "S2F29";

        public string Description =>
            "Equipment Constant Namelist Request - Requests the available equipment constant identifiers and names.";

        public string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F29 W");
            sml.AppendLine($"<L [{EcidList.Count}]");

            foreach (int ecid in EcidList)
            {
                sml.AppendLine($"    <U4 {ecid}>");
            }

            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
