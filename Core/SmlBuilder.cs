using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SML_Generator
{
    public class SmlBuilder
    {
        private readonly List<ISecsCommand> _commands = new List<ISecsCommand>();

        private readonly string _filePath;
         

        public SmlBuilder(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be empty.");

            _filePath = filePath;
        }


        public void AddCommand(ISecsCommand command)
        {
            _commands.Add(command);
        }



        public bool Build()
        {
            StringBuilder sml = new StringBuilder();

            foreach (ISecsCommand command in _commands)

            { 
                List<string> errors = command.Validate();

                if (errors.Count > 0)
                {
                    throw new InvalidOperationException(
                        $"{command.Name}: {string.Join(", ", errors)}"
                    );
                }
                sml.AppendLine(command.Generate()+Environment.NewLine+"./");
            }


            File.WriteAllText(_filePath, sml.ToString());

            return true;
        }
    }
}