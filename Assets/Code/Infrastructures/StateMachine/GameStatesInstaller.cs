using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Zenject;

public class GameStatesInstaller : Installer<GameStatesInstaller>
{
    public override void InstallBindings()
    {
        BindStateMachine();
        BindStateFactory();
        BindGameStates();
    }

    private void BindStateMachine()
    {
        Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
    }

    private void BindStateFactory()
    {
        Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
    }

    private void BindGameStates()
    {
        Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameplayLoopState>().AsSingle();
    }
}
