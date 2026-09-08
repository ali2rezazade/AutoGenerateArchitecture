// Generators/CqrsGenerator.cs
using System.IO;

public class CqrsGenerator : IArchitectureGenerator
{
    public string Name => "CQRS Architecture";
    public string Description => "تفکیک مدل‌های خواندن (Read/Query) و نوشتن (Write/Command)";

    public void Generate(string rootPath, string rootNamespace)
    {
        // Commands
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "Commands", "Handlers", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "Commands", "Models", "Sample.cs"), "");

        // Queries
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "Queries", "Handlers", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "Queries", "Models", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "Queries", "DTOs", "Sample.cs"), "");

        // Core & Infrastructure
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Domain", "Aggregates", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Domain", "Events", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Infrastructure", "EventStore", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Infrastructure", "ReadDatabase", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Infrastructure", "WriteDatabase", "Sample.cs"), "");
    }
}
