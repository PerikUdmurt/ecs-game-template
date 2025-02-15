using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Cursor.Systems
{
    [UsedImplicitly]
    public class SwitchCursorTypeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cursorGroup;
        private readonly IGroup<GameEntity> _dragingGroup;
        
        public SwitchCursorTypeSystem(GameContext context)
        {
            _cursorGroup = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Cursor,
                GameMatcher.EntityUnderCursor));
            
            _dragingGroup = context.GetGroup(GameMatcher.Dragging);
        }
        
        public void Execute()
        {

            foreach (var cursor in _cursorGroup)
            {
                if (!cursor.hasCursorType)
                {
                    cursor.ReplaceCursorType(ECursorType.Default);
                }

                if (_dragingGroup.count > 0)
                {
                    SetCursorType(cursor, ECursorType.Dragging);
                    continue;
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
}