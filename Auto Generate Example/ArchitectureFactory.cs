// Core/ArchitectureFactory.cs
using System.Collections.Generic;
using ArchitectureScaffolder.Generators;

namespace ArchitectureScaffolder.Core
{
    public static class ArchitectureFactory
    {
        public static IReadOnlyList<IArchitectureGenerator> GetAvailableArchitectures()
        {
            return new List<IArchitectureGenerator>
            {
                new CleanArchitectureGenerator(),
                new VerticalSliceGenerator(),
                new HexagonalGenerator(),
                new OnionGenerator(),
                new CqrsGenerator(),
                new DddGenerator(),
                new ModularMonolithGenerator(),
                new MicroserviceGenerator(),
                new NTierGenerator(),
                new EventDrivenGenerator()
            };
        }
    }
}
