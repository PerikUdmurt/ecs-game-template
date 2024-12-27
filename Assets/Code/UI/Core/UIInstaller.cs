using Code.Gameplay.DialogueSystem.UI;
using Code.Gameplay.DialogueSystem.UI.Controller;
using Code.UI.Core.Controller;
using Code.UI.Core.Navigator;
using Code.UI.Develop;
using Code.UI.Localization;
using UnityEngine;
using Zenject;

namespace Code.UI.Core
{
    public abstract class UIInstaller : MonoInstaller<UIInstaller>
    {
        public sealed override void InstallBindings()
        {
            InstallBindingsInternal();
        }

        protected abstract void InstallBindingsInternal();
        
        protected void Install<T>() where T : Installer<T>
        {
            Installer<T>.Install(Container);
            Debug.Log($"[UI INSTALLER] Install: <b>{typeof(T).Name}</b>");
        }
    }

    public class UICoreInstaller : Installer<UICoreInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IUINavigator>()
                .To<UINavigator>()
                .AsSingle();

            Container
                .Bind<UIRoot>()
                .FromComponentInNewPrefabResource(UIConstants.UIRoot)
                .AsSingle()
                .NonLazy();

            Installer<DevelopUIInstaller>.Install(Container);
            Installer<DialogueSystemUIInstaller>.Install(Container);
            Installer<LocalizationUIInstaller>.Install(Container);
        }
    }
}