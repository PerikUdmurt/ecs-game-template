using Code.Infrastructures.View;
using UnityEngine;

namespace Code.Common.UnityRegistrars.Registrars
{
    public class AnimatorRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Animator _animator;
        public override void RegisterComponent() =>
            Entity.AddAnimator(_animator);

        public override void UnregisterComponent() =>
            Entity.RemoveAnimator();
    }
}