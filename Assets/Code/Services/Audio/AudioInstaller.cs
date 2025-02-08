using JetBrains.Annotations;
using UnityEngine.Audio;
using Zenject;

namespace Code.Services.Audio
{
    [UsedImplicitly]
    public class AudioInstaller : Installer<AudioInstaller>
    {
        private const string AUDIO_MIXER_RESOURCE_PATH = "Audio/DefaultAudioMixer";
        
        public override void InstallBindings()
        {
            Container
                .Bind<AudioMixer>()
                .FromResources(AUDIO_MIXER_RESOURCE_PATH)
                .AsSingle();
            
            Container
                .Bind<IAusioService>()
                .To<AudioService>()
                .AsSingle();
        }
    }
}