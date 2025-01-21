using Entitas;

namespace Code.Common.Unity
{
    public class SpriteRenderer : IComponent { public UnityEngine.SpriteRenderer Value; }
    public class NavMeshAgent : IComponent { public UnityEngine.AI.NavMeshAgent Value; }
    public class Animator : IComponent { public UnityEngine.Animator Value; }
    public class Rigidbody : IComponent { public UnityEngine.Rigidbody Value; }
    public class AudioSource : IComponent { public UnityEngine.AudioSource Value; }
    public class Transform : IComponent { public UnityEngine.Transform Value; }
    public class Rigidbody2D : IComponent { public UnityEngine.Rigidbody2D Value; }
    public class Rigidbody3D : IComponent { public UnityEngine.Rigidbody Value; }
}