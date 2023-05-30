namespace FacioRatio.Whereby.Api
{
    public class Meeting
    {
        public string MeetingId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string RoomName { get; set; }
        public string RoomUrl { get; set; }
        public string HostRoomUrl { get; set; }
        public string ViewerRoomUrl { get; set; }
    }
}
