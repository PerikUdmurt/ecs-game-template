using Code.Common.UnityStructs;
using UnityEngine;

namespace Code.Common.Extensions
{
    public static class Vector2DataExtensions
    {
        public static Vector2Data ToVector2Data(this Vector2 vector)
            => new Vector2Data(vector.x, vector.y);

        public static Vector2 ToVector2(this Vector2Data vector)
            => new Vector2(vector.X, vector.Y); 
    }
}
