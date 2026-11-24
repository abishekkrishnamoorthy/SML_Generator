
using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S2F23Command : ISecsCommand
    {
        public int TraceID { get; set; }
        public string SamplingPeriod { get; set; }
        public int TotalSamples { get; set; }
        public int ReportGroupSize { get; set; }
        public List<int> SvidList { get; set; }

        public S2F23Command()
        {
            TraceID = 0;
            SamplingPeriod = "";
            TotalSamples = 0;
            ReportGroupSize = 0;
            SvidList = new List<int>();
        }

        public S2F23Command(
            int traceID,
            string samplingPeriod,
            int totalSamples,
            int reportGroupSize,
            List<int> svidList)
        {
            TraceID = traceID;
            SamplingPeriod = samplingPeriod;
            TotalSamples = totalSamples;
            ReportGroupSize = reportGroupSize;
            SvidList = svidList;
        }

        public string Name => "S2F23";
        public string Description =>
            "Trace Initialize Send - Configures a trace using the selected variables and sampling settings.";
        public virtual string Generate()
        {
            const string tab = "  ";
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F23 W");
            sml.AppendLine("<L [5]");

            sml.AppendLine($"{tab}{tab}<U4  {TraceID}>");

            sml.AppendLine(
                $"{tab}{tab}<A [6] \"{SamplingPeriod}\">");

            sml.AppendLine($"{tab}{tab}<U4  {TotalSamples}>");

            sml.AppendLine($"{tab}{tab}<U4  {ReportGroupSize}>");

            sml.AppendLine($"{tab}{tab}<L [{SvidList.Count}]");

            foreach (int svid in SvidList)
            {
                sml.AppendLine($"{tab}{tab}{tab}{tab}<U4 {svid}>");
            }

            sml.AppendLine($"{tab}{tab}>");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
