using Code.Infrastructures.View;
using UnityEngine;

public class RigidbodyRegistrar : EntityComponentRegistrar
{
    [SerializeField] private UnityEngine.Rigidbody _rigidbody;

    public override void RegisterComponent() =>
        Entity.AddRigidbody(_rigidbody);

    public override void UnregisterComponent() =>
        Entity.RemoveRigidbody();
}