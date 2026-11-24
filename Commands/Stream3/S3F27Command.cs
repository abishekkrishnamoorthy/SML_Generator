using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S3F27Command : ISecsCommand
    {
        public byte AccessMode { get; set; }
        public List<byte> PortNumbers { get; set; }

        public string Name => "S3F27";
        public string Description =>
            "Change Access Request - Requests an access mode change for selected ports.";
        public S3F27Command()
        {
            AccessMode = 1;
            PortNumbers = new List<byte> { 1 };
        }

        public S3F27Command(byte accessMode, List<byte> portNumbers)
        {
            AccessMode = accessMode;
            PortNumbers = portNumbers;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S3F27 W");
            sml.AppendLine("<L [2]");
            sml.AppendLine($"{tab}<U1 {AccessMode}>");
            sml.AppendLine($"{tab}<L [{PortNumbers.Count}]");
            foreach (var port in PortNumbers)
            {
                sml.AppendLine($"{tab}{tab}<U1 {port}>");
            }
            sml.AppendLine($"{tab}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
