using ObjectFactories;
using System.Collections.Generic;
using UnityEngine;

namespace Chutes
{
    public class ChuteBackgroundDecorator : Chute
    {
        private readonly Chute _chute;
        private readonly IObjectFactory _backgroundFactory;

        public ChuteBackgroundDecorator(Chute chute, IObjectFactory backgroundFactory)
        {
            _chute = chute;
            _backgroundFactory = backgroundFactory;
        }

        public override IEnumerable<RectInt> From(RectInt origin)
        {
            foreach(var chunk in _chute.From(origin))
            {
                _backgroundFactory.Create(chunk.center);
                yield return chunk;
            }
        }
    }
}
