using Code.Common.Extensions;
using Code.Gameplay;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructures.Factories;
using Code.Progress.SaveLoadServices;
using Code.Services.AnalyticService;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  [UsedImplicitly]
  public class GameplayLoopState : IState, IUpdateable
  {
    private readonly ISystemFactory _systems;
    private GameplayFeature _gameplayFeature;
    private readonly GameContext _gameContext;
    private readonly ISaveLoadService _saveLoadService;
    private readonly IAnalyticService _analyticService;

    public GameplayLoopState(ISystemFactory systems, GameContext gameContext, ISaveLoadService saveLoadService, IAnalyticService analyticService)
    {
      _systems = systems;
      _gameContext = gameContext;
      _saveLoadService = saveLoadService;
      _analyticService = analyticService;
    }
    
    public void Enter()
    {
      _analyticService.SendEvent("kjkjk");
      _analyticService.StartTestTimer();
      _gameplayFeature = _systems.Create<GameplayFeature>();
      _saveLoadService.LoadProgress();
      _gameplayFeature.Initialize();
    }

    public void Update()
    {  
      _gameplayFeature.Execute();
      _gameplayFeature.Cleanup();
    }

    public void Exit()
    {
      _saveLoadService.SaveProgress();
      _gameplayFeature.DeactivateReactiveSystems();
      _gameplayFeature.ClearReactiveSystems();

      DestructEntities();
      
      _gameplayFeature.Cleanup();
      _gameplayFeature.TearDown();
      _gameplayFeature = null;
    }

    private void DestructEntities()
    {
      foreach (GameEntity entity in _gameContext.GetEntities()) 
        entity.isDestructed = true;
    }
  }
}