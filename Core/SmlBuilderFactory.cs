using System.Collections.Generic;

namespace SML_Generator
{
    public static class SmlBuilderFactory
    {
        public static void GetStatusVar(SmlBuilder smlcode)
        {
            List<ISecsCommand> commands = new List<ISecsCommand>
            {
                new S1F13Command(),
                new S1F1Command(),
                new S1F11Command()
            };

            smlcode.AddCommand(commands);
        }
    }
}
