using Code.UI.Core;
using Code.UI.Develop;

namespace Code.Infrastructures.Installers.SceneInstallers.Gameplay
{
    public class GameplayUIMonoInstaller : UIInstaller
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
