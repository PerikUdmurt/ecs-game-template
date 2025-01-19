using Code.Infrastructures.Factories;
using Code.NodeBasedSystem.Systems;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem
{
    [UsedImplicitly]
    public class NodeSystemFeature : Feature
    {
        public NodeSystemFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<AutoskipNodeSystem>());
            Add(systemFactory.Create<PlayNextNodeGraphSystem>());
        }
    }
}
