using UnityEngine;

namespace Code.Infrastructures.View
{
    public class EntityDependant : MonoBehaviour
    {
        public EntityBehaviour EntityBehaviour;

        public GameEntity Entity => EntityBehaviour != null ? EntityBehaviour.Entity : null;

        private void Awake()
        {
            if (!EntityBehaviour)
                EntityBehaviour = GetComponent<EntityBehaviour>();
        }
    }
}