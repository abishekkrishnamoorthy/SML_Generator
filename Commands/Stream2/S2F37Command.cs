using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S2F37Command : ISecsCommand

    {
        public bool IsEnabled { get; set; }
        public List<int> EventIDList { get; set; }
        public string Name => "S2F37";
        public string Description =>
            "Enable/Disable Event Report - Enables or disables reporting for selected collection events.";
        public S2F37Command()
        {
            IsEnabled = true;
            EventIDList = new List<int>();
        }

        public S2F37Command(bool isEnabled, List<int> eventIDList)
        {
            IsEnabled = isEnabled;
            EventIDList = eventIDList
                ?? new List<int>();
        }
        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F37 W");
            sml.AppendLine("<L [2]");

            string enableValue = IsEnabled ? "TRUE" : "FALSE";

            sml.AppendLine(
                $"{tab}{tab}<BOOLEAN  {enableValue}>");

            sml.AppendLine(
                $"{tab}{tab}<L [{EventIDList.Count}]");

            foreach (int eventID in EventIDList)
            {
                sml.AppendLine(
                    $"{tab}{tab}{tab}{tab}<U4  {eventID}>");
            }

            sml.AppendLine($"{tab}{tab}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
