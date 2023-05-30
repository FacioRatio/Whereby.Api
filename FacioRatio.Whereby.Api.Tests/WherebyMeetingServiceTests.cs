using FacioRatio.Whereby.Api;

namespace FacioRatio.Whereby.Tests
{
    public class WherebyMeetingServiceTests
    {
        public IWherebyMeetingService BuildWherebyFacade()
        {
            var creds = new ApiCreds("https://api.whereby.dev/v1/", "");
            var facade = new WherebyMeetingService(
                new ApiCall<CreateMeetingResponse>(creds, new CreateMeetingFun()),
                new ApiCall<GetMeetingsResponse>(creds, new GetMeetingsFun()),
                new ApiCall<GetMeetingResponse>(creds, new GetMeetingFun()),
                new ApiCall<DeleteMeetingResponse>(creds, new DeleteMeetingFun())
            );
            return facade;
        }

        [Fact]
        public async Task MeetingsWork()
        {
            var sut = BuildWherebyFacade();

            async Task<string> testCreateMeeting()
            {
                var dto = new CreateMeetingRequest()
                {
                    IsLocked = true,
                    RoomMode = "normal",
                    RoomNamePattern = "human-short",
                    RoomNamePrefix = "test",
                    Fields = new string[] { "hostRoomUrl", "viewerRoomUrl" },
                    EndDate = DateTime.UtcNow.AddMinutes(1)
                };
                var result = await sut.CreateMeeting(dto);

                Assert.NotNull(result);
                Assert.Null(result.Error);

                return result.MeetingId;
            }

            async Task testGetMeetings()
            {
                var dto = new GetMeetingsRequest()
                {
                    Fields = new string[] { "hostRoomUrl", "viewerRoomUrl" },
                    Cursor = null,
                    Limit = 1
                };
                var result = await sut.GetMeetings(dto);

                Assert.NotNull(result);
                Assert.Null(result.Error);
                Assert.NotEmpty(result.Results);
                Assert.NotNull(result.Results[0].HostRoomUrl);
                Assert.NotNull(result.Results[0].ViewerRoomUrl);
            }

            async Task testGetMeeting(string meetingId)
            {
                var dto = new GetMeetingRequest()
                {
                    MeetingId = meetingId,
                    Fields = new string[] { "hostRoomUrl", "viewerRoomUrl" },
                };
                var result = await sut.GetMeeting(dto);

                Assert.NotNull(result);
                Assert.Null(result.Error);
                Assert.Equal(meetingId, result.MeetingId);
                Assert.NotNull(result.HostRoomUrl);
                Assert.NotNull(result.ViewerRoomUrl);
            }

            async Task testDeleteMeeting(string meetingId)
            {
                var dto = new DeleteMeetingRequest()
                {
                    MeetingId = meetingId
                };
                var result = await sut.DeleteMeeting(dto);

                Assert.NotNull(result);
                Assert.Null(result.Error);
            }

            string meetingId = await testCreateMeeting();
            await testGetMeetings();
            await testGetMeeting(meetingId);
            await testDeleteMeeting(meetingId);
        }
    }
}