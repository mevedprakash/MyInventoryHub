using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IUnitOfWork
    {
      
        IRepository<User> UserRespository { get; }
        
        IRepository<EmailQueue> EmailQueueRespository { get; }
        IRepository<VerificationCode> VerificationCodeRespository { get; }
        IRepository<Brand> BrandRepository { get; }

        IRepository<Product> ProductRepository { get; }

        IRepository<ProductSupply> ProductSupplyRepository { get; }

        IRepository<Order> OrderRepository { get; }
        IRepository<OrderItem> OrderItemRepository { get; }
        IRepository<Unit> UnitRepository { get; }

        IRepository<Store> StoreRepository { get; }
        IRepository<ProductPicture> ProductPictureRepository { get; }
        IRepository<Picture> PictureRepository { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();

    }
}
