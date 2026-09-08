// Generators/HexagonalGenerator.cs
using ArchitectureScaffolder.Core;
using ArchitectureScaffolder.Helpers;
using System.IO;

namespace ArchitectureScaffolder.Generators
{
    public class HexagonalGenerator : IArchitectureGenerator
    {
        public string Name => "Hexagonal Architecture (Ports & Adapters)";
        public string Description => "ایزوله‌سازی هسته بیزینس از طریق Portها (Interfaces) و Adapterها (پیاده‌سازی‌ها)";

        public void Generate(string rootPath, string rootNamespace)
        {
            // Core
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Core", "Domain", "Models"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Core", "Ports", "Inbound"));  // Use Cases
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Core", "Ports", "Outbound")); // Repositories / External APIs
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Core", "Services"));

            // Adapters
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Adapters", "Primary", "WebControllers"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Adapters", "Primary", "Consumers"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Adapters", "Secondary", "Persistence"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Adapters", "Secondary", "ThirdPartyServices"));
        }
    }
}
