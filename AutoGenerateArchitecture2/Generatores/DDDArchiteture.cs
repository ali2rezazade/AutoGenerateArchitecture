using System.IO;

public class DddGenerator : IArchitectureGenerator
{
    public string Name => "DDD Architecture";
    public string Description => "طراحی دامنه محور کامل با تفکیک Aggregateها، Value Objectها و Domain Eventها";

    public void Generate(string rootPath, string rootNamespace)
    {
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Domain", "Aggregates", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Domain", "ValueObjects", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Domain", "Events", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Domain", "Repositories", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Domain", "Specifications", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Domain", "Exceptions", "Sample.cs"), "");

        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "Contracts", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "UseCases", "Sample.cs"), "");

        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Infrastructure", "Persistence", "Configurations", "Sample.cs"), "");
    }
}
