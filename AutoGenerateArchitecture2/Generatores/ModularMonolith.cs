using System.IO;
public class ModularMonolithGenerator : IArchitectureGenerator
{
    public string Name => "Modular Monolith";
    public string Description => "مونولیت ماژولار با مرزهای شفاف بیزینسی (Modules)";

    public void Generate(string rootPath, string rootNamespace)
    {
        // ماژول نمونه Users
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Modules", "Users", "Domain", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Modules", "Users", "Application", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Modules", "Users", "Infrastructure", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Modules", "Users", "Endpoints", "Sample.cs"), "");

        // ماژول نمونه Ordering
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Modules", "Ordering", "Domain", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Modules", "Ordering", "Application", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Modules", "Ordering", "Infrastructure", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Modules", "Ordering", "Endpoints", "Sample.cs"), "");

        // بخش مشترک
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "BuildingBlocks", "Domain", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "BuildingBlocks", "Infrastructure", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "BuildingBlocks", "EventBus", "Sample.cs"), "");
    }
}
