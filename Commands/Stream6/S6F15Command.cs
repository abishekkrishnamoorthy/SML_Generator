using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SML_Generator
{
    public class S6F15Command : ISecsCommand
    {
        public int CEID { get; set; }

        public string Name => "S6F15";

        public S6F15Command()
        {
            CEID = 0;
        }

        public S6F15Command(int ceid)
        {
            CEID = ceid;
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S6F15 W");
            sml.AppendLine("<L [1]");

            // Collection Event ID
            sml.AppendLine($"    <U4 {CEID}>");

            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}