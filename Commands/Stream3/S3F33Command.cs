using System.Text;

namespace SML_Generator
{
    public class S3F33Command : ISecsCommand
    {

        public string Name => "S3F33";
        public string Description =>
            "Cancel All POD Out Request - Requests cancellation of all pod-out operations.";
        public S3F33Command()
        {
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S3F33 W.");

            return sml.ToString();
        }
    }
}
