using Code.UI.Core;
using Code.UI.Core.ContainerBinding;
using Code.UI.Core.Navigator;
using Code.UI.Develop.Debugger;
using Cysharp.Threading.Tasks;
using System;
using Code.Gameplay.Test.UI;
using JetBrains.Annotations;
using UnityEditor.AddressableAssets.Build.BuildPipelineTasks;
using UnityEngine;
using Zenject;

namespace Code.UI.Develop
{
    [UsedImplicitly]
    public class DevelopUIInstaller : Installer<DevelopUIInstaller>
    {
        public override void InstallBindings()
        {
            Installer<UIDebuggerInstaller>.Install(Container);
            Installer<ProgressDebuggerInstaller>.Install(Container);

            Container
                .BindController<DevelopUIController>()
                .WithViewFromResourcePath(UIConstants.DevelopDisplay)
                .InLayer(EUILayerType.Develop);
            
            Container
                .BindController<DevelopUiShowerController>()
                .WithViewFromResourcePath(UIConstants.DevelopShower)
                .InLayer(EUILayerType.Develop)
                .OnInstantiated<DevelopUiShowerController>((o,controller) => controller.Show().Forget());
            /*
            Container.BindInterfacesAndSelfTo<DevelopHUDController>()
                .AsSingle()
                .NonLazy();
            */
            Container
                .BindInterfacesAndSelfTo<DevelopHUDModel>()
                .AsSingle();
        }
    }

    [UsedImplicitly]
    public class DevelopHUDController : ITickable
    {
        private readonly IUINavigator _navigator;

        public DevelopHUDController(IUINavigator navigator)
        {
            _navigator = navigator;
        }
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                _navigator.Show<DevelopUIController>();
            }
        }
    }
}