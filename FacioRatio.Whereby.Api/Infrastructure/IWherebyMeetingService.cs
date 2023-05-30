namespace FacioRatio.Whereby.Api
{
    public interface IWherebyMeetingService
    {
        Task<CreateMeetingResponse> CreateMeeting(CreateMeetingRequest Dto);
        Task<GetMeetingsResponse> GetMeetings(GetMeetingsRequest Dto);
        Task<GetMeetingResponse> GetMeeting(GetMeetingRequest Dto);
        Task<DeleteMeetingResponse> DeleteMeeting(DeleteMeetingRequest Dto);
    }
}
