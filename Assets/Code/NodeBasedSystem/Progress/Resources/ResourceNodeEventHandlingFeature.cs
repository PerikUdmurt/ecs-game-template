using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Progress
{
    [UsedImplicitly]
    public class ResourceNodeEventHandlingFeature : Feature
    {
        public ResourceNodeEventHandlingFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<AddBenzineEventSystem>());
            Add(systemFactory.Create<RemoveBenzineEventSystem>());
            Add(systemFactory.Create<AddVolitionEventSystem>());
            Add(systemFactory.Create<RemoveVolitionEventSystem>());
            Add(systemFactory.Create<AddRatingEventSystem>());
            Add(systemFactory.Create<RemoveRatingEventSystem>());
            Add(systemFactory.Create<AddMoneyEventSystem>());
            Add(systemFactory.Create<RemoveMoneyEventSystem>());
        }
    }
}