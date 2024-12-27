using Zenject;

public class ContextsInstaller : Installer<ContextsInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<GameContext>()
            .FromInstance(Contexts.sharedInstance.game)
            .AsSingle();

        Container
            .Bind<Contexts>()
            .FromInstance(Contexts.sharedInstance)
            .AsSingle();
        
        Container
            .Bind<ProgressContext>()
            .FromInstance(Contexts.sharedInstance.progress)
            .AsSingle();

        Container
            .Bind<NodeSystemContext>()
            .FromInstance(Contexts.sharedInstance.nodeSystem)
            .AsSingle();
    }
}
