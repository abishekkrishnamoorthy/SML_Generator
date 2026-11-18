
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

        // 4. Input validation
        public virtual List<string> Validate()
        {
            List<string> errors = new List<string>();

            // Validate Trace ID
            if (TraceID < 0)
            {
                errors.Add("TraceID cannot be negative.");
            }

            // Validate sampling period (hhmmss)
            if (string.IsNullOrEmpty(SamplingPeriod) ||
                SamplingPeriod.Length != 6)
            {
                errors.Add(
                    "SamplingPeriod must contain 6 digits (hhmmss).");
            }
            else
            {
                int hours = 0;
                int minutes = 0;
                int seconds = 0;

                bool valid =
                    int.TryParse(SamplingPeriod.Substring(0, 2), out hours) &&
                    int.TryParse(SamplingPeriod.Substring(2, 2), out minutes) &&
                    int.TryParse(SamplingPeriod.Substring(4, 2), out seconds);

                if (!valid ||
                    minutes > 59 ||
                    seconds > 59 ||
                    (hours == 0 && minutes == 0 && seconds == 0))
                {
                    errors.Add(
                        "SamplingPeriod must be a valid nonzero hhmmss value.");
                }
            }

            // Validate total samples
            if (TotalSamples <= 0)
            {
                errors.Add("TotalSamples must be greater than 0.");
            }

            // Validate report group size
            if (ReportGroupSize <= 0)
            {
                errors.Add("ReportGroupSize must be greater than 0.");
            }

            if (TotalSamples > 0 &&
                ReportGroupSize > TotalSamples)
            {
                errors.Add(
                    "ReportGroupSize cannot exceed TotalSamples.");
            }

            // Validate SVID list
            if (SvidList == null || SvidList.Count == 0)
            {
                errors.Add("SvidList cannot be null or empty.");
            }
            else
            {
                foreach (int svid in SvidList)
                {
                    if (svid < 0)
                    {
                        errors.Add(
                            $"SVID {svid} cannot be negative.");
                    }
                }
            }

            return errors;
        }

        // 5. SML generation
        public virtual string Generate()
        {
            List<string> errors = Validate();

            if (errors.Count > 0)
            {
                throw new InvalidOperationException(
                    string.Join(Environment.NewLine, errors));
            }

            StringBuilder sml = new StringBuilder();

            sml.AppendLine("S2F23 W");
            sml.AppendLine("<L [5]");

            // Trace Request ID
            sml.AppendLine($"    <U4 [1] {TraceID}>");

            // Data Sampling Period
            sml.AppendLine(
                $"    <A [6] \"{SamplingPeriod}\">");

            // Total Samples
            sml.AppendLine($"    <U4 [1] {TotalSamples}>");

            // Report Group Size
            sml.AppendLine($"    <U4 [1] {ReportGroupSize}>");

            // SVID List
            sml.AppendLine($"    <L [{SvidList.Count}]");

            foreach (int svid in SvidList)
            {
                sml.AppendLine($"        <U4 [1] {svid}>");
            }

            sml.AppendLine("    >");
            sml.AppendLine(">.");

            return sml.ToString();
        }
    }
}
