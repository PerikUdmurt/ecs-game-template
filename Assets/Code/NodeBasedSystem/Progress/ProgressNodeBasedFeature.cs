using Code.Infrastructures.Factories;
using Code.NodeBasedSystem.Progress.Tokens;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Progress
{
    [UsedImplicitly]
    public class ProgressNodeBasedFeature : Feature
    {
        public ProgressNodeBasedFeature(ISystemFactory factory)
        {
            Add(factory.Create<ResourceNodeEventHandlingFeature>());
            Add(factory.Create<TokenNodeEventHandlingFeature>());
        }
    }
}
