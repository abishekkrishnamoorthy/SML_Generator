using System.Text;

namespace SML_Generator
{
    public class S16F1Command : ISecsCommand
    {
        public uint DataID { get; set; }
        public uint Length { get; set; }

        public string Name => "S16F1";
        public string Description =>
            "Process Job Data Multi-Block Inquire - Requests permission to send a multi-block process job message.";
        public S16F1Command()
        {
            DataID = 1001;
            Length = 1024;
        }

        public S16F1Command(uint dataID, uint length)
        {
            DataID = dataID;
            Length = length;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S16F1 W");
            sml.AppendLine("<L [2]");
            sml.AppendLine($"{tab}<U4 {DataID}>");
            sml.AppendLine($"{tab}<U4 {Length}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
