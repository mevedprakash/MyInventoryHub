using Entity;
using Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BrandService : IBrandService
    {
        private IUnitOfWork unitOfWork { get; }

        public BrandService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void DeleteBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public async Task<Brand> GetBrand(int brandId)
        {
            return await unitOfWork.BrandRepository.GetOneAsync(x => x.Id == brandId);
        }

        public async Task<List<Brand>> GetBrands()
        {
            return await unitOfWork.BrandRepository.GetAsync();
        }

        public Brand SaveBrand(Brand brand)
        {
            if (brand.Id == 0)
            {
                brand.CreatedAt = DateTime.UtcNow;
                brand.ModifiedAt = DateTime.UtcNow;
                unitOfWork.BrandRepository.Add(brand);
            }
            else
            {
                brand.ModifiedAt = DateTime.UtcNow;
            }
            unitOfWork.SaveChanges();
            return brand;
        }

    }
}
