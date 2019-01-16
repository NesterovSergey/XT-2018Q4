using System.Text.RegularExpressions;

namespace Epam.Task8.NumberValidator
{
    public static class RegularExpression
    {
        private static readonly string UsualRegString = @"^(\s+)?-?\d+(\.\d+)?(\s+)?$"; 
        private static readonly string ScientificRegString = @"^(\s+)?-?\d+(\.\d+)?e-?\d+(\s+)?$";
        private static Regex usualNumberRegex;
        private static Regex scientificNumberRegex;

        static RegularExpression()
        {
            usualNumberRegex = new Regex(UsualRegString);
            scientificNumberRegex = new Regex(ScientificRegString);
        }

        public static bool ScientificCheck(string line)
        {
            return scientificNumberRegex.IsMatch(line);
        }

        public static bool UsualCheck(string line)
        {
            return usualNumberRegex.IsMatch(line);
        }
    }
}
