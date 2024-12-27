using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effects
{
    [Game] public class EffectComponent : IComponent {}
    [Game] public class EffectSetupsComponent : IComponent { public List<EffectSetup> Value; }
    [Game] public class EffectProducerIdComponent : IComponent { public int Value; }
    [Game] public class EffectTargetIdComponent : IComponent { public int Value; }
    [Game] public class EffectValueComponent : IComponent { public int Value; }
    [Game] public class BleedingEffectComponent : IComponent { }
    [Game] public class BurningEffectComponent : IComponent { }
    [Game] public class DamageEffectComponent : IComponent { }
}