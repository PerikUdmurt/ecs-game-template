using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using Zenject;

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
