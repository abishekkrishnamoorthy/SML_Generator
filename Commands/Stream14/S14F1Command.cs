using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S14F1Command : ISecsCommand
    {
        public string ObjectSpec { get; set; }
        public string ObjectType { get; set; }
        public List<string> ObjectIDs { get; set; }
        public List<string> AttributeIDs { get; set; }

        public string Name => "S14F1";
        public string Description =>
            "Get Attributes Request - Requests selected attributes for matching objects.";
        public S14F1Command()
        {
            ObjectSpec = "";
            ObjectType = "Carrier";
            ObjectIDs = new List<string> { "CARR001" };
            AttributeIDs = new List<string> { "CarrierID", "SlotMap" };
        }

        public S14F1Command(string objectSpec, string objectType, List<string> objectIDs, List<string> attributeIDs)
        {
            ObjectSpec = objectSpec;
            ObjectType = objectType;
            ObjectIDs = objectIDs;
            AttributeIDs = attributeIDs;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S14F1 W");
            sml.AppendLine("<L [5]");
            sml.AppendLine($"{tab}<A '{ObjectSpec}'>");
            sml.AppendLine($"{tab}<A '{ObjectType}'>");
            sml.AppendLine($"{tab}<L [{ObjectIDs.Count}]");
            foreach (var obj in ObjectIDs)
            {
                sml.AppendLine($"{tab}{tab}<A '{obj}'>");
            }
            sml.AppendLine($"{tab}>");
            sml.AppendLine($"{tab}<L [0]>");
            sml.AppendLine($"{tab}<L [{AttributeIDs.Count}]");
            foreach (var attr in AttributeIDs)
            {
                sml.AppendLine($"{tab}{tab}<A '{attr}'>");
            }
            sml.AppendLine($"{tab}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
