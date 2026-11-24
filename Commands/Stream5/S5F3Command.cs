
using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S5F3Command : ISecsCommand
    {
        public byte ALED { get; set; }
        public uint ALID { get; set; }
        public bool AllAlarms { get; set; }

        public string Name => "S5F3";

        public string Description =>
            "Enable/Disable Alarm Send - Enables or disables reporting for selected alarms.";

        public S5F3Command()
        {
            ALED = 1;
            ALID = 0;
            AllAlarms = false;
        }

        public S5F3Command(byte aled, uint alid)
        {
            ALED = aled;
            ALID = alid;
            AllAlarms = false;
        }

        public S5F3Command(byte aled, bool allAlarms)
        {
            ALED = aled;
            ALID = 0;
            AllAlarms = allAlarms;
        }

        public virtual List<string> Validate()
        {
            List<string> errors = new List<string>();

            if (ALED != 0 && ALED != 1)
            {
                errors.Add("ALED must be 0 or 1.");
            }

            return errors;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S5F3 W");
            sml.AppendLine("<L [2]");
            sml.AppendLine($"{tab}{tab}<B [1] 0x{ALED:X2}>");

            if (AllAlarms)
            {
                sml.AppendLine($"{tab}{tab}<L [0]>");
            }
            else
            {
                sml.AppendLine($"{tab}{tab}<U4 [1] {ALID}>");
            }

            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
