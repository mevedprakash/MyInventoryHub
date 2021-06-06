using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int Status { get; set; }
        [Required]
        public Decimal SubAmount { get; set; }
        [Required]
        public Decimal Discount { get; set; }
        [Required]
        public Decimal Tax { get; set; }
        [Required]
        public Decimal NetAmount { get; set; }
        public int? CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public DateTime CreatedAt { get; set; }

        public PaymentDto Payment { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
    public class PaymentDto
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
    }
}
