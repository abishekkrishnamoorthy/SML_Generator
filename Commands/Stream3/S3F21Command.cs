using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S3F21Command : ISecsCommand
    {
        public string PortGroupName { get; set; }
        public byte AccessMode { get; set; }
        public List<byte> PortNumbers { get; set; }

        public string Name => "S3F21";
        public string Description =>
            "Manual verification required: defines a port group and its access mode.";
        public S3F21Command()
        {
            PortGroupName = "PG01";
            AccessMode = 1;
            PortNumbers = new List<byte> { 1, 2 };
        }

        public S3F21Command(string portGroupName, byte accessMode, List<byte> portNumbers)
        {
            PortGroupName = portGroupName;
            AccessMode = accessMode;
            PortNumbers = portNumbers;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S3F21 W");
            sml.AppendLine("<L [3]");
            sml.AppendLine($"{tab}<A '{PortGroupName}'>");
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
