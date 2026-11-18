
using System;
using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S2F17Command : ISecsCommand
    {
        public string Name => "S2F17";

        public S2F17Command()
        {
        }

        public virtual List<string> Validate()
        {
            List<string> errors = new List<string>();

            return errors;
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F17 W.");

            return sml.ToString();
        }
    }
}
