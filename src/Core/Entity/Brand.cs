using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class Brand : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }

        [ForeignKey("Image")]
        public int? ImageId { get; set; }
        public FileStore Image { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
