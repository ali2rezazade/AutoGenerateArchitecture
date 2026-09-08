using System.IO;
public class CleanArchitectureGenerator : IArchitectureGenerator
{
    public string Name => "Clean Architecture";
    public string Description => "تفکیک کامل لایه‌های Domain, Application, Infrastructure و Presentation";

    public void Generate(string rootPath, string rootNamespace)
    {
        // Core - Domain
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Domain", "Entities","Sample.cs"),"");
        FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Domain", "Common"));
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Domain", "Enums", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Domain", "Exceptions", "Sample.cs"), "");

        // Core - Application
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "Common", "Interfaces", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "Common", "Models", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "Common", "Behaviors", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "Features", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Application", "Services", "Sample.cs"), "");

        // Infrastructure
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Infrastructure", "Persistence", "Contexts", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Infrastructure", "Persistence", "Repositories", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Infrastructure", "Services", "Sample.cs"), "");

        // Presentation
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Presentation", "Controllers", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Presentation", "Middlewares","Sample.cs"),"");

        // Sample Base Entity
        FileSystemHelper.CreateFileWithContent(
            Path.Combine(rootPath, "Domain", "Common", "BaseEntity.cs"),
            $@"
    public abstract class BaseEntity
    {{
        public int Id {{ get; set; }}
        public DateTime CreatedAt {{ get; set; }} = DateTime.UtcNow;
    }}");
    }
}
