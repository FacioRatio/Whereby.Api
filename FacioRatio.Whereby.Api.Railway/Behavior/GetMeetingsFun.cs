using FacioRatio.CSharpRailway;

namespace FacioRatio.Whereby.Api
{
    public class GetMeetingsFun : IApiFun<GetMeetingsResponse>
    {
        public string Endpoint => "meetings";

        public Func<Action<HttpRequestMessage>, Action<HttpResponseMessage>, Task<Result<string>>> Generate(string Host, IDto<GetMeetingsResponse> Dto)
        {
            async Task<Result<string>> fun(Action<HttpRequestMessage> req, Action<HttpResponseMessage> res)
            {
                var qs = Dto.ToQueryString();
                var url = Host + Endpoint;
                url += String.IsNullOrWhiteSpace(qs) ? "" : ("?" + qs);
                var result = await url.GetJsonResultFromUrlAsync(req, res);
                return result;
            }
            return fun;
        }
    }
}