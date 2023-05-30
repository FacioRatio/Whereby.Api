using FacioRatio.CSharpRailway;

namespace FacioRatio.Whereby.Api
{
    public interface IWherebyMeetingService
    {
        Task<Result<GetMeetingsResponse>> GetMeetings(GetMeetingsRequest Dto);
    }
}
