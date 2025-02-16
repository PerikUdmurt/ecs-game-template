using Code.Gameplay.Features.Camera.RTS.Systems;
using Code.Gameplay.Test.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Test
{
    [UsedImplicitly]
    public class GameplayTestFeature : Feature
    {
        public GameplayTestFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<DebugPlayerProgressSystem>());
            Add(systemFactory.Create<DebugCameraFeature>());
        }
    }
}