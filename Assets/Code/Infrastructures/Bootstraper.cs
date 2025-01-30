using Code.Infrastructure.States.StateMachine;
using Code.Infrastructures.StateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace Code.Infrastructures
{
    public class Bootstraper : MonoBehaviour
    {
        private IGameStateMachine _stateMachine;
    
        [Inject]
        private void SetDependencies(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    
        private void Awake()
        {
            _stateMachine.Enter<BootstrapState>();
        }
    }
}
