using System.Collections.Generic;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Cursor.Systems
{
    [UsedImplicitly]
    public class SwitchCursorIconSystem : ReactiveSystem<GameEntity>
    {
        private readonly CursorConfig _cursorConfig;

        public SwitchCursorIconSystem(GameContext context, CursorConfig cursorConfig) : base(context)
        {
            _cursorConfig = cursorConfig;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CursorType);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCursorType 
                   && entity.isCursor;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                ECursorType cursorType = entity.cursorType.Value;
                if (_cursorConfig.cursors.TryGetValue(cursorType, out CursorConfig.CursorData cursorData))
                {
                    UnityEngine.Cursor.SetCursor(cursorData.cursorTexture, cursorData.cursorOffset, CursorMode.Auto);
                }
            }
        }
    }
}