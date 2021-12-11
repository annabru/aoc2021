using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day2
{
    public class Day2
    {
        public static int GetPositionFromFile(string filepath)
        {
            var position = new Position();  
            var cmds = FileHelper.GetLinesFromFile(filepath);

            foreach (var cmd in cmds)
            {
                position.ExecuteCommand(cmd);
            }

            return position.GetProduct();
        }

        public static int GetPositionAimFromFile(string filepath)
        {
            var position = new PositionAim();
            var cmds = FileHelper.GetLinesFromFile(filepath);

            foreach (var cmd in cmds)
            {
                position.ExecuteCommand(cmd);
            }

            return position.GetProduct();
        }
    }
}
