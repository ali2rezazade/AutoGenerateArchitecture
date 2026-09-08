// Generators/CleanArchitectureGenerator.cs
using ArchitectureScaffolder.Core;
using ArchitectureScaffolder.Helpers;
using System.IO;

namespace ArchitectureScaffolder.Generators
{
    public class CleanArchitectureGenerator : IArchitectureGenerator
    {
        public string Name => "Clean Architecture";
        public string Description => "تفکیک کامل لایه‌های Domain, Application, Infrastructure و Presentation";

        public void Generate(string rootPath, string rootNamespace)
        {
            // Core - Domain
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Entities"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Common"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Enums"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Exceptions"));

            // Core - Application
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "Common", "Interfaces"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "Common", "Models"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "Common", "Behaviors"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "Features"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "Services"));

            // Infrastructure
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Infrastructure", "Persistence", "Contexts"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Infrastructure", "Persistence", "Repositories"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Infrastructure", "Services"));

            // Presentation
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Presentation", "Controllers"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Presentation", "Middlewares"));

            // Sample Base Entity
            FileSystemHelper.CreateFileWithContent(
                Path.Combine(rootPath, "Domain", "Common", "BaseEntity.cs"),
                $@"namespace {rootNamespace}.Domain.Common
{{
    public abstract class BaseEntity
    {{
        public int Id {{ get; set; }}
        public DateTime CreatedAt {{ get; set; }} = DateTime.UtcNow;
    }}
}}");
        }
    }
}
