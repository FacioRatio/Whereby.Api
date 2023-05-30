using ServiceStack;
using ServiceStack.Text;

namespace FacioRatio.Whereby.Api
{
    public class DeleteMeetingFun : IApiFun<DeleteMeetingResponse>
    {
        public string Endpoint => "meetings";

        public Func<Action<HttpRequestMessage>, Action<HttpResponseMessage>, Task<string>> Generate(string Host, IDto<DeleteMeetingResponse> Dto)
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
                    var dto = Dto as DeleteMeetingRequest;
                    var url = Host + Endpoint + $"/{dto.MeetingId}";
                    return await url.DeleteFromUrlAsync(null, req, res);
                }
            }
            return fun;
        }
    }
}