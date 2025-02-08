using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Stack
{
    [Game] public class CardStack : IComponent { public EStackType Value; }
    [Game] public class CardStackElement : IComponent { public EStackType Value; }
    [Game] public class StackCountComponent : IComponent { public int Value; }
    [Game] public class StackMaxCountComponent : IComponent { public int Value; }
    [Game] public class OutOfRangeOfStackComponent : IComponent { public EStackType Value; }
    [Game] public class HorizontalLayout : IComponent { public Vector3 Delta; }

    public enum EStackType
    {
        DiceDeck = 0,
        ItemDeck = 1,
        Hand = 2,
        Reset = 3,
    }
}
