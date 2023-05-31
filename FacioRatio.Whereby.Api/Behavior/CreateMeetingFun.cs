using ServiceStack;
using ServiceStack.Text;

namespace FacioRatio.Whereby.Api
{
    internal class CreateMeetingFun : IApiFun<CreateMeetingResponse>
    {
        public string Endpoint => "meetings";

        public Func<Action<HttpRequestMessage>, Action<HttpResponseMessage>, Task<string>> Generate(string Host, IDto<CreateMeetingResponse> Dto)
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
                    var dto = (Dto as CreateMeetingRequest).ToJson();
                    var url = Host + Endpoint;
                    return await url.PostStringToUrlAsync(dto, "application/json", null, req, res);
                }
            }
            return fun;
        }
    }
}