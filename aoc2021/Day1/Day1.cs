using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    public static class Day1
    {
        public static int CountIncreasesFromFile(String filepath, int bulkSize)
        {
            List<int> lines = FileHelper.GetIntsFromFile(filepath);
            return Day1Helper.CountIncreasesBulkOfX(lines, bulkSize);
        }
    }
}
