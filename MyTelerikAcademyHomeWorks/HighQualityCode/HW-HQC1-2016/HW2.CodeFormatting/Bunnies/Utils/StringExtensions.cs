using System.Text;

namespace Bunnies
{
    public static class StringExtensions
    {
        public static string SplitToSeparateWordsByUppercaseLetter(this string inputString)
        {
            const char SingleSpace = ' ';

            var builder = new StringBuilder();

            foreach (var chr in inputString)
            {
                if (char.IsUpper(chr))
                {
                    builder.Append(SingleSpace);
                }

                builder.Append(chr);
            }

            return builder.ToString().Trim();
        }
    }
}
