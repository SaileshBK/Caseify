namespace Caseify.Commands;

[Command(PackageIds.Help)]
internal sealed class Help : BaseCommand<Help>
{
    protected override Task ExecuteAsync(OleMenuCmdEventArgs e)
    {
        System.Diagnostics.Process.Start("https://github.com/SaileshBK/Caseify");
        return Task.CompletedTask;
    }
}