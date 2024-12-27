using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructures.ObjectPool
{
    public interface IObjectPool<T>: IFillableObjectPool where T : MonoBehaviour
    {
        UniTask<T> Get();
        void Release(T obj);
    }

    public interface IFillableObjectPool
    {
        UniTask Fill(int prepareObjects);
    }
}