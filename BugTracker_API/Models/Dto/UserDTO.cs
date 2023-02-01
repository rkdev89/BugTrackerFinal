﻿using System.ComponentModel.DataAnnotations;

namespace BugTracker_API.Models.Dto
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}