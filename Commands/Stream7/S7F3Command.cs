
using System.Text;
namespace SML_Generator
{
    public class S7F3Command : ISecsCommand
    {
        public string PPID { get; set; }
        public byte[] PPBody { get; set; }

        public string Name => "S7F3";

        public string Description =>
            "Process Program Send - Sends a process program body to the equipment.";

        public S7F3Command()
        {
            PPID = "";
            PPBody = new byte[0];
        }

        public S7F3Command(string ppid, byte[] ppBody)
        {
            PPID = ppid;
            PPBody = ppBody;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S7F3 W");
            sml.AppendLine("<L [2]");

            sml.AppendLine(
                $"{tab}{tab}<A [{PPID.Length}] \"{PPID}\">");

            sml.AppendLine(
                $"{tab}{tab}<B [{PPBody.Length}]");

            foreach (byte value in PPBody)
            {
                sml.AppendLine(
                    $"{tab}{tab}{tab}{tab}0x{value:X2}");
            }

            sml.AppendLine($"{tab}{tab}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
