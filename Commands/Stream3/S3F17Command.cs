using System.Text;

namespace SML_Generator
{
    public class S3F17Command : ISecsCommand
    {
        public uint DataID { get; set; }
        public string CarrierAction { get; set; }
        public string CarrierID { get; set; }
        public byte PortNumber { get; set; }

        public string Name => "S3F17";
        public string Description =>
            "Carrier Action Request - Requests an action on a carrier at a specified port.";
        public S3F17Command()
        {
            DataID = 1001;
            CarrierAction = "ProceedWithCarrier";
            CarrierID = "CARR001";
            PortNumber = 1;
        }

        public S3F17Command(uint dataID, string carrierAction, string carrierID, byte portNumber)
        {
            DataID = dataID;
            CarrierAction = carrierAction;
            CarrierID = carrierID;
            PortNumber = portNumber;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S3F17 W");
            sml.AppendLine("<L [5]");
            sml.AppendLine($"{tab}<U4 {DataID}>");
            sml.AppendLine($"{tab}<A '{CarrierAction}'>");
            sml.AppendLine($"{tab}<A '{CarrierID}'>");
            sml.AppendLine($"{tab}<U1 {PortNumber}>");
            sml.AppendLine($"{tab}<L [0]>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
