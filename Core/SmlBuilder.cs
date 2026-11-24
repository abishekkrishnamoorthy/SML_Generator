using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SML_Generator
{
    public class SmlBuilder
    {
        private readonly List<ISecsCommand> _commands = new List<ISecsCommand>();

        private readonly string _filePath;

        public SmlBuilder(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = Path.Combine(
                    Path.GetTempPath(),
                    "GeneratedSML.txt"
                );
            }

            _filePath = filePath;
        }
        public void AddCommand(ISecsCommand command)
        {
            if (command != null)
            {
                _commands.Add(command);
            }
        }

        public void AddCommand(List<ISecsCommand> commands)
        {
            _commands.AddRange(commands);
        }
        public bool Build()
        {
            StringBuilder sml = new StringBuilder();

            foreach (ISecsCommand command in _commands)
            {
                sml.AppendLine($"// Command: {command.Name}");
                sml.AppendLine($"// Description: {command.Description}");
                sml.AppendLine();

                sml.AppendLine(command.Generate());

                sml.AppendLine();
            }

            File.WriteAllText(_filePath, sml.ToString());

            return true;
        }
    }
}
