using System;
using System.Diagnostics.CodeAnalysis;

namespace Datapoint.Compass.Middleware
{
    internal static class Assert
    {
        internal static void Found<T>([NotNull] T? entity) where T : class
        {
            if (entity is null)
                throw new BusinessException("Entity was not found.");
        }

        internal static void NotNull<T>([NotNull] T? value)
        {
            if (value is null)
                throw new InvalidOperationException("Property is not set and can not be empty.");
        }
        internal static void RowVersionId(Guid subjectRowVersionId, Guid targetRowVersionId)
        {
            if (!subjectRowVersionId.Equals(targetRowVersionId))
                throw new BusinessException("Row version identifier mismatch.");
        }
    }
}
