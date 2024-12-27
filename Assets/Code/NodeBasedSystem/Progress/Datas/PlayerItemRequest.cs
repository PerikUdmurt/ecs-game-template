using System;
using UnityEngine;

namespace Code.NodeBasedSystem.Progress.Datas
{
    [Serializable]
    public class PlayerItemRequest: CustomEventData
    {
        public EPlayerItem resource;
        public int amount;
    }

    public abstract class CustomEventData { }
}