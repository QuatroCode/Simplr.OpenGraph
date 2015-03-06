using System.Text;

namespace Simplr.OpenGraph.Helpers
{
    public static class OGHelper
    {
        private static string AddSymbolBeforeUpperCase(this string text, char symbol)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != '.')
                {
                    newText.Append(symbol);
                }
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
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
