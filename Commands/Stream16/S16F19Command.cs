using System.Text;

namespace SML_Generator
{
    public class S16F19Command : ISecsCommand
    {

        public string Name => "S16F19";
        public string Description =>
            "Process Job List Request - Requests the list of process jobs.";
        public S16F19Command()
        {
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S16F19 W.");

            return sml.ToString();
        }
    }
}
