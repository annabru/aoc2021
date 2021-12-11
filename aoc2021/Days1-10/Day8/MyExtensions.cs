namespace aoc2021.Day8
{
    public static class MyExtensions
    {
        public static bool ContainsAll(this String str, String input)
        {
            if(input == null) return false;
            foreach(char c in input)
            {
                if (!str.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static string RemoveAll(this String str, String input)
        {
            if (input == null || input.Length < 1) return str;
            var copy = new String(str).ToString();
            foreach (var c in input)
            {
                if (copy.Contains(c))
                {
                    copy = copy.Replace(""+c, "");
                }
            }
            return copy;
        }
    }
}
