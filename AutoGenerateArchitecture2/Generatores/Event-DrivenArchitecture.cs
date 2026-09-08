using System.IO;

public class EventDrivenGenerator : IArchitectureGenerator
{
    public string Name => "ED Architecture";
    public string Description => "معماری مبتنی بر رخداد، شامل پیام‌رسانی (Producers, Consumers/Subscribers, Channels)";

    public void Generate(string rootPath, string rootNamespace)
    {
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Events", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Producers", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Consumers", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "EventBus", "Abstractions", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "EventBus", "RabbitMQ", "Sample.cs"), ""); // or Kafka
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "StateStores", "Sample.cs"), "");
        FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Handlers", "Sample.cs"), "");
    }
}
