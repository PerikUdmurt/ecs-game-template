using Code.Gameplay.Features.Camera.Configs;
using JetBrains.Annotations;
using Zenject;

namespace Code.Gameplay.Features.Camera
{
    [UsedImplicitly]
    public class CameraInstaller : Installer<CameraInstaller>
    {
        private const string CAMERA_CONFIG_PATH = "StaticDatas/Camera/CameraConfig";
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<CameraConfig>()
                .FromResources(CAMERA_CONFIG_PATH)
                .AsSingle();
        }
    }
}