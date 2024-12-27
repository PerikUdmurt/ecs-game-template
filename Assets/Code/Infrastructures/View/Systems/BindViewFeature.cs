using Code.Infrastructures.Factories;

namespace Code.Infrastructures.View.Systems
{
    public class BindViewFeature : Feature
    {
        public BindViewFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<BindViewFromPathEntitySystem>());
            Add(systemFactory.Create<BindViewFromPrefabEntitySystem>());
        }
    }
}