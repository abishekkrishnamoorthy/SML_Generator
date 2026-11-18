using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SML_Generator
{
    public class S2F37Command : ISecsCommand

    {
        public bool IsEnabled { get; set; }
        public List<int> EventIDList { get; set; }
        public string Name => "S2F37";

        public S2F37Command()
        {
            IsEnabled = true;
            EventIDList = new List<int>();
        }

        public S2F37Command( bool isEnabled,List<int> eventIDList)
        {
            IsEnabled = isEnabled;
            EventIDList = eventIDList
                ?? new List<int>();
        }
        public virtual List<string> Validate()
        {
            List<string> errors = new List<string>();

            return errors;
        }


        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();



            sml.AppendLine("S2F37 W");
            sml.AppendLine("<L [2]");

            // Enable or disable reporting
            string enableValue = IsEnabled ? "TRUE" : "FALSE";

            sml.AppendLine(
                $"    <BOOLEAN [1] {enableValue}>");

            // Selected CEIDs
            sml.AppendLine(
                $"    <L [{EventIDList.Count}]");

            foreach (int eventID in EventIDList)
            {
                sml.AppendLine(
                    $"        <U4 [1] {eventID}>");
            }

            sml.AppendLine("    >");
            sml.AppendLine(">.");


            return sml.ToString();
        }
    }
}
