//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBurningEffect;

    public static Entitas.IMatcher<GameEntity> BurningEffect {
        get {
            if (_matcherBurningEffect == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BurningEffect);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBurningEffect = matcher;
            }

            return _matcherBurningEffect;
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

    static readonly Code.Gameplay.Features.Effects.BurningEffectComponent burningEffectComponent = new Code.Gameplay.Features.Effects.BurningEffectComponent();

    public bool isBurningEffect {
        get { return HasComponent(GameComponentsLookup.BurningEffect); }
        set {
            if (value != isBurningEffect) {
                var index = GameComponentsLookup.BurningEffect;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : burningEffectComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}