namespace FacioRatio.Whereby.Api
{
    public class CreateMeetingRequest : IDto<CreateMeetingResponse>
    {
        /// <summary>
        /// Value: "viewerMode"
        /// [BETA]: This is a beta feature, and might change in the future.If provided, the room will be created with the given template type. Each template defines a set of properties needed for a particular use-case. Currently the only supported template type is "viewerMode". This will set up a room with properties that are needed to create a viewer mode room.The room will be locked, roomMode set to "group" and fields like hostRoomUrl and viewerRoomUrl will be added to the response.
        /// </summary>
        public string TemplateType { get; set; }

        /// <summary>
        /// The initial lock state of the room. If true, only hosts will be able to let in other participants and change lock state.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// <= 39 characters [a-z0-9]{0,39}
        /// This will be used as the prefix for the room name.The string should be lowercase, and spaces will be automatically removed.
        /// </summary>
        public string RoomNamePrefix { get; set; }

        /// <summary>
        /// Default: "uuid"
        /// Enum: "uuid" "human-short"
        /// The format of the randomly generated room name.uuid is the default room name pattern and follows the usual 8-4-4-4-12 pattern.human-short generates a shorter string made up of six distinguishable characters.
        /// </summary>
        public string RoomNamePattern { get; set; }

        /// <summary>
        /// Default: "normal"
        /// Enum: "group" "normal"
        /// The mode of the created transient room.normal is the default room mode and should be used for meetings up to 4 participants.group should be used for meetings that require more than 4 participants.
        /// </summary>
        public string RoomMode { get; set; }

        /// <summary>
        /// When the meeting ends. By default in UTC but a timezone can be specified, e.g. 2021-05-07T17:42:49-05:00. This has to be the same or after the current date.
        /// </summary>
        public DateTimeOffset EndDate { get; set; }

        //!!recording
        //!!streaming

        /// <summary>
        /// Array of strings(Fields)
        /// Items Enum: "hostRoomUrl" "viewerRoomUrl"
        /// Additional fields that should be populated.
        /// hostRoomUrl - Include hostRoomUrl field in the meeting response.
        /// viewerRoomUrl - Include viewerRoomUrl field in the meeting response.
        /// </summary>
        public string[] Fields { get; set; }
    }

    public class CreateMeetingResponse : Meeting
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
