using Microsoft.VisualStudio.Shell;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using ArchitectureScaffolder.UI;
using ArchitectureScaffolder.Core;

namespace Auto_Generate_Example
{
    /// <summary>
    /// Main entry point of the VS Extension Package.
    /// Registers the Scaffold Architecture command at startup.
    /// </summary>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(Auto_Generate_ExamplePackage.PackageGuidString)]
    public sealed class Auto_Generate_ExamplePackage : AsyncPackage
    {
        /// <summary>
        /// Auto_Generate_ExamplePackage GUID string.
        /// </summary>
        public const string PackageGuidString = "9d14d3f0-8595-4994-a1ac-3e76435462cd";

        #region Package Members

        /// <summary>
        /// Runs right after the package is sited. 
        /// Registers the Scaffold command into the Shell.
        /// </summary>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // Switch to the UI thread because command registration should occur on it.
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            // Load the package's own UI resources (mandatory since this package uses WPF via managed resources).
            await this.LoadJSON();

            // Register the main command.
            var command = new ArchitectureScaffolderCommand();
            await command.RegisterAsync(cancellationToken);
        }

        /// <summary>
        /// In case the extension is installed for all users, we must provide a valid path
        /// to the resources. Since we're using ManagedResources this method is fine.
        /// </summary>
        private async Task LoadJSON()
        {
            // Placeholder: if the package has bundled resources (e.g., dialog styles),
            // they can be loaded here. For WPF inline dialogs, nothing extra is required.
            //await this.GetPackageService(...);
            await Task.CompletedTask;
        }

        #endregion
    }
}
