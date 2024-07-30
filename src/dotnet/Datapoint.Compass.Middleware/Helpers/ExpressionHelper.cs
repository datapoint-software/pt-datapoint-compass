using System;

namespace Datapoint.Compass.Middleware.Helpers
{
    internal static class ExpressionHelper
    {
        internal static string CreateLikePatternExpression(string searchExpression) =>
            $"%{string.Join('%', searchExpression.Split(' ', StringSplitOptions.RemoveEmptyEntries))}%";
    }
}
