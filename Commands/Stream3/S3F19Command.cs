using System.Text;

namespace SML_Generator
{
    public class S3F19Command : ISecsCommand
    {

        public string Name => "S3F19";
        public string Description =>
            "Cancel All Carrier Out Request - Requests cancellation of all carrier-out operations.";
        public S3F19Command()
        {
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S3F19 W.");

            return sml.ToString();
        }
    }
}
