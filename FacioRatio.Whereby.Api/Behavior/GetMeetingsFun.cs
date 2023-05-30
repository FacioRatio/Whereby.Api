using ServiceStack;

namespace FacioRatio.Whereby.Api
{
    public class GetMeetingsFun : IApiFun<GetMeetingsResponse>
    {
        public string Endpoint => "meetings";

        public Func<Action<HttpRequestMessage>, Action<HttpResponseMessage>, Task<string>> Generate(string Host, IDto<GetMeetingsResponse> Dto)
        {
            async Task<string> fun(Action<HttpRequestMessage> req, Action<HttpResponseMessage> res)
            {
                var dto = Dto as GetMeetingsRequest;
                var qs = dto.ToQueryString();
                var url = Host + Endpoint;
                url += String.IsNullOrWhiteSpace(qs) ? "" : ("?" + qs);
                return await url.GetStringFromUrlAsync("application/json", req, res);
                //return url.GetJsonFromUrl(requestFilter, responseFilter); //this doesn't set the Content-Type!
                //var bytes = url.SendBytesToUrl(
                //    method: "GET",
                //    contentType: "application/json",
                //    accept: "*/*",
                //    requestFilter: requestFilter,
                //    responseFilter: responseFilter);
                //return Encoding.Default.GetString(bytes);
            }
            return fun;
        }
    }
}