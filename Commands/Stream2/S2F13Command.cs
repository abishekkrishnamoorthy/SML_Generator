
using System;
using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S2F13Command : ISecsCommand
    {
        public List<int> EcidList { get; set; }

        public string Name => "S2F13";

        // Default constructor
        public S2F13Command()
        {
            EcidList = new List<int>();
        }

        // Parameterized constructor
        public S2F13Command(List<int> ecidList)
        {
            EcidList = ecidList ?? new List<int>();
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F13 W");

            // Number of requested ECIDs
            sml.AppendLine($"<L [{EcidList.Count}]");

            // Add each ECID
            foreach (int ecid in EcidList)
            {
                sml.AppendLine(
                    $"    <U4  {ecid}>");
            }

            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
