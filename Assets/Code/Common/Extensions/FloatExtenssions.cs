using System;
using UnityEngine;

namespace Extensions
{
    public static class FloatExtenssions
    {
        public static float RandomBias(this float value, float range, bool useNegativeBiase = true)
        {
            return (
                value + (value * UnityEngine.Random.Range(useNegativeBiase ? -range : 0, range))
            );
        }

        public static float Round(this float value, int digits = 0)
        {
            return (float)Math.Round(value, digits);
        }

        public static bool IsApproximatelyEqual(
            this float value,
            float other,
            float tolerance = 0.0001f
        )
        {
            return Math.Abs(value - other) < tolerance;
        }

        public static float ToPercentage(this float value, float total)
        {
            return (value / total) * 100f;
        }

        public static bool IsInRange(this float value, float minValue, float maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        public static float ClosestInRange(this float value, float minValue, float maxValue)
        {
            if (value.IsInRange(minValue, maxValue))
                return value;

            float diffrenceToMinValue = Mathf.Abs(value - minValue);
            float diffrenceToMaxValue = Mathf.Abs(value - maxValue);

            return MathF.Min(diffrenceToMinValue, diffrenceToMaxValue);
        }

        public static float Max(this float value, float max) => value <= max ? value : max;

        public static float Min(this float value, float min) => value <= min ? min : value;

        public static float Clamp(this float value, float min, float max) =>
            Mathf.Clamp(value, min, max);

        public static float Lerp(this float current, float target, float t) =>
            Mathf.Lerp(current, target, Mathf.Clamp01(t));

        public static float LerpUnclamped(this float current, float target, float t) =>
            Mathf.LerpUnclamped(current, target, t);

        public static float MoveTowards(this float current, float target, float maxDelta)
        {
            return Mathf.MoveTowards(current, target, maxDelta);
        }
    }
}
