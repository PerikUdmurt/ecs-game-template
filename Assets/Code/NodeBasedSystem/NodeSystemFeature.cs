using Code.Infrastructures.Factories;
using Code.NodeBasedSystem.Systems;

namespace Code.NodeBasedSystem
{
    public class NodeSystemFeature : Feature
    {
        public NodeSystemFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<AutoskipNodeSystem>());
        }
    }
}
