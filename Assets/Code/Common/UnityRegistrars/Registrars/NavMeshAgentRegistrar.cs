using Code.Infrastructures.View;
using UnityEngine;

namespace Code.Common.Unity.Registrars
{
    public class NavMeshAgentRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;

        public override void RegisterComponent() =>
            Entity.AddNavMeshAgent(_agent);

        public override void UnregisterComponent() =>
            Entity.RemoveNavMeshAgent();
    }
}
