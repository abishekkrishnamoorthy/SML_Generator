using System.Text;

namespace SML_Generator
{
    public class S3F23Command : ISecsCommand
    {
        public string PortGroupAction { get; set; }
        public string PortGroupName { get; set; }

        public string Name => "S3F23";
        public string Description =>
            "Port Group Action Request - Requests an action on a specified port group.";
        public S3F23Command()
        {
            PortGroupAction = "ExampleAction";
            PortGroupName = "PG01";
        }

        public S3F23Command(string portGroupAction, string portGroupName)
        {
            PortGroupAction = portGroupAction;
            PortGroupName = portGroupName;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S3F23 W");
            sml.AppendLine("<L [3]");
            sml.AppendLine($"{tab}<A '{PortGroupAction}'>");
            sml.AppendLine($"{tab}<A '{PortGroupName}'>");
            sml.AppendLine($"{tab}<L [0]>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
