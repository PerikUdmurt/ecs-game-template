using System.Collections.Generic;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Cursor.Systems
{
    [UsedImplicitly]
    public class SwitchCursorTypeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cursorGroup;
        private readonly IGroup<GameEntity> _inputGroup;
        
        public SwitchCursorTypeSystem(GameContext context)
        {
            _cursorGroup = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Cursor,
                GameMatcher.EntityUnderCursor));
            
            _inputGroup = context.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (var input in _inputGroup)
            foreach (var cursor in _cursorGroup)
            {
                if (!cursor.hasCursorType)
                {
                    cursor.ReplaceCursorType(ECursorType.Default);
                }
                
                GameEntity entity = cursor.entityUnderCursor.Value;
                
                if (entity == null)
                {
                    SetCursorType(cursor, ECursorType.Default);
                    continue;
                }

                if (entity.isDragging)
                {
                    SetCursorType(cursor, ECursorType.Dragging);
                    continue;
                }
                
                if (entity.isDragable && !entity.isDragging)
                {
                    SetCursorType(cursor, ECursorType.Draggable);
                    continue;
                }
                
                SetCursorType(cursor, ECursorType.Default);
            }
        }

        private static void SetCursorType(GameEntity cursor, ECursorType cursorType)
        {
            if (cursor.cursorType.Value != cursorType)
                cursor.ReplaceCursorType(cursorType);
        }
    }
    
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