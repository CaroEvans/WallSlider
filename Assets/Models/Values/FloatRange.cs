using UnityEngine;

namespace Values
{
    public class FloatRange : Range<float>
    {
        private readonly float _min, _max;

        public FloatRange(float min, float max)
        {
            _min = min;
            _max = max;
        }

        public override float FromNormal(float normal)
        {
            return Mathf.Lerp(_min, _max, normal);
        }
    }
}
