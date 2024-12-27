using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Infrastructures.View
{
    public class SelfInitializeEntityView : MonoBehaviour
    {
        public EntityBehaviour entityBehaviour;

        private IIdentifierService _identifierService;
        
        [Inject]
        public void Constuct(IIdentifierService identifier) =>
            _identifierService = identifier;

        private void Awake()
        {
            GameEntity entity = CreateEntity.Empty()
                .AddId(_identifierService.Next());

            entityBehaviour.SetEntity(entity);
        }
    }
}