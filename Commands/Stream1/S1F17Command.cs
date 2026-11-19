using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S1F17Command : ISecsCommand
    {
        public string Name => "S1F17";

        public S1F17Command()
        {
        }

       

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S1F17 W");
            sml.AppendLine("<L [0]");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}