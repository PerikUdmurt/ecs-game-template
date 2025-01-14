//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class NodeSystemMatcher {

    static Entitas.IMatcher<NodeSystemEntity> _matcherAddRating;

    public static Entitas.IMatcher<NodeSystemEntity> AddRating {
        get {
            if (_matcherAddRating == null) {
                var matcher = (Entitas.Matcher<NodeSystemEntity>)Entitas.Matcher<NodeSystemEntity>.AllOf(NodeSystemComponentsLookup.AddRating);
                matcher.componentNames = NodeSystemComponentsLookup.componentNames;
                _matcherAddRating = matcher;
            }

            return _matcherAddRating;
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

    public Code.NodeBasedSystem.ProgressNodeComponents.AddRatingComponent addRating { get { return (Code.NodeBasedSystem.ProgressNodeComponents.AddRatingComponent)GetComponent(NodeSystemComponentsLookup.AddRating); } }
    public float AddRating { get { return addRating.Value; } }
    public bool hasAddRating { get { return HasComponent(NodeSystemComponentsLookup.AddRating); } }

    public NodeSystemEntity AddAddRating(float newValue) {
        var index = NodeSystemComponentsLookup.AddRating;
        var component = (Code.NodeBasedSystem.ProgressNodeComponents.AddRatingComponent)CreateComponent(index, typeof(Code.NodeBasedSystem.ProgressNodeComponents.AddRatingComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public NodeSystemEntity ReplaceAddRating(float newValue) {
        var index = NodeSystemComponentsLookup.AddRating;
        var component = (Code.NodeBasedSystem.ProgressNodeComponents.AddRatingComponent)CreateComponent(index, typeof(Code.NodeBasedSystem.ProgressNodeComponents.AddRatingComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public NodeSystemEntity RemoveAddRating() {
        RemoveComponent(NodeSystemComponentsLookup.AddRating);
        return this;
    }
}
