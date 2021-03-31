﻿using System.ComponentModel.DataAnnotations;

namespace Ums.Application.DTOs.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}