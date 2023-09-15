﻿using System.ComponentModel.DataAnnotations;

namespace WebSec.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
