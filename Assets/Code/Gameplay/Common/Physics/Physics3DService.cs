using System.Collections.Generic;
using Code.Gameplay.Common.Collisions;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Common.Physics
{
    [UsedImplicitly]
    public class Physics3DService : IPhysics3DService
    {
        private static readonly RaycastHit[] Hits = new RaycastHit[128];
        private static readonly Collider[] OverlapHits = new Collider[128];

        private readonly ICollisionRegistry _collisionRegistry;

        public Physics3DService(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public IEnumerable<GameEntity> RaycastAll(Vector3 worldPosition, Vector3 direction, int layerMask)
        {
            int hitCount = UnityEngine.Physics.RaycastNonAlloc(worldPosition, direction, Hits, layerMask);

            DrawDebugRay(worldPosition, direction, Color.yellow);
            
            for (int i = 0; i < hitCount; i++)
            {
                RaycastHit hit = Hits[i];
                if (hit.collider == null)
                    continue;

                GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
                if (entity == null)
                    continue;

                yield return entity;
            }
        }

        public GameEntity Raycast(Vector3 worldPosition, Vector3 direction, int layerMask)
        {
            int hitCount = UnityEngine.Physics.RaycastNonAlloc(worldPosition, direction, Hits, layerMask);

            DrawDebugRay(worldPosition, direction, Color.green);
            
            for (int i = 0; i < hitCount; i++)
            {
                RaycastHit hit = Hits[i];
                if (hit.collider == null)
                    continue;

                GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
                if (entity == null)
                    continue;

                return entity;
            }

            return null;
        }

        public IEnumerable<GameEntity> SphereCast(Vector3 position, float radius, int layerMask)
        {
            int hitCount = OverlapSphere(position, radius, OverlapHits, layerMask);
            
            DrawDebugSphere(position, radius, Color.red);

            for (int i = 0; i < hitCount; i++)
            {
                GameEntity entity = _collisionRegistry.Get<GameEntity>(OverlapHits[i].GetInstanceID());
                if (entity == null)
                    continue;

                yield return entity;
            }
        }
        
        public IEnumerable<GameEntity> BoxCast(Vector3 position, Vector3 halfExt, Quaternion quaternion, int layerMask)
        {
            int hitCount = OverlapBox(position, halfExt, quaternion, layerMask);

            DrawDebugBox(position, halfExt, Color.red);
            
            for (int i = 0; i < hitCount; i++)
            {
                GameEntity entity = _collisionRegistry.Get<GameEntity>(OverlapHits[i].GetInstanceID());
                if (entity == null)
                    continue;

                yield return entity;
            }
        }

        private int OverlapSphere(Vector3 worldPos, float radius, Collider[] hits, int layerMask) =>
            UnityEngine.Physics.OverlapSphereNonAlloc(worldPos, radius, hits, layerMask);

        private int OverlapBox(Vector3 center, Vector3 halfExt, Quaternion quaternion, int layerMask) =>
            UnityEngine.Physics.OverlapBoxNonAlloc(center, halfExt, OverlapHits, quaternion, layerMask);

        private static void DrawDebugSphere(Vector3 worldPos, float radius, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(worldPos, radius);
        }

        private static void DrawDebugBox(Vector3 center, Vector3 size, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawCube(center, size);
        }

        private static void DrawDebugRay(Vector3 start, Vector3 dir, Color color)
        {
            Debug.DrawRay(start, dir, color, 1f);
        }
    }
}