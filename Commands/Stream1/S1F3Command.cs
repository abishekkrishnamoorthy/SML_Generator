
using System;
using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S1F3Command : ISecsCommand
    {
        public List<int> SVIDList { get; set; }

        public string Name => "S1F3";

        public S1F3Command()
        {
            SVIDList = new List<int>();
        }

        public S1F3Command(List<int> svidList)
        {
            SVIDList = svidList;
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S1F3 W");
            sml.AppendLine($"<L [{SVIDList.Count}]");

            foreach (int svid in SVIDList)
            {
                sml.AppendLine($"    <U2  {svid}>");
            }

            sml.AppendLine(">");

            return sml.ToString();
        }
    }
}
