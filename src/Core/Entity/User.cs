using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{

    public class User : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("Image")]
        public int? ImageId { get; set; }
        public FileStore Image { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }


    
}
