namespace Code.NodeBasedSystem.GraphPlayer
{
    public interface IGraphPlayer
    {
        void PlayNode(string nodeId);
        void StartGraph(string graphId);
        void PlayNextNode();
        void Release();
    }
}