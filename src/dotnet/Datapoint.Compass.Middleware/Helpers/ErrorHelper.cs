using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware.Helpers
{
    internal static class ErrorHelper
    {
        internal static Task AddWhenAsync(this List<Error> errors, string name, string propertyName, Func<Task<bool>> fn) =>

            AddWhenAsync(errors, name, propertyName, fn.Invoke());

        internal static async Task AddWhenAsync(this List<Error> errors, string name, string propertyName, Task<bool> fn)
        {
            if (await fn)
                errors.Add(new Error(name, propertyName, null));
        }
    }
}
