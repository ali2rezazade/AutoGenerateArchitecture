// Core/IArchitectureGenerator.cs
using System.Threading.Tasks;
public interface IArchitectureGenerator
{
    string Name { get; }
    string Description { get; }
    void Generate(string rootPath, string rootNamespace);
}
