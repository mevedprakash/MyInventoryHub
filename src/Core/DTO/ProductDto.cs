using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Detail { get; set; }
        public string SKU { get; set; }
        public int? BrandId { get; set; }
        public int? ImageId { get; set; }

        public Decimal PurchasePrice { get; set; }      
        public Decimal SalePrice { get; set; }

        public int UnitId { get; set; }
        [Required]
        public int AvaiableQuantity { get; set; }
        public int MinQuantityLimit { get; set; }

        public int SoldQuantity { get; set; }
    }


   
    
}
