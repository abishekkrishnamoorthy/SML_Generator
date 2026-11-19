using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SML_Generator
{
    public class S6F23Command : ISecsCommand
    {
        public byte RSDC { get; set; }
        public string Name => "S6F23";
        public S6F23Command()
        {
            RSDC = 0;
        }
        public S6F23Command(byte rsdc)
        {
            RSDC = rsdc;
        }
        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();
            sml.AppendLine("S6F23 W");
            sml.AppendLine($"<B 0x{RSDC:X2}>.");
            return sml.ToString();
        }
    }
}