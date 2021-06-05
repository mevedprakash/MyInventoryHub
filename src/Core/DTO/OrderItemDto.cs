using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Decimal PriceRate { get; set; }
        [Required]
        public Decimal SubAmount { get; set; }
        [Required]
        public Decimal Discount { get; set; }
        [Required]
        public Decimal Tax { get; set; }
        [Required]
        public Decimal NetAmount { get; set; }
    }
}
