using Entitas;

namespace Code.Gameplay.Features.Cursor
{
    [Game] public class CursorComponent : IComponent { }
    [Game] public class EntityUnderCursor : IComponent { public GameEntity Value; }
    [Game] public class CursorType : IComponent { public ECursorType Value; }
}
