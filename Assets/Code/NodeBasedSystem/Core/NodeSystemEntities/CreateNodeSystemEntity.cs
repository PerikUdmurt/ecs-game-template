namespace Code.NodeBasedSystem.Core.NodeSystemEntities
{
    public static class CreateNodeSystemEntity
    {
        public static NodeSystemEntity Empty() =>
            Contexts.sharedInstance.nodeSystem.CreateEntity();
    
        public static NodeSystemEntity NextNodeRequest() =>
            Contexts.sharedInstance.nodeSystem.CreateEntity();
    }
}
