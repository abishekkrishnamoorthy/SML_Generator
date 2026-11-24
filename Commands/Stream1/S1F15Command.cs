using System.Text;

namespace SML_Generator
{
    public class S1F15Command : ISecsCommand
    {
        public string Name => "S1F15";
        public string Description =>
            "Request Off-Line - Requests that the equipment transition to the off-line state.";
        public S1F15Command()
        {
        }
        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S1F15 W");
            sml.AppendLine("<L [0]");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
