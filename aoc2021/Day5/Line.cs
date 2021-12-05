using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day5;

public class Line {

    private Coordinate start;
    private Coordinate end;

    private Line(Coordinate s, Coordinate e)
    { 
        start = s;
        End = e;
    }

    internal Coordinate Start { get => start; set => start = value; }
    internal Coordinate End { get => end; set => end = value; }

    internal static List<Line> Parse(List<string> lineStrings)
    {
        List<Line> lines = new List<Line>();
        foreach (var line in lineStrings)
        {
            lines.Add(Line.Parse(line));
        }
        return lines;
    }

    internal static Line Parse(string line)
    {

        var coordStrings = line.Split("->").Select(c => c.Trim()).ToList();

        var startCoord = Coordinate.Parse(coordStrings[0]);
        var endCoord = Coordinate.Parse(coordStrings[1]);

        return new Line(startCoord, endCoord);
    }


    public class Coordinate
    {
        private int x;
        private int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Coordinate(List<int> c)
        {
            this.x = c[0];
            this.y = c[1];
        }

        internal static Coordinate Parse(string c)
        {
            var splitted = c.Split(',').Select(c => Int32.Parse(c.Trim())).ToList();

            return new Coordinate(splitted);
        }
    }

}
