using System.Globalization;
using Caseify.Utility;

namespace Caseify.Commands;

[Command(PackageIds.UpperCase)]
internal sealed class UpperCase : BaseCommand<UpperCase>
{
    protected override async Task ExecuteAsync(OleMenuCmdEventArgs eventArgs)
    {
        await Transform.TextConverterAsync(CultureInfo.CurrentCulture.TextInfo.ToUpper);
    }
}