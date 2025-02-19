using Entitas;
using UnityEngine;

namespace Code.Infrastructures.View
{
    public interface IEntityView
    {
        GameEntity Entity { get; }
        void ReleaseEntity();
        void SetEntity(GameEntity entity);
        GameObject gameObject { get; }
    }
}