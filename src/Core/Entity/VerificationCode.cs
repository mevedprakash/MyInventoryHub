using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class VerificationCode
    {
        [Required]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Entity { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}
