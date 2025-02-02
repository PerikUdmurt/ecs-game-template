using Code.Gameplay.Features.Cards.Factory;
using UnityEngine;
using Zenject;

namespace Code.Infrastructures.Installers.SceneInstallers.Gameplay
{
    public class GameplayMonoInstaller : MonoInstaller<GameplayMonoInstaller>
    {
        public override void InstallBindings()
        {
            Install<CardsInstaller>();
        }

        private void Install<T>() where T : Installer<T>
        {
            Installer<T>.Install(Container);
            Debug.Log($"[GAMEPLAY INSTALLER] Install: <b>{typeof(T).Name}</b>");
        }
    }
}