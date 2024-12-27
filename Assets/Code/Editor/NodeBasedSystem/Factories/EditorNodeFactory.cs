using System.Collections.Generic;
using NodeBasedEditor.Editors.Nodes;
using NodeBasedSystem.Nodes;
using UnityEngine;
using UnityEngine.UIElements;
using ChoiceNodePortContent = NodeBasedEditor.Editors.Nodes.ChoiceNodePortContent;

namespace NodeBasedEditor.Editors
{
    public class EditorNodeFactory
    {
        private readonly NodeGraphView _graphView;
        
        public SimpleNode CreateSimpleNode(Vector2 position, List<INodeEventComponent> events = null, string id = null)
        {
            return CreateNode<SimpleNode, VisualElement>(position, new() { new VisualElement() }, events, id);
        }

        public ChoiceNode CreateChoiceNode(Vector2 position, List<ChoiceNodePortContent> ports = null,List<INodeEventComponent> events = null, string id = null)
        {
            return CreateNode<ChoiceNode, ChoiceNodePortContent>(position, ports, events, id);
        }

        public ConditionNode CreateConditionNode(Vector2 position, List<ConditionNodePortContent> ports = null, List<INodeEventComponent> events = null, string id = null)
        {
            return CreateNode<ConditionNode, ConditionNodePortContent>(position, ports, events, id);
        }
        
        public TNode CreateNode<TNode, TPortContent>(Vector2 position, List<TPortContent> portContents = null, List<INodeEventComponent> events = null, string id = null) 
            where TNode : BaseEditorNode<TPortContent>, new() 
            where TPortContent: VisualElement
        {
            TNode node = new();
            node.Initialize(position, portContents, events, id);
            node.Draw();

            return node;
        }
    }
}