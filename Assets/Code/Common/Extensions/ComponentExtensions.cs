using UnityEngine;

namespace SABI
{
    public static class ComponentExtensions
    {
        public static T AddComponent<T>(this Component component)
            where T : Component
        {
            return component.gameObject.AddComponent<T>();
        }

        public static T GetOrAddComponent<T>(this Component component)
            where T : Component
        {
            if (!component.TryGetComponent<T>(out var attachedComponent))
            {
                attachedComponent = component.AddComponent<T>();
            }

            return attachedComponent;
        }

        public static bool HasComponent<T>(this Component component)
            where T : Component
        {
            return component.TryGetComponent<T>(out _);
        }

        public static void DestroyComponent<T>(this Component component)
            where T : Component
        {
            if (component.TryGetComponent<T>(out var componentToDestroy))
            {
                Object.Destroy(componentToDestroy);
            }
        }
    }
}
