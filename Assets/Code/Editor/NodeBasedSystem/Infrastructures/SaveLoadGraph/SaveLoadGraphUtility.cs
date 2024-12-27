using Code.Common.Extensions;
using Code.NodeBasedSystem.Core.Conditions;
using Code.NodeBasedSystem.GraphLoaders;
using NodeBasedEditor.Editors;
using NodeBasedEditor.Editors.Nodes;
using NodeBasedSystem.Editor.Extensions;
using NodeBasedSystem.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Node = NodeBasedSystem.Nodes.Node;

namespace NodeBasedEditor.SaveLoadUtility
{
    //TODO: Christa radi, refactor this nechistivy code
    public static class SaveLoadGraphUtility
    {
        private static EditorNodeFactory _nodeFactory;
        private static NodeGraphView _graphView;
        private static NodeGraphStaticData _nodeGraphStaticData;

        static SaveLoadGraphUtility()
        {
            _nodeFactory = new EditorNodeFactory();
        }
        
        public static void Load(NodeGraphStaticData graphData, NodeGraphView nodeGraphView)
        {
            _graphView = nodeGraphView;
            _nodeGraphStaticData = graphData;
            NodeGraphSavedData data = graphData.Json.FromJson<NodeGraphSavedData>();
            CreateEditorNodesFromData(data);
            RestoreConnections(data);
        }

        private static void RestoreConnections(NodeGraphSavedData data)
        {
            var allNodes = _graphView.GetNodes<BaseNode>();
            foreach (NodeEntitySnapshot node in data.nodeSnapshots)
            {
                NextNodes nextNodes = node.FindComponent<NextNodes>();
                NodeId nodeId = node.FindComponent<NodeId>();
                BaseNode startNode = allNodes.FirstOrDefault(n => n.ID == nodeId.Value);
                Debug.Log($"{startNode.ID} {nextNodes.Value.Count}");

                for (int i = 0; i < nextNodes.Value.Count; i++)
                {
                    var nextNodeId = nextNodes.Value[i].NodeId;
                    BaseNode endNode = allNodes.FirstOrDefault(n => n.ID == nextNodeId);
                    UnityEditor.Experimental.GraphView.Edge connection = startNode.OutputPorts[i].Port.ConnectTo(endNode.InputPorts[0]);
                    _graphView.AddElement(connection);
                }
            }
        }

        private static void CreateEditorNodesFromData(NodeGraphSavedData data)
        {
            var simpleNodes = data.GetNodesWithType(ENodeType.Simple);
            foreach (NodeEntitySnapshot node in simpleNodes)
            {
                Vector2 position = node.FindComponent<NodePosition>().Value.ToVector2();
                string id = node.FindComponent<NodeId>().Value;
                List<INodeEventComponent> events = node.FindComponents<INodeEventComponent>().ToList();
                
                SimpleNode editorNode = _nodeFactory.CreateSimpleNode(position, events, id);
                _graphView.AddElement(editorNode);
            }
            
            var choiceNodes = data.GetNodesWithType(ENodeType.Choices);
            foreach (NodeEntitySnapshot node in choiceNodes)
            {
                Vector2 position = node.FindComponent<NodePosition>().Value.ToVector2();
                string id = node.FindComponent<NodeId>().Value;
                List<INodeEventComponent> events = node.FindComponents<INodeEventComponent>().ToList();
                NextNodes nextNodes = node.FindComponent<NextNodes>();

                List<ChoiceNodePortContent> contents = new List<ChoiceNodePortContent>();
                foreach (ConditionedNode nextNode in nextNodes.Value)
                {
                    ChoiceNodePortContent content = new("", nextNode.Conditions.ToArray());
                    contents.Add(content);
                }
                
                ChoiceNode editorNode = _nodeFactory.CreateChoiceNode(position, contents ,events, id);
                
                _graphView.AddElement(editorNode);
            }
            
            var conditionNodes = data.GetNodesWithType(ENodeType.Conditional);
            foreach (NodeEntitySnapshot node in conditionNodes)
            {
                Vector2 position = node.FindComponent<NodePosition>().Value.ToVector2();
                string id = node.FindComponent<NodeId>().Value;
                List<INodeEventComponent> events = node.FindComponents<INodeEventComponent>().ToList();
                NextNodes nextNodes = node.FindComponent<NextNodes>();
                
                List<ConditionNodePortContent> contents = new();
                foreach (ConditionedNode nextNode in nextNodes.Value)
                {
                    ConditionNodePortContent content = new(nextNode.Conditions.ToArray());
                    contents.Add(content);
                }
                
                ConditionNode editorNode = _nodeFactory.CreateConditionNode(position, contents ,events, id);
                
                _graphView.AddElement(editorNode);
            }
        }

