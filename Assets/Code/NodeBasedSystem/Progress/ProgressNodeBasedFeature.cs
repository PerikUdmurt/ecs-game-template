using Code.Infrastructures.Factories;

namespace Code.NodeBasedSystem.Progress
{
    public class ProgressNodeBasedFeature : Feature
    {
        public ProgressNodeBasedFeature(ISystemFactory factory)
        {
            Add(factory.Create<ResourceNodeEventHandlingFeature>());
        }
    }
}
