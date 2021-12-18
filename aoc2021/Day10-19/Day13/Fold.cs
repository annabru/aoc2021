using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day10_19.Day13;
public class Fold
{
    public HashSet<(int, int)> points = new HashSet<(int, int)>();

    public Fold(List<string> lines)
    {
        foreach(var line in lines)
        {
            var coord = line.Split(',').Select(s => int.Parse(s)).ToList();
            points.Add((coord[0], coord[1]));
        }
    }

    public void PrintPoints()
    {
        var width = points.Select(p => p.Item1).Max();
        var height = points.Select(p => p.Item2).Max();

        for(int i = 0; i <= height; i++)
        {
            for(int j = 0; j <= width; j++)
            {
                if(points.Contains((j, i)))
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }

    public void FoldItX(List<(char, int)> instructions)
    {
        foreach(var instruction in instructions)
        {
            FoldIt(instruction.Item1, instruction.Item2);
        }
    }

    private void FoldIt(char axis, int position)
    {
        var newPoints = new List<(int, int)>();
        if(axis == 'x')
        {
            points.RemoveWhere(p => {
                var removePoint = p.Item1 > position;
                if (removePoint)
                {
                    newPoints.Add((2 * position - p.Item1, p.Item2));
                }
                return removePoint;
            });
        }
        else
        {
            points.RemoveWhere(p => {
                var removePoint = p.Item2 > position;
                if (removePoint)
                {
                    newPoints.Add((p.Item1, 2 * position - p.Item2));
                }
                return removePoint;
            });
        }

        foreach(var point in newPoints)
        {
            points.Add(point);
        }
    }
}
