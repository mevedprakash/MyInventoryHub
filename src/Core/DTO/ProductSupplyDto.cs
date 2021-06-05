using System;

namespace DTO
{
    public class ProductSupplyDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }        
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public Decimal PurchasPrice { get; set; }
        public Decimal SellingPrice { get; set; }
        public Decimal SubAmount { get; set; }
        public Decimal Discount { get; set; }
        public Decimal Tax { get; set; }
        public Decimal NetAmount { get; set; }
        public int? SupplierId { get; set; }
    }

}
