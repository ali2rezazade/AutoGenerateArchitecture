// Generators/NTierGenerator.cs
using ArchitectureScaffolder.Core;
using ArchitectureScaffolder.Helpers;
using System.IO;

namespace ArchitectureScaffolder.Generators
{
    public class NTierGenerator : IArchitectureGenerator
    {
        public string Name => "N-Tier (Layered Architecture)";
        public string Description => "ساختار لایه‌ای سنتی (Presentation, Business Logic Layer, Data Access Layer)";

        public void Generate(string rootPath, string rootNamespace)
        {
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Presentation", "Controllers"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Presentation", "ViewModels"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "BLL", "Services"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "BLL", "Interfaces"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "DAL", "Repositories"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "DAL", "Data"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "DTOs"));
        }
    }
}
