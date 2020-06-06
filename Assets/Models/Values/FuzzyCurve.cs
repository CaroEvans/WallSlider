using System;

namespace Values
{
    public class FuzzyCurve : Curve
    {
        private readonly Curve _curve;
        private readonly Random _random;
        private readonly Range<float> _offset;

        public FuzzyCurve(Curve curve, Random random, Range<float> offset)
        {
            _curve = curve;
            _random = random;
            _offset = offset;
        }

        public override float Evaluate(float time)
        {
            return _curve.Evaluate(time) + _offset.FromNormal((float)_random.NextDouble());
        }
    }
}