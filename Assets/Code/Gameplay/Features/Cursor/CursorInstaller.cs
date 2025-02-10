using JetBrains.Annotations;
using Zenject;

namespace Code.Gameplay.Features.Cursor
{
    [UsedImplicitly]
    public class CursorInstaller : Installer<CursorInstaller>
    {
        private readonly string CURSOR_CONFIG_RESOURCES_PATH = "StaticDatas/Cursors/CursorConfig";
        
        public override void InstallBindings()
        {
            Container
                .Bind<CursorConfig>()
                .FromResources(CURSOR_CONFIG_RESOURCES_PATH)
                .AsSingle();
        }
    }
}