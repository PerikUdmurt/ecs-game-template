using UnityEditor;
using UnityEngine;

namespace NodeBasedEditor.Editors
{
    [CustomEditor(typeof(NodeGraphStaticData))]
    public class NodeGraphStaticDataCustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            if (GUILayout.Button("Open"))
            {
                NodeSystemWindowEditor.Open(target as NodeGraphStaticData);
            }
        }
    }
}