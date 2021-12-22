using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day10_19.Day18;

public class SFNumber
{

    public SFNumber? Left { get; private set; }
    public SFNumber? Right { get; private set; }

    public int? LeftNumber { get; private set; }
    public int? RightNumber { get; private set; }

    public SFNumber(SFNumber left, SFNumber right)
    {
        Left = left;
        Right = right;
    }

    public SFNumber(string str)
    {
        var (leftString, rightString) = FindLeftAndRightString(str);

        if(int.TryParse(leftString, out var leftNumber))
        {
            LeftNumber = leftNumber;
        }
        else
        {
            Left = new SFNumber(rightString);
        }

        if (int.TryParse(rightString, out var rightNumber))
        {
            RightNumber = rightNumber;
        }
        else
        {
            Right = new SFNumber(rightString);
        }
    }

    public SFNumber Add(SFNumber x, SFNumber y)
    {
        var res = new SFNumber(x, y);
        res.Reduce();
        return res;
    }

    private void Reduce()
    {
        while (Explode())
        {
        }

        while (Split())
        {
            Reduce();
        }
    }

    private bool Explode()
    {
        if (ShouldExplode(0))
        {
            return true;
        }
        return false;
    }

    private bool ShouldExplode(int depth )
    {
        depth++;
        if (depth > 4)
        {
            return true;
        }
        return true;
    }

    private bool Split()
    {
        throw new NotImplementedException();
    }

    private (string,string) FindLeftAndRightString(string str)
    {
        str = str.Substring(1, str.Length - 2 );
        var rightBrackets = 0;
        int i = 0;
        char c;
        do {
            c = str[i];
            if (c == '[')
            {
                rightBrackets++;
            }else if(c == ']')
            {
                rightBrackets--;
            }
            i++;
        } while (rightBrackets != 0 || c != ',');
        
        return (str.Substring(0, i-1), str.Substring(i)); 
    }
}