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
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.AddTransform(transform);
            
            entity.Retain(this);

            foreach (IEntityComponentRegistrar registrars in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrars.RegisterComponent();

            foreach (Collider2D col2D in GetComponentsInChildren<Collider2D>(includeInactive: true))
                _collisionRegistry.Register(col2D.GetInstanceID(), _entity);
            
            foreach (Collider col in GetComponentsInChildren<Collider>(includeInactive: true))
                _collisionRegistry.Register(col.GetInstanceID(), _entity);
        }

        public void ReleaseEntity()
        {
            foreach (IEntityComponentRegistrar registrars in GetComponentsInChildren<IEntityComponentRegistrar>())
                registrars.UnregisterComponent();

            foreach (Collider2D col2D in GetComponentsInChildren<Collider2D>(includeInactive: true))
                _collisionRegistry.Unregister(col2D.GetInstanceID());
            
            foreach (Collider col in GetComponentsInChildren<Collider>(includeInactive: true))
                _collisionRegistry.Unregister(col.GetInstanceID());
            
            _entity.Retain(this);
            _entity = null;
        }
    }
}