// UI/ArchitectureScaffolderCommand.cs
using ArchitectureScaffolder.UI;
using ArchitectureScaffolder.Core;
using ArchitectureScaffolder.Generators;
using Microsoft.VisualStudio.Shell;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace ArchitectureScaffolder.UI
{
    public class ArchitectureScaffolderCommand
    {
        // Command ID (must match the one registered in .vsixmanifest and commands plugin)
        private static readonly string CommandId = "AutoGenerate.Cmd.ScaffoldArchitecture";

        public async Task RegisterAsync(CancellationToken cancellationToken)
        {
            // 1. Retrieve the extension package instance.
            var extension = await Extension.GetExtensionAsync(ExtensionPoint.VsToolExtensionPoint.AutoGenerate);
            if (extension == null) return;

            // 2. Fetch the CommandRegistry service.
            var commandRegistry = extension.GetInteraction<CommandRegistryInteraction>();
            if (commandRegistry != null)
            {
                // 3. Register the command with the Shell.
                commandRegistry.RegisterCommand(
                    new CommandInvocation(CommandId, ExecuteAsync, this)
                );
            }
        }

        // ---------------------------------------------------------------------
        // Core execution: Open dialog + generate structure
        // ---------------------------------------------------------------------
        private async Task ExecuteAsync(CommandSource commandSource)
        {
            if (commandSource?.Source instanceof SelectionInteraction selection)
            {
                var selectedElement = selection.SelectedElement;
                if (selectedElement == null || !(selectedElement is FileSystemMapping mapping) || mapping.DriveType != FileSystemMapping.DriveTypeMask.Project)
                {
                    ShowMessage("هشدار", "لطفاً ابتدا پروژه مورد نظر را در Solution Explorer انتخاب کنید.");
                    return;
                }

                string projectDirectory = Path.GetDirectoryName(mapping.FullPath);

                var dialog = new ArchitectureDialog();
                if (dialog.ShowDialog() == true && dialog.SelectedGenerator != null)
                {
                    dialog.SelectedGenerator.Generate(projectDirectory);
                    ShowMessage("موفقیت", $"ساختار و فایل‌های پایه معماری '{dialog.SelectedGenerator.Name}' ساخته شد.");
                }
            }
        }

        private void ShowMessage(string title, string message)
        {
            Microsoft.VisualStudio.Shell.MessageBox.Show(title, message, Microsoft.VisualStudio.Shell.MessageBox.INFO);
        }
    }
}
