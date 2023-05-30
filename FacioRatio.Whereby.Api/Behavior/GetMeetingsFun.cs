using ServiceStack;
using ServiceStack.Text;

namespace FacioRatio.Whereby.Api
{
    public class GetMeetingsFun : IApiFun<GetMeetingsResponse>
    {
        public string Endpoint => "meetings";

        public Func<Action<HttpRequestMessage>, Action<HttpResponseMessage>, Task<string>> Generate(string Host, IDto<GetMeetingsResponse> Dto)
        {
            async Task<string> fun(Action<HttpRequestMessage> req, Action<HttpResponseMessage> res)
            {
                using (JsConfig.With(new Config()
                {
                    TextCase = TextCase.CamelCase,
                    PropertyConvention = PropertyConvention.Lenient,
                    DateHandler = DateHandler.ISO8601
                }))
                {
                    var dto = Dto as GetMeetingsRequest;
                    
                    var qs = dto.ToQueryString();
                    var url = Host + Endpoint;
                    url += String.IsNullOrWhiteSpace(qs) ? "" : ("?" + qs);
                    return await url.GetStringFromUrlAsync("application/json", req, res);
                }
            }
            return fun;
        }
    }
}