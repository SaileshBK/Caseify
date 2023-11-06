using System.Globalization;
using System.Linq;

namespace Caseify
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync().ConfigureAwait(false);
            var selection = docView?.TextView.Selection.SelectedSpans.FirstOrDefault();

            if (selection.HasValue)
            {
                var text = selection.GetValueOrDefault();
                var caseifiedText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.GetText().ToLower());
                docView.TextView.TextBuffer.Replace(selection.Value, caseifiedText);
            }
        }
    }
}
