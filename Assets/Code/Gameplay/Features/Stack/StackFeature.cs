using System.Collections.Generic;
using System.Xml;
using Code.Infrastructures.Factories;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Stack
{
    [UsedImplicitly]
    public class CardDecksFeature : Feature
    {
        public CardDecksFeature(ISystemFactory factory)
        {
            Add(factory.Create<StackInitializeFeature>());
            Add(factory.Create<OnChangeCardStackElementSystem>());
        }
    }

    [UsedImplicitly]
    public class OnChangeCardStackElementSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _cardStacks;
        
        public OnChangeCardStackElementSystem(GameContext gameContext)
            : base(gameContext)
        {
            _cardStacks = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.CardStack));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CardStackElement);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCardStackElement;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity stackable in entities)
                switch (stackable.CardStackElement)
                {
                    case EStackType.Hand:
                        
                        break;
                    case EStackType.DiceDeck:
                        break;
                    case EStackType.Reset:
                        break;
                    case EStackType.ItemDeck:
                        break;
                }
        }

        private void AddEntityToHand(GameEntity stackable)
        {
            foreach (GameEntity hand in _hands.GetEntities())
                
        }
    }
}
