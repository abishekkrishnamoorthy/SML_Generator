using System.Text;

namespace SML_Generator
{
    public class S6F15Command : ISecsCommand
    {
        public int CEID { get; set; }

        public string Name => "S6F15";
        public string Description =>
            "Event Report Request - Requests data for a specified collection event.";
        public S6F15Command()
        {
            CEID = 0;
        }

        public S6F15Command(int ceid)
        {
            CEID = ceid;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S6F15 W");
            sml.AppendLine("<L [1]");

            sml.AppendLine($"{tab}{tab}<U4 {CEID}>");

            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
