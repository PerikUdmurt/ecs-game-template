namespace Code.NodeBasedSystem.GraphLoaders
{
    public interface IGraphLoader
    {
        void LoadGraph(string staticDataId, string graphID);
    }
}