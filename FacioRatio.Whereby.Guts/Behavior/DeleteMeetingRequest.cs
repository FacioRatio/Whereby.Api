namespace FacioRatio.Whereby.Api
{
    public class DeleteMeetingRequest : IDto<DeleteMeetingResponse>
    {
        /// <summary>
        /// Example: 1
        /// meeting ID
        /// </summary>
        public string MeetingId { get; set; }
    }

    public class DeleteMeetingResponse
    {
        public string Error { get; set; }
    }
}