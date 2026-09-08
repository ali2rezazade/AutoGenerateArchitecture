using System.IO;
    public class VerticalSliceGenerator : IArchitectureGenerator
    {
        public string Name => "Vertical Slice Architecture";
        public string Description => "تمرکز بر روی Featureها و برش‌های عمودی به جای لایه‌بندی افقی";

        public void Generate(string rootPath, string rootNamespace)
        {
            FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Features", "SampleFeature", "Commands", "Sample.cs"), "");
            FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Features", "SampleFeature", "Queries", "Sample.cs"), "");
            FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Common", "Behaviors", "Sample.cs"), "");
            FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Common", "Data", "Sample.cs"), "");
            FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Common", "Exceptions", "Sample.cs"), "");
            FileSystemHelper.CreateFileWithContent(Path.Combine(rootPath, "Common", "Extensions", "Sample.cs"), "");
        }
    }
