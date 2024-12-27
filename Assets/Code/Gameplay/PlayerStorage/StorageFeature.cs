using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Progress
{
    [UsedImplicitly]
    public class StorageFeature : Feature
    {
        public StorageFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ProgressNodeBasedFeature>());
            //TODO: Add handling of negative values (maybe debt)
        }
    }
}