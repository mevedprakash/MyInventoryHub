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
    public interface IBrandService
    {
        Task<List<Brand>> GetBrands();
        Task<Brand> GetBrand(int brandId);
        Brand SaveBrand(Brand brand);
        void DeleteBrand(int brandId);
    }
}
