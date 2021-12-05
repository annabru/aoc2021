using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day5
{
    internal class Map
    {
        int[,] map;

        public Map()
        {
            map = new int[1000, 1000];
        }

        internal void AddStraightLines(List<Line> lines)
        {
            foreach (Line line in lines)
            {
                AddStraightLine(line);
            }
        }
        internal void AddLines(List<Line> lines)
        {
            foreach (Line line in lines)
            {
                AddLine(line);
            }
        }

        private bool AddStraightLine(Line line)
        {
            if(line.Start.X == line.End.X )
            {
                AddVerticalLine(line);
                return true;
            }else if (line.Start.Y == line.End.Y)
            {
                AddHorisontalLine(line);
                return true;
            }
            return false;
        }

        private void AddLine(Line line)
        {
            if (!AddStraightLine(line))
            {
                AddDiagonalLine(line);
            }
        }

        internal List<(int,int)> GetThicknessAbove(int x)
        {
            var coords = new List<(int,int)>();

            for(int row = 0; row < 1000; row++)
            {
                for (int col = 0; col < 1000; col++)
                {
                    if (map[row, col] >= x)
                    {
                        coords.Add((row, col));
                    }
                }
            }
            return coords;
        }

        private void AddVerticalLine(Line line)
        {
            var length = line.End.Y - line.Start.Y;
            var direction = Math.Sign(length);
            for (int i = 0; i <= Math.Abs(length); i++)
            {
                map[line.Start.X, line.Start.Y + i*direction ] += 1;
            }
        }

        private void AddHorisontalLine(Line line)
        {
            var length = line.End.X - line.Start.X;
            var direction = Math.Sign(length);
            for (int i = 0; i <= Math.Abs(length); i++)
            {
                map[line.Start.X + i*direction, line.Start.Y] += 1;
            }
        }


        // Strictly diagonal -> same x & y length
        private void AddDiagonalLine(Line line)
        {
            var length = line.End.X - line.Start.X;
            var xdirection = Math.Sign(length);
            var ydirection = Math.Sign(line.End.Y - line.Start.Y);
            for (int i = 0; i <= Math.Abs(length); i++)
            {
                map[line.Start.X + i * xdirection, line.Start.Y + i*ydirection] += 1;
            }
        }
    }
}
