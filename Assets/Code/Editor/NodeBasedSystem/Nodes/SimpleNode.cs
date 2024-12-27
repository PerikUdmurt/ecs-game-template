using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace NodeBasedEditor.Editors.Nodes
{
    public class SimpleNode : BaseEditorNode<VisualElement>
    {
        protected override string nodeName { get => "Node"; }

        public override void Draw()
        {
            base.Draw();
            CreatePort("Input",Direction.Input,Port.Capacity.Multi,null);
        }
    }
}