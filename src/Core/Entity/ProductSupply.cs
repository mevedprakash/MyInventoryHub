
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{

    public class ProductSupply : BaseEntity
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public Decimal PurchasPrice { get; set; }
        public Decimal SellingPrice { get; set; }
        public Decimal SubAmount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal Tax { get; set; }
        public Decimal NetAmount { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
