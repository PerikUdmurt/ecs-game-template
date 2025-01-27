namespace Code.NodeBasedSystem.Core.NodeSystemEntities
{
    public static class CreateNodeSystemEntity
    {
        public static NodeSystemEntity Empty() =>
            Contexts.sharedInstance.nodeSystem.CreateEntity();
        
        public static NodeSystemEntity LocalTokenStorage(string graphPlayerID) =>
            Contexts.sharedInstance.nodeSystem.CreateEntity()
                .AddLocalProgressTokenStorage(new())
                .AddGraphID(graphPlayerID);
    }
}
