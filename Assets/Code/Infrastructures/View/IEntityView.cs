using Entitas;
using UnityEngine;

namespace Code.Infrastructures.View
{
    public interface IEntityView
    {
        GameEntity Entity { get; }

        void ReleaseEntity();
        void SetEntity(GameEntity entity);
        GameObject gameObject {  get; }  
    }

    public class BindEntityViewSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public BindEntityViewSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ViewPath)
                .NoneOf(GameMatcher.View));
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}