using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;

namespace VsAiHelper
{
    internal sealed class CopyCodeContextInfoCommand
    {
        public const int CommandId = 0x0100;
        public static readonly Guid CommandSet = new Guid("f335c497-3340-4d3e-8128-1f13a72a7583");

        private readonly AsyncPackage package;

        private CopyCodeContextInfoCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        public static CopyCodeContextInfoCommand Instance { get; private set; }

        private IAsyncServiceProvider ServiceProvider => package;

        public static async Task InitializeAsync(AsyncPackage package)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            var commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new CopyCodeContextInfoCommand(package, commandService);
        }

        private void Execute(object sender, EventArgs e)
        {
            _ = ThreadHelper.JoinableTaskFactory.RunAsync(async delegate
            {
                try
                {
                    await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                    var dte = await ServiceProvider.GetServiceAsync(typeof(DTE)) as DTE2;
                    if (dte == null || dte.ActiveDocument == null)
                        return;

                    var textDocument = dte.ActiveDocument.Object("TextDocument") as TextDocument;
                    if (textDocument == null) return;

                    var selection = textDocument.Selection;
                    var filePath = dte.ActiveDocument.FullName;
                    var startLine = selection.TopPoint.Line;
                    var endLine = selection.BottomPoint.Line;

                    var className = "UnknownClass";
                    var methodName = "UnknownMethod";

                    var codeElement = selection.TopPoint.get_CodeElement(vsCMElement.vsCMElementClass);
                    if (codeElement != null) className = codeElement.Name;

                    var functionElement = selection.TopPoint.get_CodeElement(vsCMElement.vsCMElementFunction);
                    if (functionElement != null) methodName = functionElement.Name;

                    var result =
                        $"File: {filePath}\nClass: {className}\nMethod: {methodName}\nLines: {startLine} - {endLine}";

                    Clipboard.SetText(result);
                }
                catch (Exception)
                {
                    // Log the exception or show a message to the user, for now just swallow it
                }
            });
        }
    }
}