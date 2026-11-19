
using System.Collections.Generic;

namespace SML_Generator
{
    public class S1F1Command : ISecsCommand
    {
        public string Name => "S1F1";
        public S1F1Command() { 

        }
        public virtual string Generate()
        {
            // S1F1 (Are You There) is a header-only request with no data body.
            return "S1F1 W";
        }
    }
}
