using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;

namespace Code.Services.Audio
{
    [UsedImplicitly]
    public class AudioService : IAusioService
    {
        private readonly AudioMixer _mixer;
        
        public AudioService(AudioMixer mixer)
        {
            _mixer = mixer;
        }

        /// <summary>
        ///  Min value = 0, MaxValue = 100
        /// </summary>
        public void SetSoundVolume(float volume) =>
            SetVolume("SoundVolume", volume);

        /// <summary>
        ///  Min value = 0, MaxValue = 100
        /// </summary>
        public void SetMasterVolume(float volume) =>
            SetVolume("MasterVolume", volume);
        
        /// <summary>
        ///  Min value = 0, MaxValue = 100
        /// </summary>
        public void SetMusicVolume(float volume) =>
            SetVolume("MusicVolume", volume);
        
        /// <summary>
        ///  Min value = 0, MaxValue = 100
        /// </summary>
        public void SetScreemsVolume(float volume) =>
            SetVolume("ScreemsVolume", volume);
        
        private void SetVolume(string exposedParameterName, float volume)
        {
            volume = Mathf.Clamp(volume, 0, 100);
            volume -= 80f;
            _mixer.SetFloat(exposedParameterName, volume);
        }
    }

    public interface IAusioService
    {
        /// <summary>
        ///  Min value = 0, MaxValue = 100
        /// </summary>
        void SetSoundVolume(float volume);

        /// <summary>
        ///  Min value = 0, MaxValue = 100
        /// </summary>
        void SetMasterVolume(float volume);

        /// <summary>
        ///  Min value = 0, MaxValue = 100
        /// </summary>
        void SetMusicVolume(float volume);

        /// <summary>
        ///  Min value = 0, MaxValue = 100
        /// </summary>
        void SetScreemsVolume(float volume);
    }
}