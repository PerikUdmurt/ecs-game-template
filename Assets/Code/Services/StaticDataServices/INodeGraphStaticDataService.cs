namespace Code.Services.StaticDataServices
{
    public interface INodeGraphStaticDataService
    {
        NodeGraphStaticData GetNodeGraph(string staticDataName, out NodeGraphStaticData itemStaticData);
    }
}