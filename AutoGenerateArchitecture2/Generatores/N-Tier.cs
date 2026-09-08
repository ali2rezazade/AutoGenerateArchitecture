using System.IO;

public class NTierGenerator : IArchitectureGenerator
{
    public string Name => "N-Tier";
    public string Description => "ساختار لایه‌ای سنتی (Presentation, Business Logic Layer, Data Access Layer)";

    public void Generate(string rootPath, string rootNamespace)
    {
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Presentation", "Controllers", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Presentation", "ViewModels", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "BLL", "Services", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "BLL", "Interfaces", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "DAL", "Repositories", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "DAL", "Data", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "DTOs", "Sample.cs"), "");
    }
}
