using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public string ProfileImageId { get; set; }
    }
}
