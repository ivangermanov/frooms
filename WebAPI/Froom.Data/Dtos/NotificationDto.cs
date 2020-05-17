using System;

namespace Froom.Data.Dtos
{
    public class NotificationDto
    {
        public Guid UserId { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Used only by IMapper. Initializes a new instance of NotificationDto.
        /// </summary>
        public NotificationDto() { }
    }
}
