namespace FacioRatio.Whereby.Api
{
    //!!use JsConfig options to send camelCase so that we do not need to violate our naming conventions
    public class GetMeetingRequest : IDto<GetMeetingResponse>
    {
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// Example: 1
        /// meeting ID
        /// </summary>
        public string meetingId { get; set; }

        /// <summary>
        /// Array of strings(Fields)
        /// Items Enum: "hostRoomUrl" "viewerRoomUrl"
        /// Additional fields that should be populated.
        /// hostRoomUrl - Include hostRoomUrl field in the meeting response.
        /// viewerRoomUrl - Include viewerRoomUrl field in the meeting response.
        /// </summary>
        public string[] fields { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }

    public class GetMeetingResponse : Meeting
    {
    }
}

//{
//  "meetingId": "1",
//  "startDate": "2020-05-12T16:42:49Z",
//  "endDate": "2020-05-12T17:42:49Z",
//  "roomUrl": "https://subdomain.whereby.com/dda1beca-af37-11eb-ac88-372b6869f077"
//}
