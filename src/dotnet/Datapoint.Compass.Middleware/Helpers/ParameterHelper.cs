using Datapoint.Compass.EntityFrameworkCore.Entities;
using System.Collections.Generic;
using System.Text.Json;

namespace Datapoint.Compass.Middleware.Helpers
{
    internal static class ParameterHelper
    {
        internal static T GetValueOf<T>(this IDictionary<string, Parameter> parameters, string parameterName) =>

            JsonSerializer.Deserialize<T>(parameters[parameterName].JsonValue)!;

        internal static bool TryGetValueOf<T>(this IDictionary<string, Parameter> parameters, string parameterName, out T value)
        {
            if (!parameters.TryGetValue(parameterName, out var parameter))
            {
                value = default!;
                return false;
            }

            value = JsonSerializer.Deserialize<T>(parameter.JsonValue)!;
            return true;
        }
    }
}
