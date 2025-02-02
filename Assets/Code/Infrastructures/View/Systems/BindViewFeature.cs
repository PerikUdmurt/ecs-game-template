using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Infrastructures.View.Systems
{
    [UsedImplicitly]
    public class BindViewFeature : Feature
    {
        public BindViewFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<BindViewFromPathEntitySystem>());
            Add(systemFactory.Create<BindViewFromPrefabEntitySystem>());
        }
    }
}