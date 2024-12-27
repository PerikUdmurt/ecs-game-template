using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class Direction : IComponent { public Vector3 Value; }
    [Game] public class Acceleration : IComponent { public float Value; }
    [Game] public class Moving : IComponent { public bool Value; }
    [Game] public class MoveTargetPosition : IComponent { public Vector3 Value; }
}
