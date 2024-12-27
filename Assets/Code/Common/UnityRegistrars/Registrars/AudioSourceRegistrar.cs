using Code.Infrastructures.View;
using UnityEngine;

namespace Code.Common.Unity.Registrars
{

    public class AudioSourceRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private UnityEngine.AudioSource _audioAgent;

        public override void RegisterComponent() =>
            Entity.AddAudioSource(_audioAgent);

        public override void UnregisterComponent() =>
            Entity.RemoveAudioSource();
    }
}