//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class NodeSystemMatcher {

    static Entitas.IMatcher<NodeSystemEntity> _matcherPlaying;

    public static Entitas.IMatcher<NodeSystemEntity> Playing {
        get {
            if (_matcherPlaying == null) {
                var matcher = (Entitas.Matcher<NodeSystemEntity>)Entitas.Matcher<NodeSystemEntity>.AllOf(NodeSystemComponentsLookup.Playing);
                matcher.componentNames = NodeSystemComponentsLookup.componentNames;
                _matcherPlaying = matcher;
            }

            return _matcherPlaying;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class NodeSystemEntity {

    static readonly NodeBasedSystem.Nodes.PlayingComponent playingComponent = new NodeBasedSystem.Nodes.PlayingComponent();

    public bool isPlaying {
        get { return HasComponent(NodeSystemComponentsLookup.Playing); }
        set {
            if (value != isPlaying) {
                var index = NodeSystemComponentsLookup.Playing;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : playingComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}