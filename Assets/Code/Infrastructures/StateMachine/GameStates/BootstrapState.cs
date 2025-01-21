using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructures.SceneLoaders;
using JetBrains.Annotations;

namespace Code.Infrastructures.StateMachine.GameStates
{
  [UsedImplicitly]
  public class BootstrapState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public BootstrapState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }
    
    public void Enter()
    {
      _sceneLoader.Load(SceneName.CharacterPlayground, OnSceneLoaded);
    }

    private void OnSceneLoaded()
    {
      _stateMachine.Enter<GameplayLoopState>();
    }

    public void Exit()
    {
      
    }
  }
}