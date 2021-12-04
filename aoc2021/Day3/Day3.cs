using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day3
{
    internal class Day3
    {

        public static int CalculatePowerConsumptionFromFile(string filepath)
        {
            DiagnosticReport diagnosticReport = new DiagnosticReport(); 
            var matrix = FileHelper.GetMatrixBoolFromFile(filepath);
            return diagnosticReport.PowerConsumption(matrix);
        }

        public static int CalculateLifeSupportRatingFromFile(string filepath)
        {
            DiagnosticReport diagnosticReport = new DiagnosticReport();
            var matrix = FileHelper.GetMatrixBoolFromFile(filepath);
            return diagnosticReport.GetLifeSupportRating(matrix);
        }
    }
}
