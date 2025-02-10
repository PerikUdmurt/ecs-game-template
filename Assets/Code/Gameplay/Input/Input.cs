using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input
{
    [Game] public class Input : IComponent { }
    [Game] public class AxisInput : IComponent { public Vector2 Value; }
    [Game] public class MouseAxisInput : IComponent { public Vector2 Value; }
    [Game] public class MousePosition : IComponent { public Vector2 Value; }
    [Game] public class MouseWorldPosition : IComponent { public Vector3 Value; }
    [Game] public class LeftMouseButtonDownPressed : IComponent { }
    [Game] public class RightMouseButtonPressed : IComponent { }
    [Game] public class LeftMouseButtonDown : IComponent { }
    [Game] public class RightMouseButtonDown : IComponent { }
    [Game] public class LeftMouseButtonUp : IComponent { }
    [Game] public class RightMouseButtonUp : IComponent { }
    [Game] public class LeftMouseButtonHold : IComponent { }
    [Game] public class RightMouseButtonHold : IComponent { }
    [Game] public class SpaceButtonPressed : IComponent { }
    [Game] public class ScrollWheelAxis : IComponent {public float Value; }
}