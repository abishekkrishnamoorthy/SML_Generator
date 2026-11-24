using System.Text;

namespace SML_Generator
{
    public class S16F17Command : ISecsCommand
    {
        public string ProcessJobID { get; set; }

        public string Name => "S16F17";
        public string Description =>
            "Process Job Dequeue Request - Requests removal of a process job from the queue.";
        public S16F17Command()
        {
            ProcessJobID = "PJ001";
        }

        public S16F17Command(string processJobID)
        {
            ProcessJobID = processJobID;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S16F17 W");
            sml.AppendLine("<L [1]>");
            sml.AppendLine($"{tab}<A '{ProcessJobID}'>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
