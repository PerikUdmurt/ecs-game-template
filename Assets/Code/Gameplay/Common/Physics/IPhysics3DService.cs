using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Common.Physics
{
    public interface IPhysics3DService
    {
        IEnumerable<GameEntity> RaycastAll(Vector3 worldPosition, Vector3 direction, int layerMask);
        GameEntity Raycast(Vector3 worldPosition, Vector3 direction, int layerMask);
        IEnumerable<GameEntity> SphereCast(Vector3 position, float radius, int layerMask);
        IEnumerable<GameEntity> BoxCast(Vector3 position, Vector3 halfExt, Quaternion quaternion, int layerMask);
    }
}