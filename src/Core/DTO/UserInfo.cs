using System;
using System.Collections.Generic;

namespace DTO
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime TokenValidity { get; set; }
        public string StudentType { get; set; }
        public IList<string> Roles { get; set; }
        public bool IsAppAdmin { get; set; }
        public string InstituteId { get; set; }
        public string StudentId { get; set; }
    }


}
