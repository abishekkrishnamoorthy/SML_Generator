using System.Text;

namespace SML_Generator
{
    public class S16F29Command : ISecsCommand
    {
        public byte MaterialOrder { get; set; }

        public string Name => "S16F29";
        public string Description =>
            "Process Job Material Order Set - Requests a material order for a process job.";
        public S16F29Command()
        {
            MaterialOrder = 1;
        }

        public S16F29Command(byte materialOrder)
        {
            MaterialOrder = materialOrder;
        }

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S16F29 W");
            sml.AppendLine($"<U1 {MaterialOrder}>.");

            return sml.ToString();
        }
    }
}
