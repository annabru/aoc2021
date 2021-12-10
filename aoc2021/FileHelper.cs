using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    internal class FileHelper
    {

        internal static List<List<string>> Get7SegmentDisplayInputValues(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            var output = lines.Select(l => l.Split('|').First().Trim());
            return output.Select(x => x.Split(' ').ToList()).ToList();
        }

        internal static List<List<string>> Get7SegmentDisplayOutputValues(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            var output = lines.Select(l => l.Split('|').Last().Trim());
            return output.Select(x => x.Split(' ').ToList()).ToList();
        }

        internal static List<int> GetIntsFromFile(string filepath)
        {
            return File.ReadAllLines(filepath).Select(l => Int32.Parse(l)).ToList();
        }

        internal static List<int> GetIntsFromCommaSeperatedFile(string filepath)
        {
            var line = File.ReadAllLines(filepath).First();
            var ints = line.Split(',');
            return ints.Select(l => Int32.Parse(l)).ToList();
        }

        internal static List<string> GetLinesFromFile(string filepath)
        {
            return File.ReadAllLines(filepath).ToList();
        }

        internal static bool[,] GetMatrixBoolFromFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath);

            var matrix = new bool[lines.Count(), lines.First().Count()];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines.First().Count(); j++)
                {
                    if (lines[i][j].Equals('1'))
                    {
                        matrix[i, j] = true;
                    }
                    else
                    {
                        matrix[i, j] = false;
                    }
                }
            }
            return matrix;
        }

        internal static string GetFirstLineFromFile(string filepath)
        {
            return File.ReadAllLines(filepath).First();
        }
    }
}
