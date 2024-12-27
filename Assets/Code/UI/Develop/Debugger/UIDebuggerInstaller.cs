using Code.UI.Core;
using Code.UI.Core.ContainerBinding;
using JetBrains.Annotations;
using Zenject;

namespace Code.UI.Develop.Debugger
{
    [UsedImplicitly]
    public class UIDebuggerInstaller : Installer<UIDebuggerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindController<UIDebuggerController>()
                .WithViewFromResourcePath(UIConstants.Debugger)
                .InLayer(EUILayerType.Develop);
        }
    }
}