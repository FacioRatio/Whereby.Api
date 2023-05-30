using FacioRatio.Whereby.Api;

namespace FacioRatio.Whereby.Tests
{
    public class WherebyMeetingServiceTests
    {
        private readonly IApiCreds ApiCreds;

        public WherebyMeetingServiceTests()
        {
            this.ApiCreds = new ApiCreds("", "");
        }

        public IWherebyMeetingService BuildWherebyFacade()
        {
            var facade = new WherebyMeetingService(
                new ApiCall<GetMeetingsResponse>(
                    ApiCreds, 
                    new GetMeetingsFun()),
                new ApiCall<GetMeetingResponse>(
                    ApiCreds,
                    new GetMeetingFun()),
                new ApiCall<DeleteMeetingResponse>(
                    ApiCreds,
                    new DeleteMeetingFun()),
                new ApiCall<CreateMeetingResponse>(
                    ApiCreds,
                    new CreateMeetingFun())
                );
            return facade;
        }

        
    }
}