
using System.Text;
namespace SML_Generator
{
    public class S7F19Command : ISecsCommand
    {
        public string Name => "S7F19";

        public string Description =>
            "Current Process Program Directory Request - Requests the list of process programs stored by the equipment.";

        public S7F19Command()
        {
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S7F19 W.");

            return sml.ToString();
        }
    }
}
