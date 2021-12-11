using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day2
{
    public class PositionAim : Position
    {
        private int depth = 0;
        private int horisontal = 0;
        private int aim = 0;

        public override void Down(int v)
        {
            aim += v;
        }

        public override void Up(int v)
        {
            aim -= v;
        }

        public override void Forward(int v)
        {
            horisontal += v;
            depth += v * aim;
        }

        public int GetAim()
        {
            return aim;
        }

        public override int GetProduct()
        {
            return depth*horisontal;
        }
    }
}
