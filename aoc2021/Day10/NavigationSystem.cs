using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day10;
public class NavigationSystem
{
    private List<Chunk> lines;

    public NavigationSystem(List<string> inputLines)
    {
        lines = new List<Chunk>();
        foreach (string line in inputLines)
        {
            var input = line;
            lines.Add(new Chunk(input));
        }
    }

    public int GetCorruptedScore()
    {
        var score = 0;
        foreach (var chunk in lines)
        {
            score += chunk.GetCorruptedScore();
        }
        return score;
    }

    public long GetIncompleteScore()
    {
        var scores = new List<long>();
        foreach (var chunk in lines)
        {
            long score = chunk.GetCompleteScore();
            if(score > 0)
            {
                scores.Add(score);
            }
            else if(score < 0)
            {
                Console.WriteLine("Huh?");
            }
        }

        scores.Sort();
        int middle = scores.Count()/2;

        return scores[middle];
    }
}
