
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{

    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string SKU { get; set; }

        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("Image")]
        public int? ImageId { get; set; }
        public FileStore Image { get; set; }      
        public Decimal PurchasePrice { get; set; }
        public Decimal SalePrice { get; set; }

        public int? UnitId { get; set; }

        [Required]
        public int AvaiableQuantity { get; set; }
        public int MinQuantityLimit { get; set; }
        public ICollection<ProductSupply> ProductSupplies { get; set; }
    }
}
