namespace Code.NodeBasedSystem
{
    public interface INodeSystem
    {
        void PlayGraph(string graphId);
        void PlayGraph(string graphId, string identifier);
        void ClearAllGraphs();
    }
}