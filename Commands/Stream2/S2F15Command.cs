
using System;
using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class EquipmentConstant
    {
        public int Ecid { get; set; }

        public int Value { get; set; }

        public EquipmentConstant(int ecid, int value)
        {
            Ecid = ecid;
            Value = value;
        }
    }

    public class S2F15Command : ISecsCommand
    {
        public List<EquipmentConstant> ConstantList { get; set; }

        public string Name => "S2F15";

        public S2F15Command()
        {
            ConstantList = new List<EquipmentConstant>();
        }

        public S2F15Command(List<EquipmentConstant> constantList)
        {
            if (constantList == null)
            {
                throw new ArgumentNullException(nameof(constantList));
            }

            ConstantList = constantList;
        }
        

        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F15 W");
            sml.AppendLine($"<L [{ConstantList.Count}]");

            foreach (EquipmentConstant constant in ConstantList)
            {
                sml.AppendLine("    <L [2]");

                // Equipment Constant ID
                sml.AppendLine(
                    $"        <U4  {constant.Ecid}>");

                // Equipment Constant Value
                sml.AppendLine(
                    $"        <U4  {constant.Value}>");

                sml.AppendLine("    >");
            }

            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
