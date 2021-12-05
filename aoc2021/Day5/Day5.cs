using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static aoc2021.Day5.Line;

namespace aoc2021.Day5
{
    public class Day5
    {
        private List<Line> lines;
        private Map map;

        public Day5(string filepath, bool diagonal)
        {
            lines = GetLinesFromFile(filepath);
            map = new Map();

            if (diagonal)
            {
                map.AddLines(lines);
            }
            else
            {
                map.AddStraightLines(lines);
            }
        }

        public List<(int,int)> GetThicknessAbove(int x)
        {
            return map.GetThicknessAbove(x);
        }

        public int NumberOfCoordinatesWithValue2orHigher()
        {
            return GetThicknessAbove(2).Count();
        }

        private static List<Line> GetLinesFromFile(string filepath)
        {
            var lineStrings = FileHelper.GetLinesFromFile(filepath);

            return Line.Parse(lineStrings);
        }


    }
}
