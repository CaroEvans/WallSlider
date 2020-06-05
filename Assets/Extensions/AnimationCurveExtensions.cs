using UnityEngine;

namespace ExtensionMethods
{
    public static class AnimationCurveExtensions
    {
        public static int Identity (this AnimationCurve curve)
        {
            float sample = 0;
            float step = 1f / 37f;
            for (float i = 0; i < 1; i = i + step)
                sample += curve.Evaluate(i);
            return Mathf.RoundToInt(sample * 31993);
        }
    }
}

