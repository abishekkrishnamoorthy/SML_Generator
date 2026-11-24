using System.Text;

namespace SML_Generator
{
    public class S6F23Command : ISecsCommand
    {
        public byte RSDC { get; set; }
        public string Name => "S6F23";
        public string Description =>
            "Request Spooled Data - Requests transmission or deletion of spooled messages.";
        public S6F23Command()
        {
            RSDC = 0;
        }
        public S6F23Command(byte rsdc)
        {
            RSDC = rsdc;
        }
        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S6F23 W");
            sml.AppendLine($"<B 0x{RSDC:X2}>.");
            return sml.ToString();
        }
    }
}
