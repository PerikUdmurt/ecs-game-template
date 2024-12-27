using Code.Progress.Provider;
using Code.Progress.SaveLoadServices;
using JetBrains.Annotations;
using Zenject;

namespace Code.Progress
{
    [UsedImplicitly]
    public class ProgressInstaller : Installer<ProgressInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .AsSingle();
            
            Container
                .Bind<IProgressProvider>()
                .To<ProgressProvider>()
                .AsSingle();

            Container
                .Bind<IInitialProgressProvider>()
                .To<InitialProgressProvider>()
                .AsSingle();
        }
    }
}
