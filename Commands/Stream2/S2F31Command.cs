
using System;
using System.Text;

namespace SML_Generator
{
    public class S2F31Command : ISecsCommand
    {
        public string Time { get; set; }

        public S2F31Command()
        {
            Time = DateTime.Now.ToString("yyyyMMddHHmmssff");
        }

        public S2F31Command(string time)
        {
            Time = time;
        }

        public string Name => "S2F31";

        public string Description =>
            "Date and Time Set Request - Requests that the equipment set its date and time.";

        public string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F31 W");
            sml.AppendLine($"<A \"{Time}\">.");

            return sml.ToString();
        }
    }
}
