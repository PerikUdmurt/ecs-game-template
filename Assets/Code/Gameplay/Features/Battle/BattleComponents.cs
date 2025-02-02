using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Battle
{
    [Game] public class BattleActionRequestComponent : IComponent { }
    [Game] public class ExecutingComponent : IComponent { }
    [Game] public class ExecutedComponent : IComponent { }
    [Game] public class ActionSourceIdComponent : IComponent { public int Value; }
    [Game] public class ActionTargetIdComponent : IComponent { public int Value; }
}
