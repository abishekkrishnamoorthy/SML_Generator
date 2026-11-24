using System.Text;

namespace SML_Generator
{
    public class S16F5Command : ISecsCommand
    {
        public uint DataID { get; set; }
        public string ProcessJobID { get; set; }
        public string ProcessJobCommand { get; set; }

        public string Name => "S16F5";
        public string Description =>
            "Process Job Command Request - Requests execution of a command for a process job.";
        public S16F5Command()
        {
            DataID = 1001;
            ProcessJobID = "PJ001";
            ProcessJobCommand = "START";
        }

        public S16F5Command(uint dataID, string processJobID, string processJobCommand)
        {
            DataID = dataID;
            ProcessJobID = processJobID;
            ProcessJobCommand = processJobCommand;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S16F5 W");
            sml.AppendLine("<L [4]");
            sml.AppendLine($"{tab}<U4 {DataID}>");
            sml.AppendLine($"{tab}<A '{ProcessJobID}'>");
            sml.AppendLine($"{tab}<A '{ProcessJobCommand}'>");
            sml.AppendLine($"{tab}<L [0]>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
