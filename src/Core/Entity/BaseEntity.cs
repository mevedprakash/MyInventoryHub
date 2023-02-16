
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    
    public class BaseEntity
    {
        
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
