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

        private readonly string _filePath="c:\\temp\\sml.sml";
         

        public SmlBuilder(string filePath)
        {
            if (filePath != null){
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
                sml.AppendLine(command.Generate()+Environment.NewLine+"./");
            }


            File.WriteAllText(_filePath, sml.ToString());

            return true;
        }
    }
}