using UnityEngine;

namespace Code.Common.UnityStructs
{
    public struct Vector2Data
    {
        private float _x;
        private float _y;

        public Vector2Data(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public float X => _x;
        public float Y => _y;
    }
}
