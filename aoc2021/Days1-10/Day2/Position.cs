using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day2
{
    public class Position
    {
        private int depth = 0;
        private int horisontal = 0;

        public Position()
        {
        }
        public Position (Position p)
        {
            depth = p.depth;
            horisontal = p.horisontal;
        }

        internal void ExecuteCommand(string cmd)
        {
            var cmdParts = cmd.Split(' ');
            var nbrOfSteps = Int32.Parse(cmdParts[1]);

            switch (cmdParts[0])
            {
                case "forward":
                    Forward(nbrOfSteps);
                    break;
                case "up":
                    Up(nbrOfSteps);
                    break;
                case "down":
                    Down(nbrOfSteps);
                    break;
                default:
                    break;
            }
        }

        public (int, int) GetPosition()
        {
            return (depth, horisontal);
        }

        public virtual int GetProduct()
        {
            return depth*horisontal;
        }

        public int GetDepth()
        {
            return depth;
        }

        public void ChangeDepth(int v)
        {
            if (v < 0 && v*-1 > depth ) return;
            depth += v;
        }

        public virtual void Down(int v)
        {
            ChangeDepth(v);
        }

        public virtual void Up(int v)
        {
            ChangeDepth(-v);
        }

        public int GetHorisontal()
        {
            return horisontal;
        }

        public virtual void Forward(int v)
        {
            horisontal += v;
        }

        public void Backward(int v)
        {
            horisontal -= v;
        }
    }
}
