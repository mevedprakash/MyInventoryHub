using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class AuthResponse
    {   
        public int UserId { get; set; }
        public string AccessToken { get; set; }
        public DateTime TokenExpireAt { get; set; }
    } 
}
