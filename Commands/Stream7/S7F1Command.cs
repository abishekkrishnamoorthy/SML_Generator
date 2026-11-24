
using System.Text;
namespace SML_Generator
{
    public class S7F1Command : ISecsCommand
    {
        public string PPID { get; set; }
        public int Length { get; set; }

        public string Name => "S7F1";

        public string Description =>
            "Process Program Load Inquire - Requests authorization to send a process program of the specified length.";

        public S7F1Command()
        {
            PPID = "";
            Length = 0;
        }

        public S7F1Command(string ppid, int length)
        {
            PPID = ppid;
            Length = length;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S7F1 W");
            sml.AppendLine("<L [2]");

            sml.AppendLine(
                $"{tab}{tab}<A [{PPID.Length}] \"{PPID}\">");

            sml.AppendLine(
                $"{tab}{tab}<U4 [1] {Length}>");

            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
