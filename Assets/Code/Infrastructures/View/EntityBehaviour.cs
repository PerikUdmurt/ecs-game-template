using Code.Gameplay.Common.Collisions;
using UnityEngine;
using Zenject;

namespace Code.Infrastructures.View
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        private GameEntity _entity;

        private ICollisionRegistry _collisionRegistry;
        public GameEntity Entity => _entity;

        [Inject]
        private void Constuct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            
            entity.Retain(this);

            foreach (IEntityComponentRegistrar registrars in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrars.RegisterComponent();

            foreach (Collider2D collider in GetComponentsInChildren<Collider2D>(includeInactive: true))
                _collisionRegistry.Register(collider.GetInstanceID(), _entity);
        }

        public void ReleaseEntity()
        {
            foreach (IEntityComponentRegistrar registrars in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrars.UnregisterComponent();

            foreach (Collider2D collider in GetComponentsInChildren<Collider2D>(includeInactive: true))
                _collisionRegistry.Unregister(collider.GetInstanceID());
            
            _entity.Retain(this);
            _entity = null;
        }
    }
}