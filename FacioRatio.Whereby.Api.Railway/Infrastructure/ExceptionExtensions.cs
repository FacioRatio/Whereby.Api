using System.Runtime.ExceptionServices;

namespace FacioRatio.Whereby.Api
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Rethrow an exception, preserving the stack trace.
        /// </summary>
        /// <param name="ex"></param>
        public static void Rethrow(this Exception ex)
        {
            ExceptionDispatchInfo.Capture(ex).Throw();
        }
    }
}
