using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S14F3Command : ISecsCommand
    {
        public string ObjectSpec { get; set; }
        public string ObjectType { get; set; }
        public List<string> ObjectIDs { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }

        public string Name => "S14F3";
        public string Description =>
            "Set Attributes Request - Requests updates to selected attributes of matching objects.";
        public S14F3Command()
        {
            ObjectSpec = "";
            ObjectType = "Carrier";
            ObjectIDs = new List<string> { "CARR001" };
            AttributeName = "UserNote";
            AttributeValue = "Test";
        }

        public S14F3Command(string objectSpec, string objectType, List<string> objectIDs, string attributeName, string attributeValue)
        {
            ObjectSpec = objectSpec;
            ObjectType = objectType;
            ObjectIDs = objectIDs;
            AttributeName = attributeName;
            AttributeValue = attributeValue;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S14F3 W");
            sml.AppendLine("<L [4]");
            sml.AppendLine($"{tab}<A '{ObjectSpec}'>");
            sml.AppendLine($"{tab}<A '{ObjectType}'>");
            sml.AppendLine($"{tab}<L [{ObjectIDs.Count}]");
            foreach (var obj in ObjectIDs)
            {
                sml.AppendLine($"{tab}{tab}<A '{obj}'>");
            }
            sml.AppendLine($"{tab}>");
            sml.AppendLine($"{tab}<L [1]>");
            sml.AppendLine($"{tab}{tab}<L [2]>");
            sml.AppendLine($"{tab}{tab}{tab}<A '{AttributeName}'>");
            sml.AppendLine($"{tab}{tab}{tab}<A '{AttributeValue}'>");
            sml.AppendLine($"{tab}{tab}>");
            sml.AppendLine($"{tab}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
