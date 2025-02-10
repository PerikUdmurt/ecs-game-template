using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Cursor.Systems
{
    [UsedImplicitly]
    public class InitializeCursorSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .With(c => c.isCursor = true);       
        }
    }
}