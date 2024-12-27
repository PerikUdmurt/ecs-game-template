using Code.Infrastructures.View;
using UnityEngine;

namespace Code.Common.Unity.Registrars
{
    public class Rigidbody2DRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private UnityEngine.Rigidbody2D _audioAgent;

        public override void RegisterComponent() =>
            Entity.AddRigidbody2D(_audioAgent);

        public override void UnregisterComponent() =>
            Entity.RemoveRigidbody2D();
    }
}