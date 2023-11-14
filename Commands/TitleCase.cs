using System.Globalization;
using Caseify.Utility;

namespace Caseify.Commands
{
    [Command(PackageIds.TitleCase)]
    internal sealed class TitleCase : BaseCommand<TitleCase>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await Transform.TextConverterAsync(CultureInfo.CurrentCulture.TextInfo.ToTitleCase);
        }
    }
}
