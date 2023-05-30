using FacioRatio.CSharpRailway;

namespace FacioRatio.Whereby.Api
{
    public class WherebyMeetingService : IWherebyMeetingService
    {
        private readonly IApiCall<GetMeetingsResponse> GetMeetingsApiCall;

        //internal constructor is for testing
        internal WherebyMeetingService(
            IApiCreds ApiCreds,
            IApiFun<GetMeetingsResponse> GetMeetingsApiFun)
        {
            this.GetMeetingsApiCall = new ApiCall<GetMeetingsResponse>(ApiCreds, GetMeetingsApiFun);
        }

        //public constructors are for consumption
        public WherebyMeetingService(IApiCreds ApiCreds, IApiCallConfig ApiCallConfig)
        {
            this.GetMeetingsApiCall = new ApiCallRateLimitDecorator<GetMeetingsResponse>(new ApiCall<GetMeetingsResponse>(ApiCreds, new GetMeetingsFun()), ApiCallConfig);
        }

        public WherebyMeetingService(string Host, string Token, int RetryAttempts = 0)
            : this(new ApiCreds(Host, Token), new ApiCallConfig(RetryAttempts))
        {
        }

        public async Task<Result<GetMeetingsResponse>> GetMeetings(GetMeetingsRequest Dto)
        {
            return await GetMeetingsApiCall.Invoke(Dto)
                .Bind(getMeetingsResult => getMeetingsResult.Value)
                .OnFailure(ex => ex.Rethrow());
        }
    }
}
