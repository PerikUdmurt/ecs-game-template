using UnityEditor.Experimental.GraphView;

namespace NodeBasedEditor.Editors.Nodes
{
    public class ConditionNode : BaseEditorNode<ConditionNodePortContent>
    {
        protected override string nodeName { get => "ConditionNode"; }

        public override void Draw()
        {
            base.Draw();
            CreatePort("Input",Direction.Input,Port.Capacity.Multi,null);
            this.CreateContextualMenu("AddChoice", actionEvent => CreatePort("Output",Direction.Output,Port.Capacity.Single,new()));
            RefreshExpandedState();
        }

        private protected override void AddOutputPort(CustomPort<ConditionNodePortContent> port)
        {
            base.AddOutputPort(port);
            port.CreateContextualMenu("RemoveCondition", actionEvent => RemoveChoicePort(port));
        }

        private void RemoveChoicePort(CustomPort<ConditionNodePortContent> port)
        {
            outputContainer.Remove(port);
            OutputPorts.Remove(port);
        }
    }
}