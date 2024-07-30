using System;
using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Helpers
{
    internal static class ExceptionHelper
    {
        internal static Exception AddInnerErrors(this Exception exception, IEnumerable<Error> innerErrors)
        {
            foreach (var innerError in innerErrors)
                exception.AddInnerError(innerError);

            return exception;
        }
    }
}
