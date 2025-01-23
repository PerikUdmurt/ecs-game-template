using UnityEngine;

namespace Extensions
{
    public static class GameObjectExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject)
            where T : Component
        {
            if (!gameObject.TryGetComponent<T>(out var attachedComponent))
            {
                attachedComponent = gameObject.AddComponent<T>();
            }

            return attachedComponent;
        }

        public static bool HasComponent<T>(this GameObject gameObject)
            where T : Component
        {
            return gameObject.TryGetComponent<T>(out _);
        }

        public static void ToggleActive(this GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public static void DestroyAllChildren(this GameObject gameObject)
        {
            foreach (Transform child in gameObject.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        public static void AddComponentIfMissing<T>(this GameObject gameObject)
            where T : Component
        {
            if (gameObject.GetComponent<T>() == null)
            {
                gameObject.gameObject.AddComponent<T>();
            }
        }
    }
}
