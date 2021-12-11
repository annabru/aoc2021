using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021.Day8
{
    public class Day8
    {
        public static int value { get; private set; }

        public static int Count1_4_7_8(List<List<string>> input)
        {
            int counter = 0;
            foreach (var row in input)
            {
                foreach(var item in row)
                {
                    if(item.Length == 2 || item.Length == 3 || item.Length == 4 || item.Length == 7)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public static int GetSum(List<List<string>> input, List<List<string>> output)
        {
            int sum = 0;
            for (int i = 0; i < input.Count; i++)
            {
                var display = new SegmentDisplay();
                display.FindNumberWires(input[i]);
                sum += display.GetNumber(output[i]);
            }
            return sum;
        }
    }

    public class SegmentDisplay 
    {
        private Dictionary<int, string> numberWires = new Dictionary<int, string>();

        public SegmentDisplay()
        {

        }

        public void FindNumberWires(List<string> input)
        {
            FindNumberWiresBasedOnLength(input);

            FindNumberWiresBasedOtherNumbers(input);
        }

        private void FindNumberWiresBasedOtherNumbers(List<string> input)
        {
            foreach (var signal in input)
            {
                switch (signal.Length)
                {
                    case 6:
                        if (signal.ContainsAll(numberWires.GetValueOrDefault(4)))
                        {
                            numberWires[9] = signal;
                        }
                        else if(signal.ContainsAll(numberWires.GetValueOrDefault(7) ) ) 
                        {
                            numberWires[0] = signal;
                        }
                        else
                        {
                            numberWires[6] = signal;
                        }
                        break;
                    case 5:
                        if(signal.ContainsAll(numberWires.GetValueOrDefault(7)))
                        {
                            numberWires[3] = signal;
                        }
                        else if( signal.RemoveAll(numberWires.GetValueOrDefault(4) ).Length == 2 )
                        {
                            numberWires[5] = signal;
                        }
                        else
                        {
                            numberWires[2] = signal;
                        }
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Heh?");
                        break;
                }
            }
        }

        private void FindNumberWiresBasedOnLength(List<string> input)
        {
            foreach (var signal in input)
            {
                switch (signal.Length)
                {
                    case 2:
                        numberWires[1] = signal;
                        break;
                    case 3:
                        numberWires[7] = signal;
                        break;
                    case 4:
                        numberWires[4] = signal;
                        break;
                    case 7:
                        numberWires[8] = signal;
                        break;
                    default:
                        break;

                };
            }
        }

        internal int GetNumber(List<string> output)
        {

            var res = "";

            foreach(var signal in output)
            {
                foreach (var kvp in numberWires)
                {
                    if (kvp.Value.Length == signal.Length && kvp.Value.ContainsAll(signal))
                    {
                        res += kvp.Key.ToString();
                        break;
                    }
                }
            }

            return int.Parse(res);
        }
    }
}
