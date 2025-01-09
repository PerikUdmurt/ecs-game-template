using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace NodeBasedEditor.Editors.Nodes
{
    public class StartNode : BaseEditorNode<VisualElement>
    {
        protected override string nodeName { get => "Start"; }

        public override void Draw()
        {
            DrawTitleContainer();
            CreatePort("Start", Direction.Output, Port.Capacity.Single, null);
            RefreshExpandedState();
        }
    }
}