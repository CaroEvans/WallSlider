using System;
using System.Linq;
using UnityEngine;

namespace Values
{
    [Serializable]
    public class ChainedCurves
    {
        [SerializeField]
        private AnimationCurve[] _curves;

        public ChainedCurves()
        {
        }

        public ChainedCurves(params AnimationCurve[] curves)
        {
            _curves = curves;
        }

        public float Evaluate (float time)
        {
            return SelectCurve(time).Evaluate(time);
        }

        // TODO: Refactor to use reducer.
        private AnimationCurve SelectCurve (float time)
        {
            float totalDistance = 0;
            for (int i = 0; i < _curves.Length - 1; i++)
            {
                var curve = _curves[i];
                totalDistance += curve.keys[curve.length - 1].time;
                if (time <= totalDistance)
                    return curve;
            }
            return _curves[_curves.Length - 1];
        }
    }
}

