using System.Globalization;
using System.Linq;

namespace Caseify.Commands
{
    [Command(PackageIds.TitleCase)]
    internal sealed class TitleCase : BaseCommand<TitleCase>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync().ConfigureAwait(false);
            var selection = docView?.TextView?.Selection.SelectedSpans.FirstOrDefault();

            if (selection.HasValue)
            {
                var selectedText = selection.GetValueOrDefault().GetText();
                var transformedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(selectedText);
                docView.TextView.TextBuffer.Replace(selection.Value, transformedText);
            }
        }
    }
}
