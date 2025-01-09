using UnityEditor.Experimental.GraphView;

namespace NodeBasedEditor.Editors.Nodes
{
    public class ChoiceNode : BaseEditorNode<ChoiceNodePortContent>
    {
        protected override string nodeName { get => "ChoiceNode"; }

        public override void Draw()
        {
            base.Draw();
            CreatePort("Input",Direction.Input,Port.Capacity.Multi,null);
            this.CreateContextualMenu("AddChoice", actionEvent => CreatePort("Output",Direction.Output,Port.Capacity.Single,new(new())));
            RefreshExpandedState();
        }

        private protected override void AddOutputPort(CustomPort<ChoiceNodePortContent> port)
        {
            base.AddOutputPort(port);
            port.CreateContextualMenu("RemoveChoice", actionEvent => RemoveChoicePort(port));
        }

        private void RemoveChoicePort(CustomPort<ChoiceNodePortContent> port)
        {
            outputContainer.Remove(port);
            OutputPorts.Remove(port);
        }
    }
}