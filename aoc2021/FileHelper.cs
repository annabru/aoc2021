namespace aoc2021
{
    public class FileHelper
    {

        public static List<List<string>> Get7SegmentDisplayInputValues(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            var output = lines.Select(l => l.Split('|').First().Trim());
            return output.Select(x => x.Split(' ').ToList()).ToList();
        }

        public static List<List<int>> GetHeightMapFromFile(string filepath)
        {
            var res = new List<List<int>>();
            var lines = File.ReadAllLines(filepath);
            foreach (var line in lines)
            {
                var ints = line.Select(c => int.Parse(c.ToString())).ToList();
                res.Add( ints );
            }
            return res;
        }

        internal static List<List<string>> Get7SegmentDisplayOutputValues(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            var output = lines.Select(l => l.Split('|').Last().Trim());
            return output.Select(x => x.Split(' ').ToList()).ToList();
        }

        internal static List<int> GetIntsFromFile(string filepath)
        {
            return File.ReadAllLines(filepath).Select(l => Int32.Parse(l)).ToList();
        }

        internal static List<int> GetIntsFromCommaSeperatedFile(string filepath)
        {
            var line = File.ReadAllLines(filepath).First();
            var ints = line.Split(',');
            return ints.Select(l => Int32.Parse(l)).ToList();
        }

        public static List<string> GetLinesFromFile(string filepath)
        {
            return File.ReadAllLines(filepath).ToList();
        }

        internal static bool[,] GetMatrixBoolFromFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath);

            var matrix = new bool[lines.Count(), lines.First().Count()];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines.First().Count(); j++)
                {
                    if (lines[i][j].Equals('1'))
                    {
                        matrix[i, j] = true;
                    }
                    else
                    {
                        matrix[i, j] = false;
                    }
                }
            }
            return matrix;
        }

        internal static string GetFirstLineFromFile(string filepath)
        {
            return File.ReadAllLines(filepath).First();
        }

        internal static (List<string>, List<(char,int)>) GetFoldingInstructions(string f)
        {
            var allLines = GetLinesFromFile(f);
            var points = new List<string>();
            var instr = new List<(char,int)>();

            var i = 0;
            while (allLines[i] != "")
            {
                points.Add(allLines[i]);
                i++;
            }

            i++;
            while(i < allLines.Count && allLines[i] != "")
            {
                //fold along x=655
                var line = allLines[i];
                var xOrY = line[11];
                var number = int.Parse(line.Substring(13));
                instr.Add((xOrY, number));
                i++;
            }
            return (points, instr);
        }
    }
}
