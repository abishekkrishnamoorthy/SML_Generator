using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S1F21Command : ISecsCommand
    {
        public List<int> VIDList { get; set; }

        public string Name => "S1F21";

        public S1F21Command()
        {
            VIDList = new List<int>();
        }

        public S1F21Command(List<int> vidList)
        {
            VIDList = vidList;
        }

       

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S1F21 W");
            sml.AppendLine($"<L [{VIDList.Count}]");

            foreach (int vid in VIDList)
            {
                sml.AppendLine($"    <U4 [1] {vid}>");
            }

            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}