using Code.Infrastructures.View;
using UnityEngine;

namespace Code.Common.Unity.Registrars
{
    public class SpriteRendererRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private UnityEngine.SpriteRenderer _spriteRenderer;

        public override void RegisterComponent()
        {
            Entity.AddSpriteRenderer(_spriteRenderer);
        }

        public override void UnregisterComponent()
        {
            Entity.RemoveSpriteRenderer();
        }
    }
}
