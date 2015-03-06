using System.Text;

namespace Simplr.OpenGraph.Helpers
{
    public static class OGHelper
    {
        private static string AddDotInsteadOfUnderscore(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == '_')
                {
                    newText.Append('.');
                }
                else
                {
                    newText.Append(text[i]);
                }
            }
            return newText.ToString();
        }
    }
}
