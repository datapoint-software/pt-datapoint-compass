using Datapoint.AspNetCore;
using System.Diagnostics.CodeAnalysis;

namespace Datapoint.Compass
{
    internal static class Assert
    {
        internal static void Found<T>([NotNull] T value)
        {
            if (value is null)
                throw new BusinessException($"An entity was not found.")
                    .AddName("missing");
        }
    }
}
