using System;
using UnityEngine;

namespace Code.Gameplay.Features.Cursor
{
    [CreateAssetMenu(fileName = "Cursor Config", menuName = "Configs/Gameplay/Cursor Config")]
    public class CursorConfig : ScriptableObject
    {
        [Serializable]
        public class CursorData
        {
            public Texture2D cursorTexture;
            public Vector2 cursorOffset;
        }
        
        public SerializableDictionary<ECursorType, CursorData> cursors;
    }
}