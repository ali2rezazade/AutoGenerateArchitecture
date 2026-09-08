// Helpers/FileSystemHelper.cs
using System.IO;

namespace ArchitectureScaffolder.Helpers
{
    public static class FileSystemHelper
    {
        public static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void CreateFileWithContent(string filePath, string content)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, content.TrimStart());
            }
        }
    }
}
