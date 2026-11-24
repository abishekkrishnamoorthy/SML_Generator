
using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S5F5Command : ISecsCommand
    {
        public List<uint> AlarmIDList { get; set; }

        public string Name => "S5F5";

        public string Description =>
            "List Alarms Request - Requests the status of selected alarms.";

        public S5F5Command()
        {
            AlarmIDList = new List<uint>();
        }

        public S5F5Command(List<uint> alarmIDList)
        {
            AlarmIDList = alarmIDList;
        }

        public virtual List<string> Validate()
        {
            List<string> errors = new List<string>();

            if (AlarmIDList == null)
            {
                errors.Add("AlarmIDList cannot be null.");
            }

            return errors;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S5F5 W");
            sml.AppendLine($"<L [{AlarmIDList.Count}]");

            foreach (uint alarmID in AlarmIDList)
            {
                sml.AppendLine($"{tab}{tab}<U4 [1] {alarmID}>");
            }

            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
