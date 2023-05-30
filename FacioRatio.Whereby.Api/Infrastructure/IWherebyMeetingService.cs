namespace FacioRatio.Whereby.Api
{
    public interface IWherebyMeetingService
    {
        Task<GetMeetingsResponse> GetMeetings(GetMeetingsRequest Dto);
        Task<GetMeetingResponse> GetMeeting(GetMeetingRequest Dto);
        Task<DeleteMeetingResponse> DeleteMeeting(DeleteMeetingRequest Dto);
        Task<CreateMeetingResponse> CreateMeeting(CreateMeetingRequest Dto);
    }
}
