using Froom.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Froom.Models
{
    public class UserInfo
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}