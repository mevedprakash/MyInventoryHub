using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.ViewModel
{
    public class ProductOrderViewModel
    {
        public OrderDto  Order { get; set; }
        public CustomerDto Customer { get; set; }
    }

    public class ProductSupplyViewModel
    {
        public ProductSupplyDto ProductSupply { get; set; }
        public SupplierDto Supplier { get; set; }
    }
}
