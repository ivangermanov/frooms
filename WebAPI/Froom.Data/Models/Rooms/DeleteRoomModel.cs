﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Froom.Data.Models.Rooms
{
    public class DeleteRoomModel
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public string BuildingName { get; set; }
    }
}