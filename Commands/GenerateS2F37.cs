using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SML_Generator
{
    public class S2F37Command: ISecsCommand
    {
        public bool Enable { get; set;}

        public List<int> CeidList { get; set;}

        public string Name => "S2F37";

        public S2F37Command(bool enable, List<int> ceidList)
        {
            Enable = enable;
            CeidList = ceidList ?? throw new ArgumentNullException(nameof(ceidList));
        }

        public virtual List<string> Validate()
        {
            List<string> errors = new List<string>();

            // Validate CEID list
            if (CeidList == null)
            {
                errors.Add("CeidList cannot be null.");
            }
            else
            {
                foreach (int ceid in CeidList)
                {
                    if (ceid < 0 || ceid > 65535)
                    {
                        errors.Add($"Invalid CEID: {ceid}. CEID must be between 0 and 65535.");
                    }
                }
            }

            return errors;
        }

        p
        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F37 W");
            sml.AppendLine("<L [2]");
            sml.AppendLine($"\t<BOOLEAN {Enable.ToString().ToUpperInvariant()}>");
            sml.AppendLine($"\t<L [{CeidList.Count}]");

            foreach (int ceid in CeidList)
            {
                sml.AppendLine($"\t\t<U2 {ceid}>");
            }

            sml.AppendLine("\t>");
            sml.AppendLine(">");

            return sml.ToString();
        }
    }
}