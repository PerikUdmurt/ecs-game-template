using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Stack.Systems
{
    [UsedImplicitly]
    public class CardDeckInitializeSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .With(e => e.isStack = true)
                .With(e => e.isCardDeck = true)
                .AddViewPath("Deck")
                .AddStackTypes(new() { EStackType.Card })
                .AddWorldPosition(Vector3.zero); //ToDo: fill from config
        }
    }
}