using UnityEngine;

namespace Extensions
{
    public static class RigidbodyExtensions
    {
        public static void ChangeDirection(this Rigidbody rigidbody, Vector3 direction)
        {
#if UNITY_6000_0_OR_NEWER
            rigidbody.linearVelocity = direction * rigidbody.linearVelocity.magnitude;
#else
            rigidbody.velocity = direction * rigidbody.velocity.magnitude;
#endif
        }

        public static void AddForceToReachVelocity(
            this Rigidbody rigidbody,
            Vector3 targetVelocity,
            float maxForce
        )
        {
            Vector3 velocityDiff = targetVelocity - rigidbody.velocity;
            Vector3 force = Vector3.ClampMagnitude(velocityDiff, maxForce);
            rigidbody.AddForce(force, ForceMode.Force);
        }

        public static void Stop(this Rigidbody rigidbody)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

        public static bool IsAlmostStopped(this Rigidbody rigidbody, float threshold = 0.1f)
        {
            return rigidbody.velocity.magnitude < threshold;
        }
    }
}
