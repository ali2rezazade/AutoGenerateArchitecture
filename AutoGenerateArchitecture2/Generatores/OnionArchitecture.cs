using System.IO;

public class OnionGenerator : IArchitectureGenerator
{
    public string Name => "Onion Architecture";
    public string Description => "معماری پیازی با وابستگی به سمت داخل (Domain > Services > Infrastructure > UI)";

    public void Generate(string rootPath, string rootNamespace)
    {
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "DomainModel", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "DomainServices", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "ApplicationServices", "Interfaces", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "ApplicationServices", "Implementations", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Infrastructure", "Logging", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Infrastructure", "DataAccess", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Presentation", "Controllers", "Sample.cs"), "");
    }
}
