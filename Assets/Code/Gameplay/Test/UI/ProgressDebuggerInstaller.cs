using Code.UI.Core;
using Code.UI.Core.ContainerBinding;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Zenject;

namespace Code.Gameplay.Test.UI
{
    [UsedImplicitly]
    public class ProgressDebuggerInstaller : Installer<ProgressDebuggerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindController<ProgressDebuggerUIController>()
                .WithViewFromResourcePath(UIConstants.ProgressDebugger)
                .InLayer(EUILayerType.Develop)
                .OnInstantiated<ProgressDebuggerUIController>((a,c)=> c.Show().Forget());
        }
    }
}