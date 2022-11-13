﻿using System.ComponentModel.DataAnnotations;

namespace Cliente.Models.VMs
{
    public class UserViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
