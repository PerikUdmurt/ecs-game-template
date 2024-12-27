using Code.UI.Core;
using Code.UI.Core.ContainerBinding;
using Zenject;

namespace Code.UI.Localization
{
    public class LocalizationUIInstaller : Installer<LocalizationUIInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindController<LocalizationUIController>()
                .WithViewFromResourcePath(UIConstants.LocalizationPopup)
                .InLayer(EUILayerType.Popup);
        }
    }
}