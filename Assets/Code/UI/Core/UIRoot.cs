using System;
using UnityEngine;

namespace Code.UI.Core
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private SerializableDictionary<EUILayerType, Transform> _layerParents;

        public Transform GetLayerTransform(EUILayerType layer)
        {
            if (_layerParents.TryGetValue(layer, out var result))
            {
                return result;
            }

            throw new Exception($"[UI_ROOT] UI Layer Type {layer} not found in dictionary.");
        }
    }
}