using System.Linq;

namespace Caseify.Utility
{
    public static class Transform
    {
        public static char[] TextToChars(string selectedText)
        {
            var charText = selectedText.ToCharArray();
            if (!charText.Any())
            {
                return null;
            }

            return charText;
        }
    }
}
