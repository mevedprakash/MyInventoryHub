
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{

    public class UserRoles : BaseEntity
    {
        [Required]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        public Roles Roles { get; set; }
    }
}
