using System.Text;

namespace SML_Generator
{
    public class S16F7Command : ISecsCommand
    {
        public string Timestamp { get; set; }
        public string ProcessJobID { get; set; }
        public uint Milestone { get; set; }
        public bool Flag { get; set; }

        public string Name => "S16F7";
        public string Description =>
            "Process Job Alert Notification - Reports a process job alert and its milestone status.";
        public S16F7Command()
        {
            Timestamp = "20261120110000";
            ProcessJobID = "PJ001";
            Milestone = 1;
            Flag = true;
        }

        public S16F7Command(string timestamp, string processJobID, uint milestone, bool flag)
        {
            Timestamp = timestamp;
            ProcessJobID = processJobID;
            Milestone = milestone;
            Flag = flag;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S16F7 W");
            string FlagText = Flag ? "TRUE" : "FALSE";
            sml.AppendLine("<L [4]");
            sml.AppendLine($"{tab}<A '{Timestamp}'>");
            sml.AppendLine($"{tab}<A '{ProcessJobID}'>");
            sml.AppendLine($"{tab}<U4 {Milestone}>");
            sml.AppendLine($"{tab}<L [2]>");
            sml.AppendLine($"{tab}{tab}<BOOLEAN {FlagText}>");
            sml.AppendLine($"{tab}{tab}<L [0]>");
            sml.AppendLine($"{tab}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
