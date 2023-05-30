namespace FacioRatio.Whereby.Api
{
    public class WherebyMeetingService : IWherebyMeetingService
    {
        private readonly IApiCall<CreateMeetingResponse> CreateMeetingApiCall;
        private readonly IApiCall<GetMeetingsResponse> GetMeetingsApiCall;
        private readonly IApiCall<GetMeetingResponse> GetMeetingApiCall;
        private readonly IApiCall<DeleteMeetingResponse> DeleteMeetingApiCall;

        //internal constructor is for testing and internal IoC
        internal WherebyMeetingService(
            IApiCall<CreateMeetingResponse> CreateMeetingApiCall,
            IApiCall<GetMeetingsResponse> GetMeetingsApiCall,
            IApiCall<GetMeetingResponse> GetMeetingApiCall,
            IApiCall<DeleteMeetingResponse> DeleteMeetingApiCall)
        {
            this.CreateMeetingApiCall = CreateMeetingApiCall;
            this.GetMeetingsApiCall = GetMeetingsApiCall;
            this.GetMeetingApiCall = GetMeetingApiCall;
            this.DeleteMeetingApiCall = DeleteMeetingApiCall;
        }

        //public constructors are for consumption
        public WherebyMeetingService(IApiCreds ApiCreds, IApiCallConfig ApiCallConfig)
        {
            this.CreateMeetingApiCall = new ApiCallRateLimitDecorator<CreateMeetingResponse>(new ApiCall<CreateMeetingResponse>(ApiCreds, new CreateMeetingFun()), ApiCallConfig);
            this.GetMeetingsApiCall = new ApiCallRateLimitDecorator<GetMeetingsResponse>(new ApiCall<GetMeetingsResponse>(ApiCreds, new GetMeetingsFun()), ApiCallConfig);
            this.GetMeetingApiCall = new ApiCallRateLimitDecorator<GetMeetingResponse>(new ApiCall<GetMeetingResponse>(ApiCreds, new GetMeetingFun()), ApiCallConfig);
            this.DeleteMeetingApiCall = new ApiCallRateLimitDecorator<DeleteMeetingResponse>(new ApiCall<DeleteMeetingResponse>(ApiCreds, new DeleteMeetingFun()), ApiCallConfig);
        }

        public WherebyMeetingService(string Host, string Token, int RetryAttempts = 0)
            : this(new ApiCreds(Host, Token), new ApiCallConfig(RetryAttempts))
        {
        }

        public async Task<CreateMeetingResponse> CreateMeeting(CreateMeetingRequest Dto)
        {
            var result = await CreateMeetingApiCall.Invoke(Dto);
            return result.Ok
                ? result.Value
                : new CreateMeetingResponse() { Error = $"[{result.HttpStatusCode}] {result.Body}" };
        }

        public async Task<GetMeetingsResponse> GetMeetings(GetMeetingsRequest Dto)
        {
            var result = await GetMeetingsApiCall.Invoke(Dto);
            return result.Ok
                ? result.Value
                : new GetMeetingsResponse() { Error = $"[{result.HttpStatusCode}] {result.Body}" };
        }

        public async Task<GetMeetingResponse> GetMeeting(GetMeetingRequest Dto)
        {
            var result = await GetMeetingApiCall.Invoke(Dto);
            return result.Ok
                ? result.Value
                : new GetMeetingResponse() { Error = $"[{result.HttpStatusCode}] {result.Body}" };
        }

        public async Task<DeleteMeetingResponse> DeleteMeeting(DeleteMeetingRequest Dto)
        {
            var result = await DeleteMeetingApiCall.Invoke(Dto);
            return result.Ok
                ? new DeleteMeetingResponse()
                : new DeleteMeetingResponse() { Error = $"[{result.HttpStatusCode}] {result.Body}" };
        }
    }
}
