using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S16F3Command : ISecsCommand
    {
        public uint DataID { get; set; }
        public byte MaterialFormat { get; set; }
        public List<string> MaterialIDs { get; set; }
        public uint RecipeMethod { get; set; }
        public string RecipeID { get; set; }
        public bool AutoStart { get; set; }

        public string Name => "S16F3";
        public string Description =>
            "Process Job Create Request - Requests creation of a process job with its material and recipe settings.";
        public S16F3Command()
        {
            DataID = 1001;
            MaterialFormat = 1;
            MaterialIDs = new List<string> { "WAFER001" };
            RecipeMethod = 1;
            RecipeID = "RCP001";
            AutoStart = true;
        }

        public S16F3Command(uint dataID, byte materialFormat, List<string> materialIDs, uint recipeMethod, string recipeID, bool autoStart)
        {
            DataID = dataID;
            MaterialFormat = materialFormat;
            MaterialIDs = materialIDs;
            RecipeMethod = recipeMethod;
            RecipeID = recipeID;
            AutoStart = autoStart;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S16F3 W");
            string AutoStartText = AutoStart ? "TRUE" : "FALSE";
            sml.AppendLine("<L [5]");
            sml.AppendLine($"{tab}<U4 {DataID}>");
            sml.AppendLine($"{tab}<U1 {MaterialFormat}>");
            sml.AppendLine($"{tab}<L [{MaterialIDs.Count}]");
            foreach (var material in MaterialIDs)
            {
                sml.AppendLine($"{tab}{tab}<A '{material}'>");
            }
            sml.AppendLine($"{tab}>");
            sml.AppendLine($"{tab}<L [3]>");
            sml.AppendLine($"{tab}{tab}<U4 {RecipeMethod}>");
            sml.AppendLine($"{tab}{tab}<A '{RecipeID}'>");
            sml.AppendLine($"{tab}{tab}<L [0]>");
            sml.AppendLine($"{tab}>");
            sml.AppendLine($"{tab}<BOOLEAN {AutoStartText}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
