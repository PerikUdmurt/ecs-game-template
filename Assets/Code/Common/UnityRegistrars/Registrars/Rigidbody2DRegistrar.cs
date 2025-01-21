using Code.Infrastructures.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Common.Unity.Registrars
{
    public class Rigidbody2DRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private UnityEngine.Rigidbody2D _rigidbody2D;

        public override void RegisterComponent() =>
            Entity.AddRigidbody2D(_rigidbody2D);

        public override void UnregisterComponent() =>
            Entity.RemoveRigidbody2D();
    }
}