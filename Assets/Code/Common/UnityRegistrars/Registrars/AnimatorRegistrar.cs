using Code.Infrastructures.View;
using UnityEngine;

public class AnimatorRegistrar : EntityComponentRegistrar
{
    [SerializeField] private UnityEngine.Animator _animator;

    public override void RegisterComponent()
    {
        Entity.AddAnimator(_animator);
    }

    public override void UnregisterComponent()
    {
        Entity.RemoveAnimator();
    }
}
