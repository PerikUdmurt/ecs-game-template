using Code.NodeBasedSystem.GraphLoaders;
using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.NodeBasedSystem.GraphPlayer
{
    public class NodeGraphPlayer : IGraphPlayer
    {
        private readonly NodeSystemContext _context;
        private readonly IGraphLoader _graphLoader;
        private readonly string _graphID;
        private IEnumerable<NodeSystemEntity> _targetGraphGroup;

        public NodeGraphPlayer(NodeSystemContext context, IGraphLoader graphLoader, string graphId) 
        {
            _graphID = graphId;
            _context = context;
            _graphLoader = graphLoader;
        }

        public void StartGraph(string staticDataId)
        {
            ReleaseGraph();

            _graphLoader.LoadGraph(staticDataId, _graphID);
            
            _targetGraphGroup = FindTargetGraph();

            NodeSystemEntity startNode = _targetGraphGroup
                .FirstOrDefault(entity => entity.isStartNode);

            if (startNode == null)
            {
                Debug.LogError($"[NODE_GRAPH_PLAYER] the starting node was not found in the graph {_graphID} with staticDataID = {staticDataId}");
                return;
            }

            PlayNode(startNode.nodeId.Value);
        }

        private IEnumerable<NodeSystemEntity> FindTargetGraph()
        {
            IGroup<NodeSystemEntity> allNodes =
                            _context.GetGroup(NodeSystemMatcher.AllOf(
                            NodeSystemMatcher.GraphID,
                            NodeSystemMatcher.NodeId));

            return allNodes
                .GetEntities()
                .Where(entity => entity.graphID.Value == _graphID);
        }

        private void ReleaseGraph()
        {
            List<NodeSystemEntity> group = FindTargetGraph().ToList();

            for (int i = 0; i < group.Count(); i++)
            {
                group[i].Destroy();
            }
        }

        public void PlayNode(string nodeId)
        {
            UnmarkAllNodes();
            MarkTargetNode(nodeId);
        }

        private void MarkTargetNode(string nodeId)
        {
            NodeSystemEntity targetNode = _targetGraphGroup
                .FirstOrDefault(node => node.nodeId.Value == nodeId);

            if (targetNode == null)
            {
                Debug.LogError($"[NODE_GRAPH_PLAYER] the node with id = {nodeId} was not found in the graph {_graphID}");
                return;
            }

            targetNode.isPlaying = true;
            targetNode.isPlayed = true;
        }

        private void UnmarkAllNodes()
        {
            foreach (NodeSystemEntity node in _targetGraphGroup)
            {
                if (node.isPlaying == true)
                    node.isPlaying = false;
            }
        }
    }

    public interface IGraphPlayer
    {
        void PlayNode(string nodeId);
        void StartGraph(string graphId);
    }
}