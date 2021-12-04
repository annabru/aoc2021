using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    internal class FileHelper
    {
        internal static List<int> GetIntsFromFile(string filepath)
        {
            return File.ReadAllLines(filepath).Select(l => Int32.Parse(l)).ToList();
        }

        internal static List<string> GetLinesFromFile(string filepath)
        {
            return File.ReadAllLines(filepath).ToList();
        }

    }
}
