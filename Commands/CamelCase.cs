using System.Linq;
using Caseify.Utility;

namespace Caseify.Commands;

[Command(PackageIds.CamelCase)]
internal sealed class CamelCase : BaseCommand<CamelCase>
{
    protected override async Task ExecuteAsync(OleMenuCmdEventArgs eventArgs)
    {
        var docView = await VS.Documents.GetActiveDocumentViewAsync().ConfigureAwait(false);
        var selection = docView?.TextView?.Selection.SelectedSpans.FirstOrDefault();

        if (selection.HasValue)
        {
            var selectedText = selection.GetValueOrDefault().GetText();
            var camelCased = ConvertToCamelCase(selectedText);
            docView.TextView.TextBuffer.Replace(selection.Value, camelCased);
        }
    }

    private static string ConvertToCamelCase(string selectedText)
    {
        var charInSelectedText = Transform.TextToChars(selectedText);
        var firstChar = charInSelectedText[0];
        var listOfCharInSelectedText = charInSelectedText.ToList();
        listOfCharInSelectedText.Remove(firstChar);
        var camelCasedText = firstChar.ToString().ToLower() + string.Join("", listOfCharInSelectedText.ToArray());
        return camelCasedText;
    }
}