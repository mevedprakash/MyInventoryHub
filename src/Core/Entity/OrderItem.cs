
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{

    public class OrderItem : BaseEntity
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public Decimal PriceRate { get; set; }
        public Decimal SubAmount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal Tax { get; set; }
        public Decimal NetAmount { get; set; }



    }
}
