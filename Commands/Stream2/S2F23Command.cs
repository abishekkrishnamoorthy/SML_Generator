
using System;
using System.Collections.Generic;
using System.Text;

namespace SML_Generator
{
    public class S2F23Command : ISecsCommand
    {
        // 1. Input properties
        public int TraceID { get; set; }
        public string SamplingPeriod { get; set; }
        public int TotalSamples { get; set; }
        public int ReportGroupSize { get; set; }
        public List<int> SvidList { get; set; }

        // 2. Default constructor
        public S2F23Command()
        {
            TraceID = 0;
            SamplingPeriod = "";
            TotalSamples = 0;
            ReportGroupSize = 0;
            SvidList = new List<int>();
        }

        // Parameterized constructor
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

        // 3. Command name
        public string Name => "S2F23";

        // 5. SML generation
        public virtual string Generate()
        {
            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F23 W");
            sml.AppendLine("<L [5]");

            // Trace Request ID
            sml.AppendLine($"    <U4  {TraceID}>");

            // Data Sampling Period
            sml.AppendLine(
                $"    <A [6] \"{SamplingPeriod}\">");

            // Total Samples
            sml.AppendLine($"    <U4  {TotalSamples}>");

            // Report Group Size
            sml.AppendLine($"    <U4  {ReportGroupSize}>");

            // SVID List
            sml.AppendLine($"    <L [{SvidList.Count}]");

            foreach (int svid in SvidList)
            {
                sml.AppendLine($"        <U4 {svid}>");
            }

            sml.AppendLine("    >");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
