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
    public interface IProductService
    {
       
        Task<List<Product>> GetProducts();

        Task<List<Product>> GetLowStokProducts();
        Task<List<ProductDto>> GetBestSellingProducts(int days = 30);
        Task<Product> GetProduct(int productId);
        Product SaveProduct(Product product);
        void AddProductPictures(ProductPicture productPicture);


    }
}
