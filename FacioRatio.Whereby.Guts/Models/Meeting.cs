namespace FacioRatio.Whereby.Api
{
#pragma warning disable IDE1006 // Naming Styles
    public class Meeting
    {
        public string meetingId { get; set; }
        public DateTimeOffset startDate { get; set; }
        public DateTimeOffset endDate { get; set; }
        public string roomName { get; set; }
        public string roomUrl { get; set; }
        public string hostRoomUrl { get; set; }
        public string viewerRoomUrl { get; set; }
    }
#pragma warning restore IDE1006 // Naming Styles
}
