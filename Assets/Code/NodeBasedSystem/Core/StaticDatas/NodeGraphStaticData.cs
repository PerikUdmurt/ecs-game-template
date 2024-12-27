using UnityEngine;

[CreateAssetMenu(fileName = "NodeGraphStaticData", menuName = "NodeSystem/NodeGraphStaticData")]
public class NodeGraphStaticData : ScriptableObject
{
    public string Id;
    public string Json;

    public NodeGraphStaticData(string json)
    {
        Json = json;
    }
}
