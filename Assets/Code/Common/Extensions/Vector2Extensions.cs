using UnityEngine;

namespace Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 WithX(this Vector2 vector, float x)
        {
            return new Vector2(x, vector.y);
        }

        public static Vector2 WithY(this Vector2 vector, float y)
        {
            return new Vector2(vector.x, y);
        }

        public static Vector2 SetMagnitude(this Vector2 vector, float magnitude)
        {
            return vector.normalized * magnitude;
        }

        public static Vector2 WithAddX(this Vector2 v, float x) => new Vector2(v.x + x, v.y);

        public static Vector2 WithSubtractX(this Vector2 v, float x) => new Vector2(v.x - x, v.y);

        public static Vector2 WithMultiplyX(this Vector2 v, float x) => new Vector2(v.x * x, v.y);

        public static Vector2 WithAddY(this Vector2 v, float y) => new Vector2(v.x, v.y + y);

        public static Vector2 WithSubtractY(this Vector2 v, float y) => new Vector2(v.x, v.y - y);

        public static Vector2 WithMultiplyY(this Vector2 v, float y) => new Vector2(v.x, v.y * y);

        public static Vector2 Clamp(this Vector2 value, Vector2 min, Vector2 max) =>
            new Vector2(Mathf.Clamp(value.x, min.x, max.x), Mathf.Clamp(value.y, min.y, max.y));

        public static Vector2 ClampMagnitude(this Vector2 vector, float maxLength) =>
            Vector2.ClampMagnitude(vector, maxLength);

        public static Vector2 Lerp(this Vector2 current, Vector2 target, float t) =>
            Vector2.Lerp(current, target, Mathf.Clamp01(t));

        public static Vector2 LerpUnclamped(this Vector2 current, Vector2 target, float t) =>
            Vector2.LerpUnclamped(current, target, t);

        public static Vector2 MoveTowards(this Vector2 current, Vector2 target, float maxDelta) =>
            Vector2.MoveTowards(current, target, maxDelta);

        public static Vector2 Max(this Vector2 a, Vector2 b) =>
            new Vector2(Mathf.Max(a.x, b.x), Mathf.Max(a.y, b.y));

        public static Vector2 Min(this Vector2 a, Vector2 b) =>
            new Vector2(Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y));

        public static Vector2 WithRandomBias(this Vector2 v, float biasValue) =>
            new Vector2(v.x.RandomBias(biasValue), v.y.RandomBias(biasValue));

        public static Vector2 WithRandomBias(this Vector2 v, Vector2 biasValue) =>
            new Vector2(v.x.RandomBias(biasValue.x), v.y.RandomBias(biasValue.y));
        
        public static Vector3 ToX0Y(this Vector2 v) => new Vector3(v.x, 0, v.y);
    }
}
