using System.Text;

namespace SML_Generator
{
    public class S16F23Command : ISecsCommand
    {
        public string ProcessJobID { get; set; }
        public string VariableName { get; set; }
        public ushort VariableValue { get; set; }

        public string Name => "S16F23";
        public string Description =>
            "Process Job Recipe Variable Set - Requests a recipe variable value change for a process job.";
        public S16F23Command()
        {
            ProcessJobID = "PJ001";
            VariableName = "Temperature";
            VariableValue = 200;
        }

        public S16F23Command(string processJobID, string variableName, ushort variableValue)
        {
            ProcessJobID = processJobID;
            VariableName = variableName;
            VariableValue = variableValue;
        }

        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S16F23 W");
            sml.AppendLine("<L [2]>");
            sml.AppendLine($"{tab}<A '{ProcessJobID}'>");
            sml.AppendLine($"{tab}<L [1]>");
            sml.AppendLine($"{tab}{tab}<L [2]>");
            sml.AppendLine($"{tab}{tab}{tab}<A '{VariableName}'>");
            sml.AppendLine($"{tab}{tab}{tab}<U2 {VariableValue}>");
            sml.AppendLine($"{tab}{tab}>");
            sml.AppendLine($"{tab}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
