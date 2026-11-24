using System.Text;

namespace SML_Generator
{
    public class S16F9Command : ISecsCommand
    {
        public uint EventID { get; set; }
        public string Timestamp { get; set; }
        public string ProcessJobID { get; set; }
        public uint AttributeID { get; set; }
        public string AttributeValue { get; set; }

        public string Name => "S16F9";
        public string Description =>
            "Process Job Event Notification - Reports a process job event and associated attribute data.";
        public S16F9Command()
        {
            EventID = 100;
            Timestamp = "20261120110000";
            ProcessJobID = "PJ001";
            AttributeID = 10;
            AttributeValue = "Running";
        }

        public S16F9Command(uint eventID, string timestamp, string processJobID, uint attributeID, string attributeValue)
        {
            EventID = eventID;
            Timestamp = timestamp;
            ProcessJobID = processJobID;
            AttributeID = attributeID;
            AttributeValue = attributeValue;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S16F9 W");
            sml.AppendLine("<L [4]");
            sml.AppendLine($"{tab}<U4 {EventID}>");
            sml.AppendLine($"{tab}<A '{Timestamp}'>");
            sml.AppendLine($"{tab}<A '{ProcessJobID}'>");
            sml.AppendLine($"{tab}<L [1]>");
            sml.AppendLine($"{tab}{tab}<L [2]>");
            sml.AppendLine($"{tab}{tab}{tab}<U4 {AttributeID}>");
            sml.AppendLine($"{tab}{tab}{tab}<A '{AttributeValue}'>");
            sml.AppendLine($"{tab}{tab}>");
            sml.AppendLine($"{tab}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
