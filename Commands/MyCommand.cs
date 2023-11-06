using System.Globalization;
using System.Linq;

namespace Caseify.Commands
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync().ConfigureAwait(false);
            var selection = docView?.TextView?.Selection.SelectedSpans.FirstOrDefault();

            if (selection.HasValue)
            {
                var text = selection.GetValueOrDefault();
                var transformedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.GetText().ToLower());
                docView.TextView.TextBuffer.Replace(selection.Value, transformedText);
            }
        }
    }
}
