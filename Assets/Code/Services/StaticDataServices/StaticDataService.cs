using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code.NodeBasedSystem.Core.StaticDatas;
using UnityEngine;

namespace Code.Services.StaticDataServices
{
    public class StaticDataService: IStaticDataService, INodeGraphStaticDataService
    {
        private const string StaticDataPath = "StaticDatas";
        private Dictionary<string, NodeGraphStaticData> _nodeGraphs;

        public void LoadStaticDatas()
        {
            LoadNodeGraphs();
        }

        private void LoadNodeGraphs()
        {
            _nodeGraphs = Resources.LoadAll<NodeGraphStaticData>(StaticDataPath)
                .ToDictionary(x => x.Id, x => x);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[STATIC_DATA_SERVICE] Node graphs loaded. Count: {_nodeGraphs.Count}");
            int index = 0;
            
            foreach (KeyValuePair<string, NodeGraphStaticData> nodeGraph in _nodeGraphs)
            {
                index++;
                sb.AppendLine($"{index} = {nodeGraph.Key}");
            }

            Debug.Log(sb.ToString());
        }

        public NodeGraphStaticData GetNodeGraph(string staticDataName, out NodeGraphStaticData itemStaticData)
        {
            NodeGraphStaticData data = _nodeGraphs.TryGetValue(staticDataName, out NodeGraphStaticData value) ? value : null;
            itemStaticData = data;
            return itemStaticData;
        }
    }
}