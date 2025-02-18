using Code.Gameplay.Common.Collisions;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Features.Camera;
using Code.Gameplay.Features.Cards.Factory;
using Code.Gameplay.Features.Cursor;
using Code.Gameplay.Features.Tiles;
using Code.Identifiers;
using Code.Infrastructures.AssetManagement;
using Code.Infrastructures.Factories;
using Code.Infrastructures.SceneLoaders;
using Code.Infrastructures.StateMachine;
using Code.Infrastructures.Time;
using Code.Infrastructures.View.Factory;
using Code.NodeBasedSystem;
using Code.Progress;
using Code.Services.AnalyticService;
using Code.Services.Audio;
using Code.Services.InputServices;
using Code.Services.LocalizationServices;
using Code.Services.PlayerSettingsServices;
using Code.Services.ScreenResolutionService;
using Code.Services.StaticDataServices;
using Code.UI.Core;
using UnityEngine;
using Zenject;

namespace Code.Infrastructures.Installers
{
    public class ProjectInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            InstallConfigs();
            InstallSelfAsCourutineRunner();
            InstallServices();
            InstallGameplayFactories();
            InstallInfrastuctures();
            InstallUI();
            
            Install<CardsInstaller>(); //to gameplay installer
        }

        private void InstallInfrastuctures()
        {
            Install<GameStatesInstaller>();
            Install<ContextsInstaller>();
            Install<SystemFactoryInstaller>();
            Install<CollisionRegistryInstaller>();
            Install<AssetManagementInstaller>();
            Install<SceneLoaderInstaller>();
            Install<PrefabFactoryInstaller>();
            Install<NodeSystemInstaller>();
        }

        private void InstallSelfAsCourutineRunner()
        {
            Container.Bind<ICoroutineRunner>()
                .FromInstance(this);
        }

        private void InstallServices()
        {
            Install<ProgressInstaller>();
            Install<TimeServiceInstaller>();
            Install<InputServiceInstaller>();
            Install<IdentifierServiceInstaller>();
            Install<StaticDataInstaller>();
            Install<LocalizationInstaller>();
            Install<ScreenResolutionInstaller>();
            Install<PlayerSettingsInstaller>();
            Install<PhysicsInstaller>();
            Install<GameAnalyticInstaller>();
            Install<AudioInstaller>();
        }

        private void InstallConfigs()
        {
            Install<CursorInstaller>();
            Install<CameraInstaller>();
        }

        private void InstallGameplayFactories()
        {
            Install<EntityViewFactoryInstaller>();
            Install<TilesInstaller>();
        }

        private void InstallUI()
        {
            Install<UICoreInstaller>();
        }

        private void Install<T>() where T : Installer<T>
        {
            Installer<T>.Install(Container);
            Debug.Log($"[PROJECT INSTALLER] Install: <b>{typeof(T).Name}</b>");
        }
    }
}