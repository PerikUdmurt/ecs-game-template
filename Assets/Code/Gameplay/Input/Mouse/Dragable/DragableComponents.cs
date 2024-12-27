using Entitas;

namespace Code.Gameplay.Features.Dragable
{
    [Game] public class DragableComponent : IComponent { public bool Value; }
    [Game] public class DraggingComponent : IComponent { } 
    [Game] public class DragLerpComponent : IComponent { public float Value; }
}
