using Code.Common.Systems;
using Code.Infrastructures.Factories;

namespace Code.Common.Destruct
{
    public class ProcessDestuctedFeature : Feature
    {
        public ProcessDestuctedFeature(ISystemFactory systems)
        {
            Add(systems.Create<CleanupGameDestructedViewsSystem>());
            Add(systems.Create<CleanupGameDestructedSystem>());
        }
    }
}