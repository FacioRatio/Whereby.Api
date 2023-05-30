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

        public async Task<ApiCallResult<TResult>> Invoke(IDto<TResult> Dto)
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

            //switch (Dto.Verb.ToLower())
            //{
            //    case "get":
            //        var qs = Dto.ToQueryString();
            //        url += (String.IsNullOrWhiteSpace(qs) ? "" : ("?" + qs));
            //        call = () =>
            //        {
            //            //return url.GetJsonFromUrl(requestFilter, responseFilter); //this doesn't set the Content-Type!
            //            //var bytes = url.SendBytesToUrl(
            //            //    method: "GET",
            //            //    contentType: "application/json",
            //            //    accept: "*/*",
            //            //    requestFilter: requestFilter,
            //            //    responseFilter: responseFilter);
            //            //return Encoding.Default.GetString(bytes);
            //            return url.GetStringFromUrl("application/json", requestFilter, responseFilter);
            //        };
            //        break;
            //    case "post":
            //        call = () =>
            //        {
            //            var body = JsonObject.Parse(Dto.ToJson());
            //            body.Remove("__type");
            //            body.Remove("Verb");
            //            body.Remove("Endpoint");
            //            var json = body.ToJson();
            //            //return url.PostStringToUrl(json, "application/json", "*/*", requestFilter, responseFilter);
            //            return url.PostJsonToUrl(json, requestFilter, responseFilter);
            //        };
            //        break;
            //    default:
            //        throw new ArgumentException("Only 'get' and 'post' verbs are supported.");
            //}

            try
            {
                string body = await call(requestFilter, responseFilter);
                return new ApiCallResult<TResult>(code, body, limit);
            }
            catch (WebException ex)
            {
                return await ApiCallResult.New<TResult>(ex);
            }
        }
    }
}
