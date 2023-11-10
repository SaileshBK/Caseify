﻿using System.Globalization;
using System.Linq;

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
            var transformedText = CultureInfo.CurrentCulture.TextInfo.ToLower(selectedText);
            docView.TextView.TextBuffer.Replace(selection.Value, transformedText);
        }
    }
}