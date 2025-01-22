//------------------------------------
//     Find References To Asset
//     Copyright© 2024 OmniShade     
//------------------------------------

using UnityEngine;

/**
 * Demo script of a sample scriptable object.
 **/
namespace FindReferencesToAsset {
    
    [CreateAssetMenu(menuName = "Scriptable Objects/SampleScriptableObject")]
    public class SampleScriptableObject : ScriptableObject {
        public GameObject Prefab;
        public AudioClip Audio;
        public Material Mat;
    }
}
