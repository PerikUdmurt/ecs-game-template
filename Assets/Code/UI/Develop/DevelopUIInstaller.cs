using Code.UI.Core;
using Code.UI.Core.ContainerBinding;
using Code.UI.Core.Navigator;
using Code.UI.Develop.Debugger;
using Cysharp.Threading.Tasks;
using System;
using Zenject;

namespace Code.UI.Develop
{
    public class DevelopUIInstaller : Installer<DevelopUIInstaller>
    {
        public override void InstallBindings()
        {
            Installer<UIDebuggerInstaller>.Install(Container);

            Container
                .BindController<DevelopUIController>()
                .WithViewFromResourcePath(UIConstants.DevelopDisplay)
                .InLayer(EUILayerType.Develop);

            Container
                .BindController<DevelopUiShowerController>()
                .WithViewFromResourcePath(UIConstants.DevelopShower)
                .InLayer(EUILayerType.Develop)
                .OnInstantiated<DevelopUiShowerController>((o,controller) => controller.Show().Forget());

            Container
                .BindInterfacesAndSelfTo<DevelopHUDModel>()
                .AsSingle();
        }
    }
}