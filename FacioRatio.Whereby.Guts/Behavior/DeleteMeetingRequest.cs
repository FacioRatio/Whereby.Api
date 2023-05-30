namespace FacioRatio.Whereby.Api
{
    //!!use JsConfig options to send camelCase so that we do not need to violate our naming conventions
    public class DeleteMeetingRequest : IDto<DeleteMeetingResponse>
    {
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// Example: 1
        /// meeting ID
        /// </summary>
        public string meetingId { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }

    public class DeleteMeetingResponse
    {
    }
}