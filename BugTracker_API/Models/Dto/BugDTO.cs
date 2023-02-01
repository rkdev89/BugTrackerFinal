﻿using System.ComponentModel.DataAnnotations;

namespace BugTracker_API.Models.Dto
{
    public class BugDTO
    {
        [Key]
        public int BugId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public DateOnly DateCreated { get; set; }
        [Required]
        public UserDTO User { get; set; }
    }
}
