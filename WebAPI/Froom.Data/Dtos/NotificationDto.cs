using System;

namespace Froom.Data.Dtos
{
    public class NotificationDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string CreatedDate { get; set; }

        public bool IsNew { get; set; }

        /// <summary>
        /// Used only by IMapper. Initializes a new instance of NotificationDto.
        /// </summary>
        public NotificationDto() { }
    }
}