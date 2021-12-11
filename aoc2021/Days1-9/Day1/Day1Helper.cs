using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    public static class Day1Helper
    {
        public static bool IsIncrease(int v1, int v2)
        {
            return v1 < v2;
        }

        public static int CountIncreasesBulkOfX(List<int> list, int bulk)
        {
            if (bulk < 1 || list == null || list.Count <= bulk )
            {
                return 0;
            }

            int increases = 0;
            for (int i = bulk; i < list.Count; i++)
            {
                if (IsIncrease(list[i - bulk], list[i]))
                {
                    increases++;
                }
            }
            return increases;
        }
    }

}
