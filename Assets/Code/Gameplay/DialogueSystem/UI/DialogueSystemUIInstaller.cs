using Code.Gameplay.DialogueSystem.UI.Controller;
using Code.Gameplay.DialogueSystem.UI.View;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructures.AssetManagement;
using Code.Infrastructures.ObjectPool.DiBinding;
using Code.UI.Core;
using Code.UI.Core.ContainerBinding;
using Zenject;

namespace Code.Gameplay.DialogueSystem.UI
{
    public class DialogueSystemUIInstaller : Installer<DialogueSystemUIInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindController<DialogueScreenController>()
                .WithViewFromResourcePath(UIConstants.DialogueScreenView)
                .InLayer(EUILayerType.Screen);

            Container
                .BindObjectPool<DialogueBlockUIView>()
                .WithPrefabFromAssetPath(AssetPath.DialogueBlockUIView)
                .PrepareObjects(5);
        }
    }
}