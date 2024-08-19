using System;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Helpers
{
    internal static class EnumerableHelper
    {
        internal static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> fn)
        {
            var index = 0;

            foreach (var item in enumerable)
                fn(item, index++);
        }
    }
}
