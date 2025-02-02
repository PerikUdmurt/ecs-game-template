using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Stack.Systems
{
    [UsedImplicitly]
    public class CardResetInitializeSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .With(e => e.isStack = true)
                .With(e => e.isCardReset = true)
                .AddViewPath("CardReset")
                .AddStackTypes(new() { EStackType.Card })
                .AddWorldPosition(Vector3.zero);
        }
    }
}