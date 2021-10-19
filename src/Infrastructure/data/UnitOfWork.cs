using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Interface;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {

        public IRepository<User> UserRespository { get; private set; }
        public IRepository<User> StudentRespository { get; private set; }
        public IRepository<VerificationCode> VerificationCodeRespository { get; private set; }
        public IRepository<EmailQueue> EmailQueueRespository { get; private set; }
        public IRepository<Brand> BrandRepository { get; private set; }

        public IRepository<Product> ProductRepository { get; private set; }
        public IRepository<ProductSupply> ProductSupplyRepository { get; private set; }
        public IRepository<Order> OrderRepository { get; private set; }
        public IRepository<Unit> UnitRepository { get; private set; }
        public IRepository<Store> StoreRepository { get; private set; }

        public IRepository<OrderItem> OrderItemRepository { get; private set; }

        public IRepository<ProductPicture> ProductPictureRepository { get; private set; }
        public IRepository<Picture> PictureRepository { get; private set; }
        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {

            StudentRespository = new Repository<User>(dbContext);
            UserRespository = new Repository<User>(dbContext);
            VerificationCodeRespository = new Repository<VerificationCode>(dbContext);
            EmailQueueRespository = new Repository<EmailQueue>(dbContext);
            BrandRepository = new Repository<Brand>(dbContext);
            ProductRepository = new Repository<Product>(dbContext);
            ProductSupplyRepository = new Repository<ProductSupply>(dbContext);
            OrderRepository = new Repository<Order>(dbContext);
            UnitRepository = new Repository<Unit>(dbContext);
            StoreRepository = new Repository<Store>(dbContext);
            OrderItemRepository = new Repository<OrderItem>(dbContext);
            ProductPictureRepository = new Repository<ProductPicture>(dbContext);
            PictureRepository = new Repository<Picture>(dbContext);
            this.dbContext = dbContext;
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
