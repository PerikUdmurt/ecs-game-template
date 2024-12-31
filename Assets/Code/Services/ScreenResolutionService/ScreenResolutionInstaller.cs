using Zenject;

namespace Code.Services.ScreenResolutionService
{
    public class ScreenResolutionInstaller : Installer<ScreenResolutionInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IScreenResolutionService>()
                .To<ScreenResolutionService>()
                .AsSingle();
        }
    }
}