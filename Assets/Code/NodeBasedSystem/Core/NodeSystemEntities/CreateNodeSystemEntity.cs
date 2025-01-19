namespace Code.NodeBasedSystem.Core.NodeSystemEntities
{
    public static class CreateNodeSystemEntity
    {
        public static NodeSystemEntity Empty() =>
            Contexts.sharedInstance.nodeSystem.CreateEntity();
    
        public static NodeSystemEntity NextNodeRequest(string nodeId, string nodePlayerId) =>
            Contexts.sharedInstance.nodeSystem.CreateEntity()
                .AddNextNodeRequest(nodeId)
                .AddNextNodeRequestGraphId(nodePlayerId);
    }
}
