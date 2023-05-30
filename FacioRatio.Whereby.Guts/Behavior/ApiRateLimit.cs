using System.Net.Http.Headers;

namespace FacioRatio.Whereby.Api
{
    internal class ApiRateLimit
    {
        //public int Limit { get; private set; }
        //public int Remaining { get; private set; }
        public int Reset { get; private set; }

        public ApiRateLimit(int Reset)
        {
            this.Reset = Reset;
        }

        //public ApiRateLimit(int Limit, int Remaining, int Reset)
        //{
        //    this.Limit = Limit;
        //    this.Remaining = Remaining;
        //    this.Reset = Reset;
        //}

        public static ApiRateLimit New(HttpResponseHeaders Headers)
        {
            if (Headers.RetryAfter == null)
                return null;

            var retryAfterSeconds = (int)Headers.RetryAfter.Delta?.TotalSeconds;
            return new ApiRateLimit(retryAfterSeconds);

            //if (!headers.AllKeys.Any(x => x.StartsWith("X-RateLimit")))
            //    return null;

            //int limit = Headers["X-RateLimit-Limit"].ToInt();
            //int remaining = Headers["X-RateLimit-Remaining"].ToInt();
            //int reset = Headers["X-RateLimit-Reset"].ToInt();
            //return new ApiRateLimit(limit, remaining, reset);
        }
    }
}
