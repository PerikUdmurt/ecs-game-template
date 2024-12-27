using Code.Common.Extensions;
using Code.Gameplay;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructures.Factories;
using Code.Progress.SaveLoadServices;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class GameplayLoopState : IState, IUpdateable
  {
    private readonly ISystemFactory _systems;
    private GameplayFeature _gameplayFeature;
    private readonly GameContext _gameContext;
    private readonly ISaveLoadService _saveLoadService;

    public GameplayLoopState(ISystemFactory systems, GameContext gameContext, ISaveLoadService saveLoadService)
    {
      _systems = systems;
      _gameContext = gameContext;
      _saveLoadService = saveLoadService;
    }
    
    public void Enter()
    {
      _gameplayFeature = _systems.Create<GameplayFeature>();
      _gameplayFeature.Initialize();
    }

    public void Update()
    {  
      _gameplayFeature.Execute();
      _gameplayFeature.Cleanup();
    }

    public void Exit()
    {
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