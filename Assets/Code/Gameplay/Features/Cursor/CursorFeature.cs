using Code.Gameplay.Features.Cursor.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Cursor
{
    [UsedImplicitly]
    public class CursorFeature : Feature
    {
        public CursorFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializeCursorSystem>());
            Add(systemFactory.Create<DetectEntityUnderCursorSystem>());
            Add(systemFactory.Create<SwitchCursorTypeSystem>());
            Add(systemFactory.Create<SwitchCursorIconSystem>());
        }
    }
}