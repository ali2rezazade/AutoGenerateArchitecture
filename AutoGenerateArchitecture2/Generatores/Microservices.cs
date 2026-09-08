using System.IO;

public class MicroserviceGenerator : IArchitectureGenerator
{
    public string Name => "Microservices";
    public string Description => "ساختار استاندارد برای تک مایکروسرویس به همراه Eventها، Protos و Health Checks";

    public void Generate(string rootPath, string rootNamespace)
    {
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "API", "Controllers", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "API", "Middlewares", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Core", "Entities", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Core", "Services", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Data", "Context", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Protos", "Sample.cs"), ""); // gRPC
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "IntegrationEvents", "Events", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "IntegrationEvents", "Handlers", "Sample.cs"), "");
    }
}
