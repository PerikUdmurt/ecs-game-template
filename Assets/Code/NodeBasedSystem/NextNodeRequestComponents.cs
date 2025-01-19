using Entitas;

namespace Code.NodeBasedSystem
{
    [NodeSystem] public class NextNodeRequestComponent : IComponent { public string Value; }
    [NodeSystem] public class NextNodeRequestGraphIdComponent : IComponent { public string Value; }
}