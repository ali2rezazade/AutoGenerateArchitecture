using System.IO;

public class HexagonalGenerator : IArchitectureGenerator
{
    public string Name => "Hexagonal Architecture";
    public string Description => "ایزوله‌سازی هسته بیزینس از طریق Portها (Interfaces) و Adapterها (پیاده‌سازی‌ها)";

    public void Generate(string rootPath, string rootNamespace)
    {
        // Core
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Core", "Domain", "Models", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Core", "Ports", "Inbound", "Sample.cs"), "");  // Use Cases
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Core", "Ports", "Outbound", "Sample.cs"), ""); // Repositories / External APIs
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Core", "Services", "Sample.cs"), "");

        // Adapters
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Adapters", "Primary", "WebControllers", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Adapters", "Primary", "Consumers", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Adapters", "Secondary", "Persistence", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Adapters", "Secondary", "ThirdPartyServices", "Sample.cs"), "");
    }
}
