using System.Collections.Generic;
using Code.Infrastructure.Identifiers;
using Code.NodeBasedSystem.Core.Conditions;
using Code.NodeBasedSystem.Core.NodeGraphPlayer;
using Code.NodeBasedSystem.GraphLoaders;
using Code.NodeBasedSystem.GraphPlayer;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem
{
    [UsedImplicitly]
    public class NodeSystem : INodeSystem
    {
        private readonly NodeSystemContext _context;
        private readonly IGraphLoader _graphLoader;
        private readonly INodeConditionVerifyService _verifier;
        private readonly IIdentifierService _identifierService; //TODO: create identifier service only for NodeSystem
        private readonly Dictionary<string, IGraphPlayer> _graphPlayers;

        public NodeSystem(
            IGraphLoader graphLoader,
            INodeConditionVerifyService verifier, 
            NodeSystemContext context, 
            IIdentifierService identifierService)
        {
            _graphLoader = graphLoader;
            _verifier = verifier;
            _context = context;
            _identifierService = identifierService;
            _graphPlayers = new();
        }

        public void PlayGraph(string graphId)
        {
            string id = $"Default Graph Player {_identifierService.Next()}";
            PlayGraph(graphId, id);
        }

        public void PlayGraph(string graphId, string identifier)
        {
            IGraphPlayer graphPlayer = new NodeGraphPlayer(_context, _verifier, _graphLoader, graphId);
            graphPlayer.StartGraph(graphId);
            _graphPlayers.Add(identifier, graphPlayer);
        }

        public void ClearAllGraphs()
        {
            foreach (IGraphPlayer player in _graphPlayers.Values)
            {
                player.Release();
            }
            _graphPlayers.Clear();
        }
    }
}