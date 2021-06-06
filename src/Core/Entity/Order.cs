
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{

    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int Status { get; set; }
        public Decimal SubAmount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal Tax { get; set; }
        public Decimal NetAmount { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Payment")]
        public int? PaymentId { get; set; }
        public Payment Payment { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
