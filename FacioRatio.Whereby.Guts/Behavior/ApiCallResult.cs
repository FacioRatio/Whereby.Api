using ServiceStack;
using System.Net;

namespace FacioRatio.Whereby.Api
{
    internal class ApiCallResult<TResult>
    {
        public HttpStatusCode HttpStatusCode { get; private set; }
        public string Body { get; private set; }
        public ApiRateLimit ApiRateLimit { get; private set; }
        public TResult Value { get; private set; }

        public bool Ok
        {
            get
            {
                return HttpStatusCode == HttpStatusCode.OK || HttpStatusCode == HttpStatusCode.Accepted || HttpStatusCode == HttpStatusCode.Created || HttpStatusCode == HttpStatusCode.NoContent;
            }
        }

        public bool AtLimit
        {
            get
            {
                //return ApiRateLimit != null && ApiRateLimit.Remaining <= 0;
                return ApiRateLimit != null && ApiRateLimit.Reset > 0;
            }
        }

        public bool HasValue
        {
            get
            {
                return !EqualityComparer<TResult>.Default.Equals(Value);
            }
        }

        public ApiCallResult(HttpStatusCode HttpStatusCode, string Body, ApiRateLimit ApiRateLimit = null)
        {
            this.HttpStatusCode = HttpStatusCode;
            this.Body = Body;
            this.ApiRateLimit = ApiRateLimit;
            this.Value = Ok ? Body.FromJson<TResult>() : default;
        }
    }

    public sealed class ApiCallResult
    {
        internal static async Task<ApiCallResult<T>> New<T>(WebException ex)
        {
            if (ex.Response == null)
                return new ApiCallResult<T>(HttpStatusCode.InternalServerError, $"Exception has no Response. Message: {ex.Message}", null);

            using var reader = new StreamReader(ex.Response.GetResponseStream());
            var body = await reader.ReadToEndAsync();
            var statusCode = ex.Response is HttpWebResponse webResponse ? webResponse.StatusCode : HttpStatusCode.InternalServerError;

            return new ApiCallResult<T>(statusCode, body, null);
        }
    }
}

//Status Code Description
//200	OK - The request was successful(some API calls may return 201 instead).
//201	Created - The request was successful and a resource was created.
//204	No Content - The request was successful but there is no representation to return (that is, the response is empty).
//400	Bad Request - The request could not be understood or was missing required parameters.
//401	Unauthorized - Authentication failed or user does not have permissions for the requested operation.
//403	Forbidden - Access denied.
//404	Not Found - Resource was not found.
//405	Method Not Allowed - Requested method is not supported for the specified resource.
//429	Too Many Requests - Exceeded API limits. When the limit is reached, your application should stop making requests until X-RateLimit-Reset seconds have elapsed.
//500	Internal Server Error - Encountered an error.