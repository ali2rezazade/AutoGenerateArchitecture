// Generators/DddGenerator.cs
using ArchitectureScaffolder.Core;
using ArchitectureScaffolder.Helpers;
using System.IO;

namespace ArchitectureScaffolder.Generators
{
    public class DddGenerator : IArchitectureGenerator
    {
        public string Name => "Domain-Driven Design (DDD)";
        public string Description => "طراحی دامنه محور کامل با تفکیک Aggregateها، Value Objectها و Domain Eventها";

        public void Generate(string rootPath, string rootNamespace)
        {
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Aggregates"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "ValueObjects"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Events"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Repositories"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Specifications"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Exceptions"));

            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "Contracts"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Application", "UseCases"));

            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Infrastructure", "Persistence", "Configurations"));
        }
    }
}
