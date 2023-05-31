using ServiceStack;
using ServiceStack.Text;

namespace FacioRatio.Whereby.Api
{
    internal class GetMeetingFun : IApiFun<GetMeetingResponse>
    {
        public string Endpoint => "meetings";

        public Func<Action<HttpRequestMessage>, Action<HttpResponseMessage>, Task<string>> Generate(string Host, IDto<GetMeetingResponse> Dto)
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
                    var dto = Dto as GetMeetingRequest;
                    var fields = String.Join("%2C", dto.Fields);
                    var qs = $"fields={fields}";
                    var url = Host + Endpoint + $"/{dto.MeetingId}?{qs}";
                    return await url.GetStringFromUrlAsync("application/json", req, res);
                }
            }
            return fun;
        }
    }
}