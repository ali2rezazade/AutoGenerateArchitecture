// Generators/VerticalSliceGenerator.cs
using ArchitectureScaffolder.Core;
using ArchitectureScaffolder.Helpers;
using System.IO;

namespace ArchitectureScaffolder.Generators
{
    public class VerticalSliceGenerator : IArchitectureGenerator
    {
        public string Name => "Vertical Slice Architecture";
        public string Description => "تمرکز بر روی Featureها و برش‌های عمودی به جای لایه‌بندی افقی";

        public void Generate(string rootPath, string rootNamespace)
        {
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Features", "SampleFeature", "Commands"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Features", "SampleFeature", "Queries"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Common", "Behaviors"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Common", "Data"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Common", "Exceptions"));
            FileSystemHelper.CreateFolder(Path.Combine(rootPath, "Common", "Extensions"));

            FileSystemHelper.CreateFileWithContent(
                Path.Combine(rootPath, "Features", "SampleFeature", "SampleEndpoint.cs"),
                $@"namespace {rootNamespace}.Features.SampleFeature
{{
    // FastEndpoints or Minimal API Endpoint Definition
}}");
        }
    }
}
