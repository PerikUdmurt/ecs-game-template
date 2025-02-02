using Entitas;

namespace Code.Gameplay.Features.Dragable
{
    [Game] public class DragableComponent : IComponent { }
    [Game] public class DraggingComponent : IComponent { } 
    [Game] public class DragLerpComponent : IComponent { public float Value; }
    [Game] public class StartDraggingComponent : IComponent { }
    [Game] public class DroppedComponent : IComponent { }
}
