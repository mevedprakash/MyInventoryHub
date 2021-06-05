using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class ForgetPasswordDto
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string VerificationCode { get; set; }


    }
}
