// Generators/CqrsGenerator.cs
using ArchitectureScaffolder.Core;
using ArchitectureScaffolder.Helpers;
using System.IO;

namespace ArchitectureScaffolder.Generators
{
    public class CqrsGenerator : IArchitectureGenerator
    {
        public string Name => "CQRS Architecture";
        public string Description => "تفکیک مدل‌های خواندن (Read/Query) و نوشتن (Write/Command)";

        public void Generate(string rootPath, string rootNamespace)
        {
            // Commands
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "Commands", "Handlers"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "Commands", "Models"));

            // Queries
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "Queries", "Handlers"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "Queries", "Models"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "Queries", "DTOs"));

            // Core & Infrastructure
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Aggregates"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Events"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Infrastructure", "EventStore"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Infrastructure", "ReadDatabase"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Infrastructure", "WriteDatabase"));
        }
    }
}
