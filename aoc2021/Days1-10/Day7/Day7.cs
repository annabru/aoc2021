using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day7
{
    public class Day7
    {
        private int[] nbrOfSteps = new int[2000];

        public Day7(List<int> crabs, bool constantRate)
        {
            if (constantRate)
            {
                FuelConsumptionWithConstantRate(crabs);
            }
            else
            {
                FuelConsumption(crabs);
            }
        }

        private void FuelConsumption(List<int> crabs)
        {
            foreach (int crab in crabs)
            {
                for (int i = 0; i < nbrOfSteps.Length; i++)
                {
                    nbrOfSteps[i] += CalculateFuelConsumptionFromAtoB(crab, i);
                }
            }
        }

        private static int CalculateFuelConsumptionFromAtoB(int A, int B)
        {
            int numberOfSteps = Math.Abs(B - A); 
            return numberOfSteps * (1 + numberOfSteps) / 2;
        }

        private void FuelConsumptionWithConstantRate(List<int> crabs)
        {
            foreach (int crab in crabs)
            {
                for (int i = 0; i < nbrOfSteps.Length; i++)
                {
                    nbrOfSteps[i] += Math.Abs(crab - i);
                }
            }
        }

        public int BestPosition()
        {
            int bestPosition = -1;
            for( int i = 0;i < nbrOfSteps.Length; i++)
            {
                if(nbrOfSteps[i] < bestPosition || bestPosition == -1) bestPosition = nbrOfSteps[i];
            }
            return bestPosition;
        }
    }
}
