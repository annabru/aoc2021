using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day10_19.Day18;
public class Day18
{
    public Day18(List<string> lines)
    {
        var res = lines[0];
        for(int i = 1; i < lines.Count; i++)
        {
            res = Add(res, lines[i]);
        }
    }

    private string Add(string x, string y)
    {
        var res = $"[{x},{y}]";
        Reduce(ref res);
        return res;
    }

    private void Reduce(ref string x)
    {
        while (Explode(ref x))
        {

        }

        while(Split(ref x))
        {
            Reduce(ref x);
        }

    }

    private bool Split(ref string x)
    {
        throw new NotImplementedException();
    }

    private bool Explode(ref string str)
    {
        var leftbrackkets = 0;

        for(int i = 0; i < str.Length; i++)
        {
            if(str[i] == '[')
            {
                leftbrackkets ++;
                if(leftbrackkets > 4)
                {
                    // TODO: check if more nested
                    var leftVal = str[i + 1];
                    var rightVal = str[i + 3];
                    str = str.Remove(i-1, 5);

                    AddValueToLeft(ref str, leftVal, i-1);
                    AddValueToRight(ref str, leftVal, i);
                }
            }
        }
    }

    private void AddValueToLeft(ref string str, char leftVal, int index)
    {
        for(int i = index; i > 0; i--)
        {
            if(int.TryParse(str[i] + "", out var number))
            {
                str = (number + leftVal);
            }
        }
    }
}
