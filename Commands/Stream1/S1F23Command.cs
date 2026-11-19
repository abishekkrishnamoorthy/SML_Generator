using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S1F23Command : ISecsCommand
    {
        public List<uint> ECIDList { get; set; }

        public string Name => "S1F23";

        public S1F23Command()
        {
            ECIDList = new List<uint>();
        }

        public S1F23Command(List<uint> ecidList)
        {
            ECIDList = ecidList;
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S1F23 W");
            sml.AppendLine($"<L [{ECIDList.Count}]");

            foreach (uint ecid in ECIDList)
            {
                sml.AppendLine($"    <U4  {ecid}>");
            }

            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}