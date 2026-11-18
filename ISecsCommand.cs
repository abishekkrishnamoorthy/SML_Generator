using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SML_Generator
{
    public interface ISecsCommand
    {
        string Name { get; }
        List<string> Validate();
        string Generate();
    }
}
