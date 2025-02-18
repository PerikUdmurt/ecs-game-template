//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMoving;

    public static Entitas.IMatcher<GameEntity> Moving {
        get {
            if (_matcherMoving == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Moving);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMoving = matcher;
            }

            return _matcherMoving;
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

    public Code.Gameplay.Features.Movement.Moving moving { get { return (Code.Gameplay.Features.Movement.Moving)GetComponent(GameComponentsLookup.Moving); } }
    public bool Moving { get { return moving.Value; } }
    public bool hasMoving { get { return HasComponent(GameComponentsLookup.Moving); } }

    public GameEntity AddMoving(bool newValue) {
        var index = GameComponentsLookup.Moving;
        var component = (Code.Gameplay.Features.Movement.Moving)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.Moving));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceMoving(bool newValue) {
        var index = GameComponentsLookup.Moving;
        var component = (Code.Gameplay.Features.Movement.Moving)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.Moving));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveMoving() {
        RemoveComponent(GameComponentsLookup.Moving);
        return this;
    }
}
