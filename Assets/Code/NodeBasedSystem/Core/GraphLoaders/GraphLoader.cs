using System.Collections.Generic;
using System.ComponentModel;
using Code.Common.Extensions;
using Code.Services.StaticDataServices;
using Entitas;
using NodeBasedSystem.Nodes;
using UnityEngine;

namespace Code.NodeBasedSystem.GraphLoaders
{
    public class GraphLoader : IGraphLoader
    {
        private readonly NodeSystemContext _context;
        private readonly INodeGraphStaticDataService _staticDataService;
        
        public GraphLoader(NodeSystemContext context, INodeGraphStaticDataService staticDataService)
        {
            _context = context;
            _staticDataService = staticDataService;
        }

        public void LoadGraph(string staticDataId, string graphID)
        {
            _staticDataService.GetNodeGraph(staticDataId, out NodeGraphStaticData staticData);
            NodeGraphSavedData graphData = staticData.Json.FromJson<NodeGraphSavedData>();
            CreateNodeEntities(graphData.nodeSnapshots, graphID);
            Debug.Log($"[NODE_BASED_SYSTEM]: Loaded graph with id = {graphID}]");
        }
        
        private void CreateNodeEntities(List<NodeEntitySnapshot> entitySnapshots, string graphId)
        {
            foreach (NodeEntitySnapshot snapshot in entitySnapshots)
            {
                _context
                    .CreateEntity()
                    .HydrateWith(snapshot)
                    .AddComponent(NodeSystemComponentsLookup.GraphID, new GraphIDComponent() { Value = graphId});
            }
        }
    }
}
