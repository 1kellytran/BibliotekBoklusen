﻿using System.ComponentModel.DataAnnotations;

namespace BibliotekBoklusen.Shared
{
    public class LoginDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
    }
}