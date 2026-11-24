using System.Text;

namespace SML_Generator
{
    public class S3F31Command : ISecsCommand
    {
        public string LocationID { get; set; }
        public string CarrierSpec { get; set; }
        public string DataSegment { get; set; }
        public uint DataLength { get; set; }
        public string Data { get; set; }

        public string Name => "S3F31";
        public string Description =>
            "Carrier Tag Write Data Request - Requests writing data to a carrier tag.";
        public S3F31Command()
        {
            LocationID = "LP01";
            CarrierSpec = "CARR001";
            DataSegment = "TAG";
            DataLength = 7;
            Data = "CARR001";
        }

        public S3F31Command(string locationID, string carrierSpec, string dataSegment, uint dataLength, string data)
        {
            LocationID = locationID;
            CarrierSpec = carrierSpec;
            DataSegment = dataSegment;
            DataLength = dataLength;
            Data = data;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S3F31 W");
            sml.AppendLine("<L [5]");
            sml.AppendLine($"{tab}<A '{LocationID}'>");
            sml.AppendLine($"{tab}<A '{CarrierSpec}'>");
            sml.AppendLine($"{tab}<A '{DataSegment}'>");
            sml.AppendLine($"{tab}<U4 {DataLength}>");
            sml.AppendLine($"{tab}<A '{Data}'>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
