//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnimator;

    public static Entitas.IMatcher<GameEntity> Animator {
        get {
            if (_matcherAnimator == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Animator);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnimator = matcher;
            }

            return _matcherAnimator;
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
public partial class GameEntity {

    public Code.Common.Unity.Animator animator { get { return (Code.Common.Unity.Animator)GetComponent(GameComponentsLookup.Animator); } }
    public UnityEngine.Animator Animator { get { return animator.Value; } }
    public bool hasAnimator { get { return HasComponent(GameComponentsLookup.Animator); } }

    public GameEntity AddAnimator(UnityEngine.Animator newValue) {
        var index = GameComponentsLookup.Animator;
        var component = (Code.Common.Unity.Animator)CreateComponent(index, typeof(Code.Common.Unity.Animator));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAnimator(UnityEngine.Animator newValue) {
        var index = GameComponentsLookup.Animator;
        var component = (Code.Common.Unity.Animator)CreateComponent(index, typeof(Code.Common.Unity.Animator));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAnimator() {
        RemoveComponent(GameComponentsLookup.Animator);
        return this;
    }
}