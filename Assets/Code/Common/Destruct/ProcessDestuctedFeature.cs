using Code.Common.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Common.Destruct
{
    [UsedImplicitly]
    public class ProcessDestuctedFeature : Feature
    {
        public ProcessDestuctedFeature(ISystemFactory systems)
        {
            Add(systems.Create<CleanupGameDestructedViewsSystem>());
            Add(systems.Create<CleanupGameDestructedSystem>());
        }
    }
}