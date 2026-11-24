using System.Text;

namespace SML_Generator
{
    public class S3F25Command : ISecsCommand
    {
        public string PortAction { get; set; }
        public byte PortNumber { get; set; }

        public string Name => "S3F25";
        public string Description =>
            "Port Action Request - Requests an action on a specified port.";
        public S3F25Command()
        {
            PortAction = "ChangeServiceStatus";
            PortNumber = 1;
        }

        public S3F25Command(string portAction, byte portNumber)
        {
            PortAction = portAction;
            PortNumber = portNumber;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S3F25 W");
            sml.AppendLine("<L [3]");
            sml.AppendLine($"{tab}<A '{PortAction}'>");
            sml.AppendLine($"{tab}<U1 {PortNumber}>");
            sml.AppendLine($"{tab}<L [0]>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
