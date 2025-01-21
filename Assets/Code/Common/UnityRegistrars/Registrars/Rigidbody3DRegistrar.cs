using Code.Infrastructures.View;
using UnityEngine;

namespace Code.Common.UnityRegistrars.Registrars
{
    public class Rigidbody3DRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private UnityEngine.Rigidbody _rigidBody3D;
        public override void RegisterComponent() =>
            Entity.AddRigidbody3D(_rigidBody3D);

        public override void UnregisterComponent() =>
            Entity.RemoveRigidbody3D();
    }
}