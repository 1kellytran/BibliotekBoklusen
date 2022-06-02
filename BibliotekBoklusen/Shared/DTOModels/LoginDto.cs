﻿using System.ComponentModel.DataAnnotations;

namespace BibliotekBoklusen.Shared
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Obligatoriskt fält")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Obligatoriskt fält")]
        public string Password { get; set; } = string.Empty;
    }
}
