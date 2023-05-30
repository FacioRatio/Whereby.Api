using FacioRatio.CSharpRailway;
using System.Net;

namespace FacioRatio.Whereby.Api
{
    internal class ApiCall<TResult> : IApiCall<TResult>
    {
        private readonly IApiCreds ApiCreds;
        private readonly IApiFun<TResult> Fun;

        public ApiCall(IApiCreds ApiCreds, IApiFun<TResult> Fun)
        {
            this.ApiCreds = ApiCreds;
            this.Fun = Fun;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public async Task<Result<ApiCallResult<TResult>>> Invoke(IDto<TResult> Dto)
        {
            HttpStatusCode code = HttpStatusCode.NotImplemented; //default to something that SS isn't supposed to return so that we know the difference
            ApiRateLimit limit = null;

            void requestFilter(HttpRequestMessage x)
            {
                x.Headers.Add("Authorization", "Bearer " + ApiCreds.Token);
            }

            string url = ApiCreds.Host + Fun.Endpoint;

            void responseFilter(HttpResponseMessage x)
            {
                if (x == null)
                    throw new MissingHttpResponseException(url);

                code = x.StatusCode;
                limit = ApiRateLimit.New(x.Headers);
            }

            var call = Fun.Generate(ApiCreds.Host, Dto);

            try
            {
                return await call(requestFilter, responseFilter)
                    .Bind(body => new ApiCallResult<TResult>(code, body, limit));
            }
            catch (WebException ex)
            {
                var result = await ApiCallResult.New<TResult>(ex);
                return Result.Ok(result);
            }
        }
    }
}
