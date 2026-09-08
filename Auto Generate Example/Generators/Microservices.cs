// Generators/MicroserviceGenerator.cs
using ArchitectureScaffolder.Core;
using ArchitectureScaffolder.Helpers;
using System.IO;

namespace ArchitectureScaffolder.Generators
{
    public class MicroserviceGenerator : IArchitectureGenerator
    {
        public string Name => "Microservices Service Template";
        public string Description => "ساختار استاندارد برای تک مایکروسرویس به همراه Eventها، Protos و Health Checks";

        public void Generate(string rootPath, string rootNamespace)
        {
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "API", "Controllers"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "API", "Middlewares"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Core", "Entities"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Core", "Services"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Data", "Context"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Protos")); // gRPC
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "IntegrationEvents", "Events"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "IntegrationEvents", "Handlers"));
        }
    }
}
