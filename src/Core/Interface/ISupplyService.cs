using DTO;
using DTO.CustomModel;
using Entity;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface ISupplyService
    {    
        Task<List<ProductSupply>> GetProductSupply();
        ProductSupply SaveProductSupply(ProductSupply productSupply);
    }
}
