using Code.UI.Core;
using Code.UI.Core.ContainerBinding;
using JetBrains.Annotations;
using Zenject;

namespace Code.UI.Settings
{
    [UsedImplicitly]
    public class SettingsUIInstaller : Installer<SettingsUIInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindController<SettingsScreenController>()
                .WithViewFromResourcePath(UIConstants.SettingsScreen)
                .InLayer(EUILayerType.Screen);
        }
    }
}