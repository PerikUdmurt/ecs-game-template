using Zenject;

namespace Code.Services.InputServices
{
    public class InputServiceInstaller : Installer<InputServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IInputService>()
                .To<DesktopInputService>()
                .AsSingle();
        }
    }
}