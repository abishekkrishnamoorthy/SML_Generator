
using System.Text;
namespace SML_Generator
{
    public class S7F5Command : ISecsCommand
    {
        public string PPID { get; set; }

        public string Name => "S7F5";

        public string Description =>
            "Process Program Request - Requests the process program identified by PPID.";

        public S7F5Command()
        {
            PPID = "";
        }

        public S7F5Command(string ppid)
        {
            PPID = ppid;
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S7F5 W");

            sml.AppendLine(
                $"<A [{PPID.Length}] \"{PPID}\">.");

            return sml.ToString();
        }
    }
}
