//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ProgressMatcher {

    static Entitas.IMatcher<ProgressEntity> _matcherMaxRating;

    public static Entitas.IMatcher<ProgressEntity> MaxRating {
        get {
            if (_matcherMaxRating == null) {
                var matcher = (Entitas.Matcher<ProgressEntity>)Entitas.Matcher<ProgressEntity>.AllOf(ProgressComponentsLookup.MaxRating);
                matcher.componentNames = ProgressComponentsLookup.componentNames;
                _matcherMaxRating = matcher;
            }

            return _matcherMaxRating;
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
public partial class ProgressEntity {

    public Code.Progress.PlayerStorage.MaxRatingComponent maxRating { get { return (Code.Progress.PlayerStorage.MaxRatingComponent)GetComponent(ProgressComponentsLookup.MaxRating); } }
    public float MaxRating { get { return maxRating.Value; } }
    public bool hasMaxRating { get { return HasComponent(ProgressComponentsLookup.MaxRating); } }

    public ProgressEntity AddMaxRating(float newValue) {
        var index = ProgressComponentsLookup.MaxRating;
        var component = (Code.Progress.PlayerStorage.MaxRatingComponent)CreateComponent(index, typeof(Code.Progress.PlayerStorage.MaxRatingComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public ProgressEntity ReplaceMaxRating(float newValue) {
        var index = ProgressComponentsLookup.MaxRating;
        var component = (Code.Progress.PlayerStorage.MaxRatingComponent)CreateComponent(index, typeof(Code.Progress.PlayerStorage.MaxRatingComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public ProgressEntity RemoveMaxRating() {
        RemoveComponent(ProgressComponentsLookup.MaxRating);
        return this;
    }
}