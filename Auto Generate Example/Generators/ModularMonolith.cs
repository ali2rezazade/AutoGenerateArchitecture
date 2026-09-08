// Generators/ModularMonolithGenerator.cs
using ArchitectureScaffolder.Core;
using ArchitectureScaffolder.Helpers;
using System.IO;

namespace ArchitectureScaffolder.Generators
{
    public class ModularMonolithGenerator : IArchitectureGenerator
    {
        public string Name => "Modular Monolith";
        public string Description => "مونولیت ماژولار با مرزهای شفاف بیزینسی (Modules)";

        public void Generate(string rootPath, string rootNamespace)
        {
            // ماژول نمونه Users
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Modules", "Users", "Domain"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Modules", "Users", "Application"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Modules", "Users", "Infrastructure"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Modules", "Users", "Endpoints"));

            // ماژول نمونه Ordering
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Modules", "Ordering", "Domain"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Modules", "Ordering", "Application"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Modules", "Ordering", "Infrastructure"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Modules", "Ordering", "Endpoints"));

            // بخش مشترک
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "BuildingBlocks", "Domain"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "BuildingBlocks", "Infrastructure"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "BuildingBlocks", "EventBus"));
        }
    }
}
