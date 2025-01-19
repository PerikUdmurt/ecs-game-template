using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Progress.Tokens
{
    [UsedImplicitly]
    public class TokenNodeEventHandlingFeature : Feature
    {
        public TokenNodeEventHandlingFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<AddProgressTokenNodeEventSystem>());
            Add(systemFactory.Create<RemoveProgressTokenNodeEventSystem>());
        }
    }
}