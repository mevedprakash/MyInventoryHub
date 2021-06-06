using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class BrandDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Detail { get; set; }
        public int? ImageId { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
