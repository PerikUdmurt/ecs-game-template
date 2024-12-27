using Code.Progress.PlayerResources.Configs;
using UnityEngine;
using Zenject;

namespace Code.Progress
{
    [CreateAssetMenu(
        fileName = "ProgressScriptableObjectInstaller", 
        menuName = "Configs/Progress/Installers/ProgressScriptableObjectInstaller")]
    public class ProgressScriptableObjectInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerResourcesInitialConfig _resourcesInitialConfig;
        
        public override void InstallBindings()
        {
            Container
                .BindInstances(_resourcesInitialConfig);
        }
    }
}