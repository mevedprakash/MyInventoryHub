using Microsoft.EntityFrameworkCore;
using Entity;


namespace Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



        }
        public DbSet<User> User { get; set; }

        public DbSet<Roles> Role { get; set; }

        public DbSet<EmailQueue> EmailQueue { get; set; }
        public DbSet<VerificationCode> VerificationCode { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ProductSupply> ProductSupply { get; set; }

        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Unit> Unit { get; set; }

        public DbSet<Store> Store { get; set; }

    }
}
