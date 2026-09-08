// Generators/OnionGenerator.cs
using ArchitectureScaffolder.Core;
using ArchitectureScaffolder.Helpers;
using System.IO;

namespace ArchitectureScaffolder.Generators
{
    public class OnionGenerator : IArchitectureGenerator
    {
        public string Name => "Onion Architecture";
        public string Description => "معماری پیازی با وابستگی به سمت داخل (Domain > Services > Infrastructure > UI)";

        public void Generate(string rootPath, string rootNamespace)
        {
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "DomainModel"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "DomainServices"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "ApplicationServices", "Interfaces"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "ApplicationServices", "Implementations"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Infrastructure", "Logging"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Infrastructure", "DataAccess"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Presentation", "Controllers"));
        }
    }
}
