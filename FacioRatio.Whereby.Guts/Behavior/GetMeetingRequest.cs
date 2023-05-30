namespace FacioRatio.Whereby.Api
{
    public class GetMeetingRequest : IDto<GetMeetingResponse>
    {
        /// <summary>
        /// Example: 1
        /// meeting ID
        /// </summary>
        public string MeetingId { get; set; }

        /// <summary>
        /// Array of strings(Fields)
        /// Items Enum: "hostRoomUrl" "viewerRoomUrl"
        /// Additional fields that should be populated.
        /// hostRoomUrl - Include hostRoomUrl field in the meeting response.
        /// viewerRoomUrl - Include viewerRoomUrl field in the meeting response.
        /// </summary>
        public string[] Fields { get; set; }
    }

    public class GetMeetingResponse : Meeting
    {
        public string Error { get; set; }
    }
}

//{
//  "meetingId": "1",
//  "startDate": "2020-05-12T16:42:49Z",
//  "endDate": "2020-05-12T17:42:49Z",
//  "roomUrl": "https://subdomain.whereby.com/dda1beca-af37-11eb-ac88-372b6869f077"
//}
