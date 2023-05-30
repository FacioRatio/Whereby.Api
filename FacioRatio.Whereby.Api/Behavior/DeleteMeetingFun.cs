using ServiceStack;

namespace FacioRatio.Whereby.Api
{
    public class DeleteMeetingFun : IApiFun<DeleteMeetingResponse>
    {
        public string Endpoint => "meetings";

        public Func<Action<HttpRequestMessage>, Action<HttpResponseMessage>, Task<string>> Generate(string Host, IDto<DeleteMeetingResponse> Dto)
        {
            async Task<string> fun(Action<HttpRequestMessage> req, Action<HttpResponseMessage> res)
            {
                var dto = Dto as DeleteMeetingRequest;
                var url = Host + Endpoint + $"/{dto.meetingId}";
                return await url.DeleteFromUrlAsync(null, req, res);
            }
            return fun;
        }
    }
}