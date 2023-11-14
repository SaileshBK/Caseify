using System.Linq;

namespace Caseify.Utility
{
    public static class Transform
    {
        public delegate string TextConversionDelegate(string inputText);
        public static char[] TextToChars(string selectedText)
        {
            var charText = selectedText.ToCharArray();
            return !charText.Any() ? null : charText;
        }

        public static async Task TextConverterAsync(TextConversionDelegate textConversionDelegate)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync().ConfigureAwait(false);
            var selection = docView?.TextView?.Selection.SelectedSpans.FirstOrDefault();

            if (selection.HasValue)
            {
                var selectedText = selection.GetValueOrDefault().GetText();
                var transformedText = textConversionDelegate(selectedText);
                docView.TextView.TextBuffer.Replace(selection.Value, transformedText);
            }
        }
    }
}
