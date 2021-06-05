using Entity;
using Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SupplyService : ISupplyService
    {
        private IUnitOfWork unitOfWork { get; }

        public SupplyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
       
        public async Task<List<ProductSupply>> GetProductSupply()
        {
            return await unitOfWork.ProductSupplyRepository.GetAsync();
        }

        public ProductSupply SaveProductSupply(ProductSupply productSupply)
        {
            if (productSupply.Id==0)
            {
                unitOfWork.ProductSupplyRepository.Add(productSupply);
            }
            unitOfWork.SaveChanges();
            return productSupply;
        }

       
    }
}
