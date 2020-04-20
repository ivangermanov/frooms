﻿using Froom.Data.Entities;
using System;

namespace Froom.Data.Models.Users
{
    public class PostUserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
    }
}
