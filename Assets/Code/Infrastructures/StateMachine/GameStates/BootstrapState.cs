using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructures.SceneLoaders;
using Code.Services.AnalyticService;
using JetBrains.Annotations;

namespace Code.Infrastructures.StateMachine.GameStates
{
  [UsedImplicitly]
  public class BootstrapState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;
    private readonly IAnalyticService _analyticService;
    
    public BootstrapState(
      IGameStateMachine stateMachine, 
      ISceneLoader sceneLoader, 
      IAnalyticService analyticService)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _analyticService = analyticService;
    }
    
    public void Enter()
    {
      InitializeServices();
      _sceneLoader.Load(SceneName.NightCycle, OnSceneLoaded);
    }

    private void OnSceneLoaded()
    {
      _stateMachine.Enter<GameplayLoopState>();
    }

    public void Exit()
    {
      
    }

    private void InitializeServices()
    {
      _analyticService.Initialize();
    }
  }
}