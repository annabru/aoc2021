using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day6
{
    public class Day6
    {
        private List<long> nbrOfFishWithIndexDaysLeftTillReproduction = new List<long>(new long[9]);

        public Day6(string start)
        {
            var startInts = start.Split(',').Select(x => int.Parse(x));


            foreach(var fish in startInts)
            {
                nbrOfFishWithIndexDaysLeftTillReproduction[fish] += 1;
            }
        }

        public long ReproduceUntil(int stop)
        {
            if(stop == 0) return CountFishes();

            var nbrOfFishesToReproduce = nbrOfFishWithIndexDaysLeftTillReproduction[0];

            ShiftLeft(nbrOfFishWithIndexDaysLeftTillReproduction);
            nbrOfFishWithIndexDaysLeftTillReproduction[6] += nbrOfFishesToReproduce;
            nbrOfFishWithIndexDaysLeftTillReproduction[8] = nbrOfFishesToReproduce;

            return ReproduceUntil(--stop);
        }

        private long CountFishes()
        {
            return nbrOfFishWithIndexDaysLeftTillReproduction.Sum();
        }

        public static void ShiftLeft<T>(List<T> lst)
        {
            for (int i = 1; i < lst.Count; i++)
            {
                lst[i - 1] = lst[i];
            }

            lst[lst.Count-1] = default(T);
        }
    }
}
