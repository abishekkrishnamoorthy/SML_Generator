using System.Text;

namespace SML_Generator
{
    public class S16F21Command : ISecsCommand
    {

        public string Name => "S16F21";
        public string Description =>
            "Process Job Creation Limit Request - Requests the process job creation limit.";
        public S16F21Command()
        {
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S16F21 W.");

            return sml.ToString();
        }
    }
}
