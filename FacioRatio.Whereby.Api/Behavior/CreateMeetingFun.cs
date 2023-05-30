using ServiceStack;

namespace FacioRatio.Whereby.Api
{
    public class CreateMeetingFun : IApiFun<CreateMeetingResponse>
    {
        public string Endpoint => "meetings";

        public Func<Action<HttpRequestMessage>, Action<HttpResponseMessage>, Task<string>> Generate(string Host, IDto<CreateMeetingResponse> Dto)
        {
            async Task<string> fun(Action<HttpRequestMessage> req, Action<HttpResponseMessage> res)
            {
                var dto = Dto as CreateMeetingRequest;
                var url = Host + Endpoint;
                return await url.PostStringToUrlAsync(dto.ToJson(), "application/json", null, req, res);
            }
            return fun;
        }
    }
}