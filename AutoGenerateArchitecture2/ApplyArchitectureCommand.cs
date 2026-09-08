using ArchitectureScaffolder.UI;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.IO;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Task = System.Threading.Tasks.Task;

namespace AutoGenerateArchitecture2
{
    internal sealed class ApplyArchitectureCommand
    {
        public const int CommandId = 0x0100;
        public static readonly Guid CommandSet = new Guid("58feb0b8-b4ec-4845-ac7e-5baabfb0831e");

        private readonly AsyncPackage package;

        private ApplyArchitectureCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(async (s, e) => await ExecuteAsync(s, e), menuCommandID);
            commandService.AddCommand(menuItem);
        }

        public static ApplyArchitectureCommand Instance { get; private set; }

        public static async Task InitializeAsync(AsyncPackage package)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService == null) return;
            Instance = new ApplyArchitectureCommand(package, commandService);
        }

        private async Task ExecuteAsync(object sender, EventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var dlg = new ArchitectureDialog();
            bool? result = dlg.ShowDialog();

            if (result != true)
                return; // کاربر Cancel زده
            if (dlg.SelectedGenerator == null)
            {
                ShowInfo("لطفا در ابتدا یک معماری انتخاب نمایید");
                return;
            }
            string selected = dlg.SelectedGenerator.Name ?? "Unknown";

            var project = await GetSelectedProjectAsync();
            if (project == null)
            {
                ShowInfo("لطفاً ابتدا یک پروژه را در Solution Explorer انتخاب کنید.");
                return;
            }

            string projectFile = project.FullName; // ...\MyApp\MyApp.csproj
            string projectDir = System.IO.Path.GetDirectoryName(projectFile)!;
            if (string.IsNullOrWhiteSpace(projectDir))
                throw new InvalidOperationException("مسیر پروژه قابل تشخیص نیست.");
            try
            {
                switch (selected.ToLower())
                {
                    case "clean architecture":
                        new CleanArchitectureGenerator().Generate(projectDir, project.Name);
                        break;
                    case "cqrs architecture":
                        new CqrsGenerator().Generate(projectDir, project.Name);
                        break;
                    case "ddd architecture":
                        new DddGenerator().Generate(projectDir, project.Name);
                        break;
                    case "ed architecture":
                        new EventDrivenGenerator().Generate(projectDir, project.Name);
                        break;
                    case "hexagonal architecture":
                        new HexagonalGenerator().Generate(projectDir, project.Name);
                        break;
                    case "microservices":
                        new MicroserviceGenerator().Generate(projectDir, project.Name);
                        break;
                    case "modular monolith":
                        new ModularMonolithGenerator().Generate(projectDir, project.Name);
                        break;
                    case "n-tier":
                        new NTierGenerator().Generate(projectDir, project.Name);
                        break;
                    case "onion architecture":
                        new OnionGenerator().Generate(projectDir, project.Name);
                        break;
                    case "vertical slice architecture":
                        new VerticalSliceGenerator().Generate(projectDir, project.Name);
                        break;
                }

                project.Save();
            }
            catch (Exception ex)
            {
                ShowError("خطا در ایجاد ساختار: " + ex.Message);
            }
            //await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            //try
            //{
            //    var project = await GetSelectedProjectAsync();
            //    if (project == null)
            //    {
            //        ShowInfo("لطفاً ابتدا یک پروژه را در Solution Explorer انتخاب کنید.");
            //        return;
            //    }

            //    await ApplyCleanArchitectureAsync(project);
            //    project.Save();

            //    ShowInfo("ساختار Clean Architecture با موفقیت ایجاد شد.");
            //}
            //catch (Exception ex)
            //{
            //    ShowError("خطا در ایجاد ساختار: " + ex.Message);
            //}
        }

        private async Task<Project> GetSelectedProjectAsync()
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var dte = await package.GetServiceAsync(typeof(SDTE)) as DTE2;
            if (dte?.SelectedItems == null || dte.SelectedItems.Count == 0)
                return null;

            SelectedItem item = dte.SelectedItems.Item(1);
            if (item.Project != null)
                return item.Project;

            if (item.ProjectItem?.ContainingProject != null)
                return item.ProjectItem.ContainingProject;

            return null;
        }

        private async Task ApplyCleanArchitectureAsync(Project project)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            string projectFile = project.FullName; // ...\MyApp\MyApp.csproj
            string projectDir = System.IO.Path.GetDirectoryName(projectFile)!;
            if (string.IsNullOrWhiteSpace(projectDir))
                throw new InvalidOperationException("مسیر پروژه قابل تشخیص نیست.");

            // فولدرها
            EnsureDirectory(Path.Combine(projectDir, "Domain"));
            EnsureDirectory(Path.Combine(projectDir, "Domain", "Entities"));
            EnsureDirectory(Path.Combine(projectDir, "Domain", "ValueObjects"));
            EnsureDirectory(Path.Combine(projectDir, "Domain", "Interfaces"));

            EnsureDirectory(Path.Combine(projectDir, "Application"));
            EnsureDirectory(Path.Combine(projectDir, "Application", "DTOs"));
            EnsureDirectory(Path.Combine(projectDir, "Application", "Interfaces"));
            EnsureDirectory(Path.Combine(projectDir, "Application", "UseCases"));

            EnsureDirectory(Path.Combine(projectDir, "Infrastructure"));
            EnsureDirectory(Path.Combine(projectDir, "Infrastructure", "Persistence"));
            EnsureDirectory(Path.Combine(projectDir, "Infrastructure", "Repositories"));

            EnsureDirectory(Path.Combine(projectDir, "Presentation"));
            EnsureDirectory(Path.Combine(projectDir, "Presentation", "Controllers"));
            EnsureDirectory(Path.Combine(projectDir, "Presentation", "ViewModels"));

            // فایل نمونه
            string baseEntityPath = Path.Combine(projectDir, "Domain", "Entities", "BaseEntity.cs");
            if (!File.Exists(baseEntityPath))
            {
                var content =
@"namespace Domain.Entities;
public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}";
                File.WriteAllText(baseEntityPath, content);
            }

            // رفرش پروژه تا آیتم‌ها نمایش داده شوند
            //project.ProjectItems?.AddFromDirectory(projectDir);
        }

        private static void EnsureDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private void ShowInfo(string message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            VsShellUtilities.ShowMessageBox(
                package,
                message,
                "Apply Architecture",
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }

        private void ShowError(string message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            VsShellUtilities.ShowMessageBox(
                package,
                message,
                "Apply Architecture - Error",
                OLEMSGICON.OLEMSGICON_CRITICAL,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }
    }
}
