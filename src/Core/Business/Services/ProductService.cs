using DTO;
using Entity;
using Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork { get; }

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<List<Product>> GetProducts()
        {
            return await unitOfWork.ProductRepository.GetAsync();
        }
        public async Task<List<Product>> GetLowStokProducts()
        {
            return await unitOfWork.ProductRepository.TableNoTrack.Where(x => x.AvaiableQuantity <= 10).ToListAsync();
        }
        public Product SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                product.CreatedAt = DateTime.UtcNow;
                product.ModifiedAt = DateTime.UtcNow;
                unitOfWork.ProductRepository.Add(product);
            }
            else
            {
                product.ModifiedAt = DateTime.UtcNow;
            }
            unitOfWork.SaveChanges();
            return product;
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await unitOfWork.ProductRepository.GetOneAsync(x => x.Id == productId);
        }

        public async Task<List<ProductDto>> GetBestSellingProducts(int days = 30)
        {
            return await unitOfWork.OrderItemRepository.TableNoTrack.Include(x => x.Product)
                .Where(x => x.Order.CreatedAt >= DateTime.Now.AddDays(-days))
                .GroupBy(x => x.ProductId)
                .Select(x => new ProductDto { Id = x.Key, SoldQuantity = x.Sum(a => a.Quantity) })
                .OrderByDescending(x => x.SoldQuantity)
                .Select(x =>x)
                .Take(10)
                .ToListAsync();           
        }
        public void AddProductPictures(ProductPicture productPicture)
        {

            if (productPicture == null)
                throw new ArgumentNullException(nameof(productPicture));
            unitOfWork.ProductPictureRepository.Add(productPicture);
            unitOfWork.SaveChanges();
            return;

        }

    }
}