        public static void Save(NodeGraphView nodeGraphView)
        {
            NodeGraphSavedData data = new NodeGraphSavedData();
            WriteNodesToData(data);
            _nodeGraphStaticData.Json = data.ToJson();
        }
        
        private static void WriteNodesToData(NodeGraphSavedData data)
        {
            List<SimpleNode> simpleNodes = _graphView.GetNodes<SimpleNode>();

            foreach (SimpleNode node in simpleNodes)
            {
                NodeEntitySnapshot entity = new NodeEntitySnapshot();

                foreach (var component in node.Events)
                {
                    DebugComponent(component);
                    entity.components.Add(component);
                }

                entity.components.Add(new NodeId() {Value = node.ID});
                entity.components.Add(new NodePosition() {Value = node.GetPosition().position.ToVector2Data()});
                entity.components.Add(new Node() {Value = ENodeType.Simple});
                entity.components.Add(new NextNodes() {Value = GetNextNodesForSimpleNode(node)});
                data.nodeSnapshots.Add(entity);
            }
            
            List<ChoiceNode> choiceNodes = _graphView.GetNodes<ChoiceNode>();
            
            foreach (ChoiceNode node in choiceNodes)
            {
                NodeEntitySnapshot entity = new NodeEntitySnapshot();

                foreach (var component in node.Events)
                {
                    entity.components.Add(component);
                }
                
                entity.components.Add(new NodeId() {Value = node.ID});
                entity.components.Add(new NodePosition() {Value = node.GetPosition().position.ToVector2Data()});
                entity.components.Add(new Node() {Value = ENodeType.Choices});
                entity.components.Add(new NextNodes() {Value = GetNextNodesForChoiceNode(node)});
                data.nodeSnapshots.Add(entity);
            }
            
            List<ConditionNode> conditionNodes = _graphView.GetNodes<ConditionNode>();
            
            foreach (ConditionNode node in conditionNodes)
            {
                NodeEntitySnapshot entity = new NodeEntitySnapshot();

                foreach (var component in node.Events)
                {
                    entity.components.Add(component);
                }
                
                entity.components.Add(new NodeId() {Value = node.ID});
                entity.components.Add(new NodePosition() {Value = node.GetPosition().position.ToVector2Data()});
                entity.components.Add(new Node() {Value = ENodeType.Conditional});
                entity.components.Add(new NextNodes() {Value = GetNextNodesForConditionNode(node)});
                data.nodeSnapshots.Add(entity);
            }
        }

        private static void DebugComponent(object component)
        {
            Type type = component.GetType();
            FieldInfo[] fields = type.GetFields();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Saved component {type.Name}");
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsStruct())
                {
                    DebugComponent(field.GetValue(component));
                }
                stringBuilder.AppendLine($"{field.Name} {field.GetValue(component)}");
            }
            Debug.Log(stringBuilder.ToString());
        }

        private static List<ConditionedNode> GetNextNodesForChoiceNode(ChoiceNode node)
        {
            List<ConditionedNode> nextNodes = new List<ConditionedNode>();
            
            foreach (CustomPort<ChoiceNodePortContent> port in node.OutputPorts)
            {
                UnityEditor.Experimental.GraphView.Edge connection = port.Port.connections.FirstOrDefault();
                
                if (connection == null)
                    continue;
                
                BaseNode nextNode = connection.input.node as BaseNode;
                nextNodes.Add(new (nextNode.ID, port.Content.Conditions.ToArray()));
            }
            
            return nextNodes;
        }
        
        private static List<ConditionedNode> GetNextNodesForConditionNode(ConditionNode node)
        {
            List<ConditionedNode> nextNodes = new List<ConditionedNode>();
            
            foreach (CustomPort<ConditionNodePortContent> port in node.OutputPorts)
            {
                UnityEditor.Experimental.GraphView.Edge connection = port.Port.connections.FirstOrDefault();
                
                if (connection == null)
                    continue;
                
                BaseNode nextNode = connection.input.node as BaseNode;
                nextNodes.Add(new (nextNode.ID, port.Content.Conditions.ToArray()));
            }
            
            return nextNodes;
        }

        private static List<ConditionedNode> GetNextNodesForSimpleNode(SimpleNode node)
        {
            UnityEditor.Experimental.GraphView.Edge connection = node.OutputPorts.First().Port.connections.FirstOrDefault();
            
            if (connection == null)
            {
                return new List<ConditionedNode>();
            }

            BaseNode nextnode = connection.input.node as BaseNode;
            return new List<ConditionedNode>() { new(nextnode.ID) };
        }
    }
}