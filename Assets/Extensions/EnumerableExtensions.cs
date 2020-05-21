using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Cycle<TSource, TResult>(this IEnumerable<TSource> source, params Func<TSource, TResult>[] selectors)
        {
            int selectorIndex = 0;
            return source.Select((item) =>
            {
                selectorIndex = selectorIndex % selectors.Length;
                return selectors[selectorIndex++].Invoke(item);
            });
        }
    }
}