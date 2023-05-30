using ServiceStack;

namespace FacioRatio.Whereby.Api
{
    public class GetMeetingFun : IApiFun<GetMeetingResponse>
    {
        public string Endpoint => "meetings";

        public Func<Action<HttpRequestMessage>, Action<HttpResponseMessage>, Task<string>> Generate(string Host, IDto<GetMeetingResponse> Dto)
        {
            async Task<string> fun(Action<HttpRequestMessage> req, Action<HttpResponseMessage> res)
            {
                var dto = Dto as GetMeetingRequest;
                var url = Host + Endpoint + $"/{dto.meetingId}";
                return await url.GetStringFromUrlAsync("application/json", req, res);
            }
            return fun;
        }
    }
}