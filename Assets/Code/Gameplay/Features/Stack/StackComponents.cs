using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Stack
{
    [Game] public class StackComponent : IComponent { }
    [Game] public class StackTypes : IComponent { public List<EStackType> AvailableTypes; }
    [Game] public class StackedEntitiesIds : IComponent { public List<int> Entities; }
    [Game] public class CardHand : IComponent { }
    [Game] public class CardDeck : IComponent { }
    [Game] public class CardReset : IComponent { }
    [Game] public class ShowStackElementsComponent : IComponent { } 
    [Game] public class HorizontalElementArrangement : IComponent { public Vector3 Delta; }
    [Game] public class StackCountComponent : IComponent { public int Value; }
    [Game] public class StackMaxCountComponent : IComponent { public int Value; }
    [Game] public class StackableComponent : IComponent { }

    public enum EStackType
    {
        Card = 0,
        Item = 1,
        Hero = 2,
        Effect = 3,
    }
}
