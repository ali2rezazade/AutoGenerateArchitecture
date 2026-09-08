// Generators/EventDrivenGenerator.cs
using ArchitectureScaffolder.Core;
using ArchitectureScaffolder.Helpers;
using System.IO;

namespace ArchitectureScaffolder.Generators
{
    public class EventDrivenGenerator : IArchitectureGenerator
    {
        public string Name => "Event-Driven Architecture";
        public string Description => "معماری مبتنی بر رخداد، شامل پیام‌رسانی (Producers, Consumers/Subscribers, Channels)";

        public void Generate(string rootPath, string rootNamespace)
        {
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Events"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Producers"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Consumers"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "EventBus", "Abstractions"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "EventBus", "RabbitMQ")); // or Kafka
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "StateStores"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Handlers"));
        }
    }
}
