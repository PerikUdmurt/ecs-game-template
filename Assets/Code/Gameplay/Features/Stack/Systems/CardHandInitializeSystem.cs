using Code.Common.Entity;
using Code.Common.Extensions;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Stack.Systems
{
    [UsedImplicitly]
    public class CardHandInitializeSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateEntity.Empty()
                .With(e => e.isStack = true)
                .With(e => e.isCardHand = true)
                .AddStackTypes(new() { EStackType.Card })
                .With(e => e.isShowStackElements = true)
                .AddStackMaxCount(5) //ToDo: Set from config
                .AddHorizontalElementArrangement(new Vector3(1f, 0f, 0.5f))
                .AddWorldPosition(Vector3.zero);
        }
    }
    
    [UsedImplicitly]
    public class 
    {
    
    }

    [UsedImplicitly]
    public class HorizontalLayoutSystem : 
    {
        
    }
}
