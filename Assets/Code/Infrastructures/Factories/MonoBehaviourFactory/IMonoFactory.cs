using UnityEngine;

namespace Code.Infrastructures.Factories
{
    public interface IMonoFactory
    {
        T Create<T>(GameObject obj) where T : MonoBehaviour;
        T Create<T>(string resourcePath) where T : MonoBehaviour;
    }
}