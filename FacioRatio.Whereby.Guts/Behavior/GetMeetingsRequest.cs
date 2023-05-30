namespace FacioRatio.Whereby.Api
{
    //!!use JsConfig options to send camelCase so that we do not need to violate our naming conventions
    public class GetMeetingsRequest : IDto<GetMeetingsResponse>
    {
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// Example: cursor=8f4031bfc7640c5f267b11b6fe0c2507. 
        /// The cursor for paginating through the results.To fetch the next page, set the cursor to the cursor returned by the previous request.
        /// </summary>
        public string cursor { get; set; }

        /// <summary>
        /// integer [ 1 .. 100 ]
        /// Default: 50
        /// The limit for the pagination - the maximum number of results that will be returned within a single API response.
        /// </summary>
        public int limit { get; set; }

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

    public class GetMeetingsResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public List<Meeting> results { get; set; }
        public string cursor { get; set; }
#pragma warning restore IDE1006 // Naming Styles
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