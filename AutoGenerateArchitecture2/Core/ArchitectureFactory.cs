using System.Collections.Generic;
public class ArchitectureFactory
{
    public List<IArchitectureGenerator> GetAvailableArchitectures()
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
