namespace FacioRatio.Whereby.Api
{
    public class GetMeetingsRequest : IDto<GetMeetingsResponse>
    {
        /// <summary>
        /// Example: cursor=8f4031bfc7640c5f267b11b6fe0c2507. 
        /// The cursor for paginating through the results.To fetch the next page, set the cursor to the cursor returned by the previous request.
        /// </summary>
        public string Cursor { get; set; }

        /// <summary>
        /// integer [ 1 .. 100 ]
        /// Default: 50
        /// The limit for the pagination - the maximum number of results that will be returned within a single API response.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Array of strings(Fields)
        /// Items Enum: "hostRoomUrl" "viewerRoomUrl"
        /// Additional fields that should be populated.
        /// hostRoomUrl - Include hostRoomUrl field in the meeting response.
        /// viewerRoomUrl - Include viewerRoomUrl field in the meeting response.
        /// </summary>
        public string[] Fields { get; set; }
    }

    public class GetMeetingsResponse
    {
        public List<Meeting> Results { get; set; }
        public string Fursor { get; set; }
        public string Error { get; set; }
    }
}

//{
//  "results": [
//    {
//      "meetingId": "1",
//      "startDate": "2020-05-12T16:42:49Z",
//      "endDate": "2020-05-12T17:42:49Z",
//      "roomUrl": "https://subdomain.whereby.com/dda1beca-af37-11eb-ac88-372b6869f077"
//    }
//  ],
//  "cursor": "string"
//}