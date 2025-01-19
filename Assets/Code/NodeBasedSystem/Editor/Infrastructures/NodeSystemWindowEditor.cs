using Code.NodeBasedSystem.Core.StaticDatas;
using NodeBasedEditor.SaveLoadUtility;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace NodeBasedEditor.Editors
{
    public class NodeSystemWindowEditor : EditorWindow
    {
        private const string TitleContentText = "Dialogue System";
        private NodeGraphView _graphView;
        private static NodeGraphStaticData _staticData;

        public static void Open()
        {
            NodeSystemWindowEditor wnd = GetWindow<NodeSystemWindowEditor>();
            wnd.titleContent = new GUIContent(TitleContentText);
        }
        
        public static void Open(NodeGraphStaticData staticData)
        {
            _staticData = staticData;
            Open();
        }

        private void CreateGUI()
        {
            _graphView = UIElementUtility.AddGraphView();
            Toolbar toolbar = UIElementUtility.AddToolbar();

            rootVisualElement.Add(_graphView);
            rootVisualElement.Add(toolbar);
            AddStyles();
            SaveLoadGraphUtility.Load(_staticData, _graphView);
        }

        private void OnDisable()
        {
            SaveLoadGraphUtility.Save(_graphView);
        }

        private void AddStyles()
        {
            rootVisualElement.AddStylesByPath("Variables.uss");
            rootVisualElement.AddStylesByPath("NodeStyles.uss");
        }
    }
}