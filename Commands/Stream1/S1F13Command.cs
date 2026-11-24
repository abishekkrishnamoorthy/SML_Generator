
using System.Text;

namespace SML_Generator
{
    public class S1F13Command : ISecsCommand
    {
        public string Name => "S1F13";
        public string Description =>
            "Establish Communications Request - Requests establishment of communication between the host and equipment.";
        public S1F13Command()
        {
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S1F13 W");
            sml.AppendLine("<L [0]");
            sml.AppendLine(">");

            return sml.ToString();
        }
    }
}
