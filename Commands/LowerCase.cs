using System.Globalization;
using Caseify.Utility;

namespace Caseify.Commands;

[Command(PackageIds.LowerCase)]
internal sealed class LowerCase : BaseCommand<LowerCase>
{
    protected override async Task ExecuteAsync(OleMenuCmdEventArgs eventArgs)
    {
        await Transform.TextConverterAsync(CultureInfo.CurrentCulture.TextInfo.ToLower);
    }
}