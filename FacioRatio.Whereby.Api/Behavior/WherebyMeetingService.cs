namespace FacioRatio.Whereby.Api
{
    public class WherebyMeetingService : IWherebyMeetingService
    {
        private readonly IApiCall<GetMeetingsResponse> GetMeetingsApiCall;
        private readonly IApiCall<GetMeetingResponse> GetMeetingApiCall;
        private readonly IApiCall<DeleteMeetingResponse> DeleteMeetingApiCall;
        private readonly IApiCall<CreateMeetingResponse> CreateMeetingApiCall;

        //internal constructor is for testing and internal IoC
        internal WherebyMeetingService(
            IApiCall<GetMeetingsResponse> GetMeetingsApiCall,
            IApiCall<GetMeetingResponse> GetMeetingApiCall,
            IApiCall<DeleteMeetingResponse> DeleteMeetingApiCall,
            IApiCall<CreateMeetingResponse> CreateMeetingApiCall)
        {
            this.GetMeetingsApiCall = GetMeetingsApiCall;
            this.GetMeetingApiCall = GetMeetingApiCall;
            this.DeleteMeetingApiCall = DeleteMeetingApiCall;
            this.CreateMeetingApiCall = CreateMeetingApiCall;
        }

        //public constructors are for consumption
        public WherebyMeetingService(IApiCreds ApiCreds, IApiCallConfig ApiCallConfig)
        {
            this.GetMeetingsApiCall = new ApiCallRateLimitDecorator<GetMeetingsResponse>(new ApiCall<GetMeetingsResponse>(ApiCreds, new GetMeetingsFun()), ApiCallConfig);
            this.GetMeetingApiCall = new ApiCallRateLimitDecorator<GetMeetingResponse>(new ApiCall<GetMeetingResponse>(ApiCreds, new GetMeetingFun()), ApiCallConfig);
            this.DeleteMeetingApiCall = new ApiCallRateLimitDecorator<DeleteMeetingResponse>(new ApiCall<DeleteMeetingResponse>(ApiCreds, new DeleteMeetingFun()), ApiCallConfig);
            this.CreateMeetingApiCall = new ApiCallRateLimitDecorator<CreateMeetingResponse>(new ApiCall<CreateMeetingResponse>(ApiCreds, new CreateMeetingFun()), ApiCallConfig);
        }

        public WherebyMeetingService(string Host, string Token, int RetryAttempts = 0)
            : this(new ApiCreds(Host, Token), new ApiCallConfig(RetryAttempts))
        {
        }

        public async Task<GetMeetingsResponse> GetMeetings(GetMeetingsRequest Dto)
        {
            var result = await GetMeetingsApiCall.Invoke(Dto);
            return result.Value;
        }

        public async Task<GetMeetingResponse> GetMeeting(GetMeetingRequest Dto)
        {
            var result = await GetMeetingApiCall.Invoke(Dto);
            return result.Value;
        }

        public async Task<DeleteMeetingResponse> DeleteMeeting(DeleteMeetingRequest Dto)
        {
            var result = await DeleteMeetingApiCall.Invoke(Dto);
            return result.Value;
        }

        public async Task<CreateMeetingResponse> CreateMeeting(CreateMeetingRequest Dto)
        {
            var result = await CreateMeetingApiCall.Invoke(Dto);
            return result.Value;
        }
    }
}
