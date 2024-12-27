using Code.UI.Core;
using Code.UI.Develop;

namespace Code.Infrastructures.Installers.SceneInstallers.NightCycle
{
    public class BootstrapUIInstaller : UIInstaller
    {
        protected override void InstallBindingsInternal()
        {
            InstallDevelopUI();
        }

        private void InstallDevelopUI()
        {
            Install<DevelopUIInstaller>();
        }
    }
}
